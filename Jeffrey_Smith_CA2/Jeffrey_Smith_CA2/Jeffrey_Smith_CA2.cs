using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Jeffrey_Smith_CA2
{
    internal class Jeffrey_Smith_CA2
    {
        static async Task Main()
        {
            // TODO 1: Define a list of integers to process
            // Hint: Use List<int> and fill numbers 1 to 10
            List<int> numbers = new List<int> { 1,2,3,4,5,6,7,8,9,10 };

            // TODO 2: Create a CancellationTokenSource to allow cancellation
            CancellationTokenSource cts = new CancellationTokenSource();

            // TODO 3: Retrieve the CancellationToken from the source
            CancellationToken token = cts.Token;

            // TODO 4: Start a background task to listen for key press
            Task.Run(() =>
            {

                // TODO 4a: Print a message to inform user
                Console.WriteLine("Press any key to cancel processing...");

                // TODO 4b: Wait for a key press
                Console.ReadKey();

                // TODO 4c: Trigger cancellation using the CancellationTokenSource
                cts.Cancel();
            });

            // TODO 5: Wrap the parallel processing in a try-catch block to handle cancellation
            try
            {
                // TODO 5a: Call the method that processes numbers asynchronously
                await ProcessNumbersAsync(numbers, token);
            }
            catch (OperationCanceledException)
            {
                // TODO 5b: Print a message when operation is cancelled
                Console.WriteLine("Operation cancelled.");
            }
        }
        // Define an asynchronous method to process numbers in parallel
        static async Task ProcessNumbersAsync(List<int> numbers, CancellationToken token)
        {
            // TODO 6: Run parallel processing asynchronously using Task.Run
            await Task.Run(() =>
            {
                // TODO 7: Use Parallel.ForEach to iterate numbers in parallel
                Parallel.ForEach(numbers, new ParallelOptions { CancellationToken = token }, number =>
                {
                    // TODO 8: Print message saying number is being processed
                    Console.WriteLine($"Processing number: {number}");

                    // TODO 9: Simulate work using Thread.Sleep
                    Thread.Sleep(1000); // Simulate work by sleeping for 1 second

                    // TODO 10: Check if cancellation was requested
                    if (token.IsCancellationRequested)
                    {
                        // TODO 10a: Print a message that operation was cancelled before processing this number
                        Console.WriteLine("Operation cancelled before processing number: " + number);

                        // TODO 10b: Exit this iteration
                        return;
                    }

                    // TODO 11: Compute and print the square of the number
                    int square = number * number;
                    Console.WriteLine($"Square of {number} is {square}");
                });
            });
        }

    }
}
