using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Smith_Jeffrey_CC4Q3
{
    public class AsyncCPUExample
    {
        public async Task FindPrimesAsync(int max)
        {
            Console.WriteLine("Starting prime number calculation...");
            var primes = await Task.Run(() => FindPrimes(max));
            // Print primes
            Console.WriteLine($"Found {primes.Count} prime numbers up to {max}.");
        }
        private List<int> FindPrimes(int max)
            {
            var primes = new List<int>();
            for (int i = 2; i <= max; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        private bool IsPrime(int number)
        {
            // Is number prime?
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }

    internal class Program
    {
        public static async Task Main(string[] args)
        {
            // Create instance of AsyncCPUExample
            var example = new AsyncCPUExample();
            await example.FindPrimesAsync(1000);

        }

    }
}
