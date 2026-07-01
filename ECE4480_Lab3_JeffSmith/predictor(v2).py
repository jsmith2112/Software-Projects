import os

# List of trace files containing branch addresses and outcomes (T for Taken, N for Not-Taken)
trace_files = [
    "/home/class/comparch/lab3/traces/branch-vortex.tr",
    "/home/class/comparch/lab3/traces/branch-bzip2.tr",
    "/home/class/comparch/lab3/traces/branch-art.tr"
]

# --- Hardware Configuration ---
PHT_SIZE = 1024  # Number of entries in Pattern History Tables (10-bit index)
HIST_BITS = 10   # Number of bits to track in history registers
HIST_MASK = (1 << HIST_BITS) - 1  # Mask to keep history within 10 bits (0x3FF)

# --- Predictor Implementations ---
def run_simulation(file_path):
    if not os.path.exists(file_path):
        return None

    # Dictionary to track correct vs total predictions for each algorithm
    stats = {k: {'correct': 0, 'total': 0} for k in 
             ['Always-T', 'Always-N', '1-bit', 'Global-2bit', 'Local-2bit', 'Gshare-2bit', 'Gskewed-2bit']}
    
    # Initialize Predictor Tables
    pht_1bit = [0] * PHT_SIZE           # 1-bit: Stores last outcome (0 or 1)
    pht_global = [1] * PHT_SIZE         # 2-bit counters: 0=StrongN, 1=WeakN, 2=WeakT, 3=StrongT
    pht_local = [1] * PHT_SIZE          # 2-bit counters for local patterns
    lht = [0] * PHT_SIZE                # Local History Table: remembers history per branch PC
    pht_gshare = [1] * PHT_SIZE         # 2-bit counters for Gshare (PC XOR Global History)
    pht_gskew = [[1] * PHT_SIZE for _ in range(3)] # 3 independent banks for Majority Vote
    
    ghr = 0 # Global History Register: tracks outcomes of the last 10 branches

    # Read the trace file line by line and simulate each predictor
    with open(file_path, "r") as f:
        for line in f:
            parts = line.split()
            if len(parts) < 2: continue
            
            pc = int(parts[0])               # Program Counter (address of the branch)
            actual = 1 if parts[1] == 'T' else 0
            # Map PC to table index; shift right by 2 to ignore byte offset (alignment)
            pc_idx = (pc >> 2) % PHT_SIZE 

            # --- 1. Static Predictors ---
            stats['Always-T']['correct'] += (actual == 1)
            stats['Always-N']['correct'] += (actual == 0)

            # --- 2. 1-bit PHT (Bimodal) ---
            # Predicts whatever happened last time at this PC
            if pht_1bit[pc_idx] == actual: stats['1-bit']['correct'] += 1
            pht_1bit[pc_idx] = actual

            # --- 3. Global 2-bit Predictor ---
            # Uses only the Global History Register to index into the PHT
            g_idx = ghr & HIST_MASK
            pred_g = 1 if pht_global[g_idx] >= 2 else 0 # Predict Taken if counter is 2 or 3
            if pred_g == actual: stats['Global-2bit']['correct'] += 1
            # Update 2-bit saturating counter (0-3)
            pht_global[g_idx] = min(3, pht_global[g_idx] + 1) if actual else max(0, pht_global[g_idx] - 1)

            # --- 4. Local 2-bit Predictor ---
            # Uses the PC to find a specific branch's history, then uses that history to index the PHT
            l_hist = lht[pc_idx] & HIST_MASK
            pred_l = 1 if pht_local[l_hist] >= 2 else 0
            if pred_l == actual: stats['Local-2bit']['correct'] += 1
            # Update the 2-bit counter and shift the new outcome into the Local History Table
            pht_local[l_hist] = min(3, pht_local[l_hist] + 1) if actual else max(0, pht_local[l_hist] - 1)
            lht[pc_idx] = ((l_hist << 1) | actual) & HIST_MASK

            # --- 5. Gshare Predictor ---
            # XORs the PC and Global History to reduce aliasing (collisions in the table)
            gs_idx = (pc_idx ^ ghr) & HIST_MASK
            pred_gs = 1 if pht_gshare[gs_idx] >= 2 else 0
            if pred_gs == actual: stats['Gshare-2bit']['correct'] += 1
            pht_gshare[gs_idx] = min(3, pht_gshare[gs_idx] + 1) if actual else max(0, pht_gshare[gs_idx] - 1)

            # --- 6. Gskewed Predictor (Majority Vote) ---
            # Uses three different hash functions to index three separate banks
            h0 = (pc_idx ^ ghr) & HIST_MASK
            h1 = (pc_idx ^ (ghr << 2)) & HIST_MASK
            h2 = ((pc_idx >> 2) ^ ghr) & HIST_MASK
            hashes = [h0, h1, h2]
            
            # Get predictions from all 3 banks; if 2 or more say "Taken", predict "Taken"
            votes = [1 if pht_gskew[i][hashes[i]] >= 2 else 0 for i in range(3)]
            pred_skew = 1 if sum(votes) >= 2 else 0
            if pred_skew == actual: stats['Gskewed-2bit']['correct'] += 1
            # Update all three banks based on the actual outcome
            for i in range(3):
                if actual: pht_gskew[i][hashes[i]] = min(3, pht_gskew[i][hashes[i]] + 1)
                else: pht_gskew[i][hashes[i]] = max(0, pht_gskew[i][hashes[i]] - 1)

            # --- Final Updates ---
            # Shift the actual outcome into the Global History Register for the next branch
            ghr = ((ghr << 1) | actual) & HIST_MASK
            for k in stats: stats[k]['total'] += 1
            
    return stats

# --- Execution Loop ---
for f_path in trace_files:
    print(f"\nProcessing: {f_path.split('/')[-1]}...")
    results = run_simulation(f_path)
    if results:
        print(f"{'Predictor Type':<20} | {'Accuracy':<10}")
        print("-" * 35)
        for name, data in results.items():
            acc = (data['correct'] / data['total']) * 100
            print(f"{name:<20} | {acc:>8.2f}%")
    else:
        print(f"Error: Could not find {f_path}")
