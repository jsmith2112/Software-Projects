using System;
using System.Collections.Generic;
using System.Numerics;  
using System.Threading;
using System.Threading.Tasks;


namespace Jeffrey_Smith_CC6Q2
{
    internal class Question2
    {

        static void Main()
        {
            var numbers = new List<int> { 10000, 12000, 15000, 13000 };

            // Create CancellationTokenSource (cts)
            var cts = new CancellationTokenSource();


            // Task.Run to cancel after 2 seconds and print "User requested cancellation"
            // 2 seconds was too long for testing, changed to 200 milliseconds
            Task.Run(() =>
            {
                Thread.Sleep(200);
                cts.Cancel();
                Console.WriteLine("User requested cancellation");
            });

            try
            {
                // Parallel.ForEach with numbers
                // Use ParallelOptions { CancellationToken = cts.Token }
                // For each number:
                //    - Print "Calculating factorial of {number} on thread {Thread.CurrentThread.ManagedThreadId}"
                //    - Compute factorial using CalculateFactorial(number, cts.Token)
                //    - Print length of result
                Parallel.ForEach(numbers, new ParallelOptions { CancellationToken = cts.Token }, number =>
                {
                    Console.WriteLine($"Calculating factorial of {number} on thread {Thread.CurrentThread.ManagedThreadId}");
                    BigInteger factorial = CalculateFactorial(number, cts.Token);
                    Console.WriteLine($"Length of factorial of {number} is {factorial.ToString().Length}");
                });
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Factorial computation was cancelled.");
            }

            Console.WriteLine("Done.");
        }

        // Implement static BigInteger CalculateFactorial(int n, CancellationToken token)
        static BigInteger CalculateFactorial(int n, CancellationToken token)
        {
            BigInteger result = 1;
            for (int i = 2; i <= n; i++)
            {
                token.ThrowIfCancellationRequested();
                result *= i;
            }
            return result;
        }

    }

}
