using System;
using System.Threading;
using System.Threading.Tasks;

class Question1
{
    // Simulates a long-running task that checks for cancellation
    static async Task RunWorkAsync(CancellationToken token)
    {
        Console.WriteLine("Work started...\n");

        for (int i = 1; i <= 10; i++)
        {
            token.ThrowIfCancellationRequested(); // Check if cancellation was requested

            Console.WriteLine($"Step {i}/10 in progress...");
            await Task.Delay(1000, token); // Simulate async work
        }

        Console.WriteLine("\nWork completed successfully.");
    }

    static async Task Main(string[] args)
    {
        // Create a CancellationTokenSource
        using (CancellationTokenSource cts = new CancellationTokenSource())
        {
            Console.WriteLine("Press ENTER at any time to cancel the operation.\n");

            // Start the long-running task with the token:
            // Define workTask of type Task, call RunWorkAsync and pass cts.Token
            Task workTask = RunWorkAsync(cts.Token);
            Console.WriteLine("Task started. Waiting for completion or cancellation...\n");

            // Wait for either the Enter key or the work to complete:
            // define cancelTask of type Task
            // initialize it with Task.Run and pass ()=>Console.ReadLine() to it.
            Task cancelTask = Task.Run(() => Console.ReadLine());
            Console.WriteLine("Press ENTER to cancel the operation...\n");


            // Define finishedTask of type Task
            // initialize it with await Task.WhenAny and pass workTask and cancelTask to it
            Task finishedTask = await Task.WhenAny(workTask, cancelTask);
            Console.WriteLine("One of the tasks has completed.\n");
            Console.WriteLine("");

            // If Enter was pressed first, cancel the operation
            if (finishedTask == cancelTask)
            {
                // Call Cancel() method from cts
                cts.Cancel();
                Console.WriteLine("\nCancellation requested by user.");
            }

            // Await the work task to observe any exceptions
            try
            {
                // Await workTask
                await workTask;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nOperation was cancelled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nUnexpected error: {ex.Message}");
            }

            Console.WriteLine("\nProgram has ended. Press any key to exit.");
            Console.ReadKey();
        }
    }
}

