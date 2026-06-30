using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Jeffrey_Smith_CC6Q1
{
    internal class Question1
    {
        static void Main()
        {
            var items = new List<int>();
            for (int i = 0; i < 100; i++) items.Add(i);

            // Create CancellationTokenSource (cts)
            var cts = new CancellationTokenSource();
            var options = new ParallelOptions
            {
                CancellationToken = cts.Token,
            };

            // Cancel after 1 second
            Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("\n>>> Cancelling loop...");
                cts.Cancel();
            });

            try
            {
                // create parallel for each loop
                Parallel.ForEach(items, options, item =>
                {
                    // print processing item
                    Console.WriteLine($"Processing item {item}");
                    // Simulate work
                    Thread.Sleep(200);
                    // throw if cancellation requested
                    options.CancellationToken.ThrowIfCancellationRequested();
                });
            } // end of try block
            catch (OperationCanceledException)
            {
                Console.WriteLine(">>> Loop was cancelled!");
            }
            Console.WriteLine("Done.");
            
        }
    }


}
