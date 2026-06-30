using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeffrey_Smith_Challenge2_Part5
{
    // Define a Transaction class with properties for TransactionId, Amount, and Date
    public class Transaction
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

    internal class Jeffrey_Smith_Challenge2_Part5
    {
        static void Main(string[] args)
        {
            // Create a list of transactions
            var transactions = new List<Transaction>
            {
                new Transaction { TransactionId = 1, Amount = 100, Date = DateTime.Now.AddDays(-5) },
                new Transaction { TransactionId = 2, Amount = 200, Date = DateTime.Now.AddDays(-10) },
                new Transaction { TransactionId = 3, Amount = 300, Date = DateTime.Now.AddDays(-40) },
                new Transaction { TransactionId = 4, Amount = 50, Date = DateTime.Now.AddDays(-20) }
            };

            // Calculate the total amount of transactions in the last 30 days using LINQ
            var last30Days = DateTime.Now.AddDays(-30);
            var result = transactions
                .Where(t => t.Date >= last30Days)
                .Sum(t => t.Amount);

            // Output the result
            Console.WriteLine($"Total amount of transactions in the last 30 days: {result:C}");

        }
    }
}
