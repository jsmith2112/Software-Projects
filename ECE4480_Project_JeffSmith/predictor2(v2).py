import os
import multiprocessing
import time

# Full list of 10 trace files representing different program workloads
trace_files = [
    "/home/class/comparch/lab3/traces/branch-bzip2.tr",
    "/home/class/comparch/lab3/traces/branch-gzip.tr",
    "/home/class/comparch/lab3/traces/branch-twolf.tr",
    "/home/class/comparch/lab3/traces/branch-apsi.tr",
    "/home/class/comparch/lab3/traces/branch-crafty.tr",
    "/home/class/comparch/lab3/traces/branch-mcf.tr",
    "/home/class/comparch/lab3/traces/branch-vortex.tr",
    "/home/class/comparch/lab3/traces/branch-art.tr",
    "/home/class/comparch/lab3/traces/branch-gcc.tr",
    "/home/class/comparch/lab3/traces/branch-mesa.tr"
]

def is_power_of_two(n):
    """Checks if the PHT size is valid for hardware indexing."""
    return n > 0 and (n & (n - 1)) == 0

def run_simulation(file_path, PHT_SIZE, HIST_BITS):
    """
    Simulates various branch predictors on a single trace file.
    """
    if not os.path.exists(file_path):
        return None

    # Constants and Data Structures
    HIST_MASK = (1 << HIST_BITS) - 1     # Mask to keep history bits within range
    pht_1bit = [0] * PHT_SIZE           # 1-bit Pattern History Table (T/N)
    pht_global = [1] * PHT_SIZE         # Global 2-bit counters (Weakly Not Taken)
    pht_local = [1] * PHT_SIZE          # Local 2-bit counters
    lht = [0] * PHT_SIZE                # Local History Table (indexed by PC)
    pht_gshare = [1] * PHT_SIZE         # Gshare counters (XOR of PC and GHR)
    
    # Gskewed uses three different banks with different hash functions to reduce aliasing
    gsk0, gsk1, gsk2 = [1]*PHT_SIZE, [1]*PHT_SIZE, [1]*PHT_SIZE 
    
    # Counter variables for tracking correct predictions and totals
    at_c = an_c = b1_c = g2_c = l2_c = gs_c = gk_c = total = 0
    ghr = 0 # Global History Register

    with open(file_path, "r") as f:
        for line in f:
            parts = line.split()
            if not parts: continue
            
            pc = int(parts[0])               # Program Counter (address of branch)
            actual = 1 if parts[1] == 'T' else 0 # Actual outcome (Taken or Not Taken)
            pc_idx = (pc >> 2) % PHT_SIZE    # PC-based index (shifted to ignore offset)
            total += 1

            # 1. Static Predictors (Baselines)
            if actual == 1: at_c += 1 # Always Taken
            else: an_c += 1           # Always Not Taken

            # 2. 1-Bit Predictor (Remembers last outcome at this PC)
            if pht_1bit[pc_idx] == actual: b1_c += 1
            pht_1bit[pc_idx] = actual

            # 3. Global 2-Bit Predictor (Uses history of all branches)
            g_idx = (ghr & HIST_MASK) % PHT_SIZE
            val_g = pht_global[g_idx]
            if (1 if val_g >= 2 else 0) == actual: g2_c += 1
            # Saturating Counter Logic: 0, 1 = NT | 2, 3 = T
            pht_global[g_idx] = min(3, val_g + 1) if actual else max(0, val_g - 1)

            # 4. Local 2-Bit Predictor (Uses history of this specific branch)
            l_hist = lht[pc_idx]
            l_idx = (l_hist & HIST_MASK) % PHT_SIZE
            val_l = pht_local[l_idx]
            if (1 if val_l >= 2 else 0) == actual: l2_c += 1
            pht_local[l_idx] = min(3, val_l + 1) if actual else max(0, val_l - 1)
            # Update Local History: Shift in the new outcome
            lht[pc_idx] = ((l_hist << 1) | actual) & HIST_MASK

            # 5. Gshare Predictor (XORs PC and Global History to reduce collisions)
            gs_idx = (pc_idx ^ (ghr & HIST_MASK)) % PHT_SIZE
            val_gs = pht_gshare[gs_idx]
            if (1 if val_gs >= 2 else 0) == actual: gs_c += 1
            pht_gshare[gs_idx] = min(3, val_gs + 1) if actual else max(0, val_gs - 1)

            # 6. Gskewed Predictor (Majority vote from 3 differently-hashed tables)
            h0 = (pc_idx ^ ghr) % PHT_SIZE
            h1 = (pc_idx ^ (ghr << 2)) % PHT_SIZE
            h2 = ((pc_idx >> 2) ^ ghr) % PHT_SIZE
            
            v0 = (1 if gsk0[h0] >= 2 else 0)
            v1 = (1 if gsk1[h1] >= 2 else 0)
            v2 = (1 if gsk2[h2] >= 2 else 0)
            
            # Majority vote logic
            if (v0 + v1 + v2 >= 2) == actual: gk_c += 1
            
            # Update the 3 banks
            gsk0[h0] = min(3, gsk0[h0]+1) if actual else max(0, gsk0[h0]-1)
            gsk1[h1] = min(3, gsk1[h1]+1) if actual else max(0, gsk1[h1]-1)
            gsk2[h2] = min(3, gsk2[h2]+1) if actual else max(0, gsk2[h2]-1)

            # Final step: Update Global History Register
            ghr = ((ghr << 1) | actual) & HIST_MASK
            
    # Return results formatted for the main table
    name = file_path.split('/')[-1].replace('branch-', '').replace('.tr', '')
    return name, {
        'Always-T': {'correct': at_c, 'total': total}, 'Always-N': {'correct': an_c, 'total': total},
        '1-bit': {'correct': b1_c, 'total': total}, 'Global-2bit': {'correct': g2_c, 'total': total},
        'Local-2bit': {'correct': l2_c, 'total': total}, 'Gshare-2bit': {'correct': gs_c, 'total': total},
        'Gskewed-2bit': {'correct': gk_c, 'total': total}
    }

def draw_bar(val, width=20):
    """Generates a text-based progress bar for the final summary."""
    filled = int((val / 100) * width)
    return "[" + "█" * filled + "░" * (width - filled) + "]"

def main():
    print("--- High-Performance Branch Prediction Multi-Core Simulator ---")
    
    # Input Configuration
    while True:
        try:
            print("\n[INITIAL CONFIGURATION]")
            PHT_SIZE = int(input("Enter the Pattern History Table (PHT) size (must be power of 2, e.g., 1024): "))
            if is_power_of_two(PHT_SIZE): break
            print("❌ Error: PHT size must be a power of 2.")
        except ValueError: print("❌ Invalid input.")

    try:
        HIST_BITS = int(input("Enter the number of Global/Local History Register bits: "))
    except ValueError: HIST_BITS = 10

    run_history = []
    predictors = ['Always-T', 'Always-N', '1-bit', 'Global-2bit', 'Local-2bit', 'Gshare-2bit', 'Gskewed-2bit']

    # Simulation Loop
    while True:
        print(f"\n{'='*115}\nSIMULATION START: Memory Allocation = {PHT_SIZE} entries | History Depth = {HIST_BITS} bits\n{'='*115}")
        
        start_time = time.time()
        completed = 0
        all_results = {}
        total_files = len(trace_files)

        # Multi-Core Processing: Process trace files in parallel
        with multiprocessing.Pool(processes=min(total_files, multiprocessing.cpu_count())) as pool:
            tasks = [(f, PHT_SIZE, HIST_BITS) for f in trace_files]
            for name, data in pool.starmap(run_simulation, tasks):
                completed += 1
                if data: all_results[name] = data
                print(f" Progress: [{completed}/{total_files}] traces finished...", end="\r")
        
        elapsed = time.time() - start_time
        print(f"\nAll traces completed in {elapsed:.2f} seconds.")

        # Display Results Table
        header = f"{'Trace File':<12} | " + " | ".join(f"{p:<11}" for p in predictors)
        print("\n" + "-" * len(header) + "\n" + header + "\n" + "-" * len(header))

        current_avg_dict = {p: 0 for p in predictors}
        for name in sorted(all_results.keys()):
            data = all_results[name]
            accs = []
            for p in predictors:
                acc = (data[p]['correct'] / data[p]['total']) * 100
                accs.append(f"{acc:>10.2f}%")
                current_avg_dict[p] += acc
            print(f"{name:<12} | " + " | ".join(accs))

        # Statistical Summary
        print("-" * len(header))
        for p in current_avg_dict: current_avg_dict[p] /= len(all_results)
        
        best_p = max(current_avg_dict, key=current_avg_dict.get)
        print(f"🏆 PERFORMANCE WINNER: {best_p} achieved the highest average accuracy at {current_avg_dict[best_p]:.2f}%.")

        # Trend Tracking (Compare against previous runs)
        overall_avg = sum(current_avg_dict.values()) / len(predictors)
        run_history.append({
            'config': f"{PHT_SIZE}/{HIST_BITS}", 
            'overall': overall_avg, 
            'per_pred': current_avg_dict, 
            'time': elapsed, 
            'winner': best_p
        })
        
        print(f"\n{' '*25} ARCHITECTURAL ACCURACY TREND")
        print("-" * 95)
        print(f"{'Run':<6} | {'Config (P/H)':<15} | {'Avg Accuracy':<15} | {'Time (s)':<10} | {'Visual Trend'}")
        print("-" * 95)
        max_h = max(r['overall'] for r in run_history)
        for i, r in enumerate(run_history):
            star = " ⭐ BEST CONFIG" if r['overall'] == max_h and len(run_history) > 1 else ""
            print(f"#{i+1:<5} | {r['config']:<15} | {r['overall']:>10.2f}%    | {r['time']:>8.2f}s  | {draw_bar(r['overall'])}{star}")
        print("-" * 95)

        # Optimization Feedback
        if len(run_history) > 1:
            prev = run_history[-2]['per_pred']
            curr = run_history[-1]['per_pred']
            diffs = {p: curr[p] - prev[p] for p in predictors}
            top_gainer = max(diffs, key=diffs.get)
            if diffs[top_gainer] > 0:
                print(f"🚀 OPTIMIZATION IMPACT: '{top_gainer}' saw the largest gain (+{diffs[top_gainer]:.2f}%).")

        # Recommendation for next run
        rec_p = PHT_SIZE * 2 if PHT_SIZE < 16384 else PHT_SIZE
        rec_h = 14 if HIST_BITS < 14 else HIST_BITS + 2
        print(f"\n[HARDWARE DESIGN RECOMMENDATION]\n 👉 Suggested PHT Size: {rec_p} | Suggested History: {rec_h}")

        choice = input("\nAction: [R]un suggested, [C]ustom, or [Q]uit: ").lower()
        if choice == 'r':
            PHT_SIZE, HIST_BITS = rec_p, rec_h
        elif choice == 'c':
            while True:
                try:
                    new_p = int(input("Enter New PHT Size (must be power of 2): "))
                    if is_power_of_two(new_p):
                        PHT_SIZE = new_p
                        break
                    print("❌ Error: Power of 2 required.")
                except: pass
            HIST_BITS = int(input("Enter New History Bits: "))
        else:
            print("Exiting simulator...")
            break

if __name__ == "__main__":
    main()
