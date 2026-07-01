import sys
import math
import random
from read_trace import read_trace 

class CacheBlock:
    """
    Represents a single block (or line) in the cache.
    Stores the memory tag and metadata required for replacement policies.
    """
    def __init__(self):
        self.tag = None         # Unique identifier for the memory block stored here
        self.valid = False      # False if empty, True if holding real data
        self.timestamp = 0      # Logical clock timestamp (used to find LRU)
        self.frequency = 0      # Counter of how many times accessed (used for LFU)

class CacheSet:
    """
    Represents a set in a set-associative cache.
    Contains N blocks, where N is the 'associativity' (e.g., 4-way).
    """
    def __init__(self, associativity):
        self.associativity = associativity
        # Create the N blocks that make up this specific set
        self.blocks = [CacheBlock() for _ in range(associativity)]
        
    def access(self, tag, policy, counter):
        """
        Processes a memory request targeting this specific set.
        Returns True for a cache hit and False for a cache miss.
        """
        # CACHE HIT DETECTION
        # Scan all blocks in the set to see if the tag matches a valid block
        for block in self.blocks:
            if block.valid and block.tag == tag:
                block.timestamp = counter # Record "recency" for LRU
                block.frequency += 1      # Record "use frequency" for LFU
                return True # Hit! Data was found in the cache.
                
        # CACHE MISS (Cold/Compulsory)
        # If missed, check if there are any empty blocks we can fill
        for block in self.blocks:
            if not block.valid:
                block.valid = True
                block.tag = tag
                block.timestamp = counter
                block.frequency = 1
                return False # Miss, but filled an empty spot. No eviction needed.
                
        # CACHE MISS & EVICTION (Conflict/Capacity)
        # If the set is entirely full, choose a victim to replace.
        if policy == "Random":
            # Pick any of the 4 blocks at complete random
            victim = random.choice(self.blocks)
            
        elif policy == "LRU":
            # Least Recently Used: Find the block with the smallest timestamp
            victim = min(self.blocks, key=lambda b: b.timestamp)
            
        elif policy == "LFU":
            # Least Frequently Used: Find the block with the lowest access count
            victim = min(self.blocks, key=lambda b: b.frequency)

        # Evict the victim and put the new tag in its place
        victim.tag = tag
        victim.timestamp = counter
        victim.frequency = 1
        return False # Miss, and required eviction.

class LLCSimulator:
    """
    The master simulator handling address translation and routing to the correct sets.
    """
    def __init__(self, cache_size_kb, associativity, block_size, policy):
        # Calculate total sets: (Size in Bytes) / (Block Size * Associativity)
        # 64KB Cache / (16 Bytes * 4 blocks per set) = 1024 sets
        self.num_sets = (cache_size_kb * 1024) // (block_size * associativity)
        
        # Instantiate the array of sets
        self.sets = [CacheSet(associativity) for _ in range(self.num_sets)]
        
        # Calculate how many bits are needed for the Offset and the Index
        # Since block_size is 16, log2(16) = 4 offset bits
        self.offset_bits = int(math.log2(block_size))
        # Since num_sets is 1024, log2(1024) = 10 index bits
        self.index_bits = int(math.log2(self.num_sets))
        
        # Performance trackers
        self.hits = 0
        self.misses = 0
        self.counter = 0 # Logical clock incremented on every memory access
        self.policy = policy # Dictates which replacement algorithm to use
        
    def simulate_access(self, address):
        """
        Takes a full memory address and maps it to a cache set.
        """
        self.counter += 1
        
        # Remove the block offset bits by shifting right
        shifted_addr = address >> self.offset_bits
        
        # Extract the index bits using a bitmask (self.num_sets - 1)
        # This isolates the specific set this address maps to
        index = shifted_addr & (self.num_sets - 1)
        
        # Extract the remaining upper bits to act as the unique Tag
        tag = shifted_addr >> self.index_bits
        
        # Pass the access request directly to the mapped set
        is_hit = self.sets[index].access(tag, self.policy, self.counter)
        
        # Log the simulation result
        if is_hit:
            self.hits += 1
        else:
            self.misses += 1

def run_experiment():
    """
    Initializes environment configurations and loops through the trace files.
    """
    size_kb = 64
    associativity = 4
    block_size = 16
    policies = ["Random", "LRU", "LFU"]
    
    trace_files = [
        "/home/class/comparch/lab4/traces/L1miss-vortex.tr",
        "/home/class/comparch/lab4/traces/L1miss-bzip2.tr",
        "/home/class/comparch/lab4/traces/L1miss-art.tr"
    ]
    
    # Outer Loop: Run every single trace file provided
    for trace_path in trace_files:
        trace_name = trace_path.split('/')[-1]
        print(f"\n{'='*15} Processing Trace: {trace_name} {'='*15}")
        print(f"{'Policy':<10} | {'Hits':<10} | {'Misses':<10} | {'Hit Rate':<10}")
        print("-" * 55)
        
        # Inner Loop: Run the trace file through all 3 policies
        for policy in policies:
            # Create a fresh, empty cache instance for this policy
            simulator = LLCSimulator(size_kb, associativity, block_size, policy)
            
            try:
                # Iterate through millions of address lines provided by read_trace
                for trace_item in read_trace(trace_path):
                    # Guard rails in case read_trace gives a raw hex string or a direct integer
                    if isinstance(trace_item, str):
                        addr = int(trace_item, 16)
                    else:
                        addr = int(trace_item)
                        
                    # Send the converted integer address to the simulator
                    simulator.simulate_access(addr)
                    
            except FileNotFoundError:
                print(f"Error: Trace file {trace_path} not found.")
                return
            
            # Calculate final results
            total_accesses = simulator.hits + simulator.misses
            hit_rate = (simulator.hits / total_accesses) * 100 if total_accesses > 0 else 0
            
            # Print the formatted row in our result table
            print(f"{policy:<10} | {simulator.hits:<10} | {simulator.misses:<10} | {hit_rate:.2f}%")

if __name__ == "__main__":
    run_experiment()
