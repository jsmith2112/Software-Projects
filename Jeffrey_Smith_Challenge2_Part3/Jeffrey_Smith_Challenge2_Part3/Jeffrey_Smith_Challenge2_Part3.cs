using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeffrey_Smith_Challenge2_Part3
{
    // Define the Customer class with properties CustomerId and Name
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
    }
    // Define the Order class with properties OrderId, CustomerId, and Amount
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }

    internal class Jeffrey_Smith_Challenge2_Part3
    {
        static void Main(string[] args)
        {
            // Create sample data for customers and orders
            var customers = new List<Customer>
            {
                new Customer { CustomerId = 1, Name = "John" },
                new Customer { CustomerId = 2, Name = "Sara" },
                new Customer { CustomerId = 3, Name = "Alice" }
            };

            var orders = new List<Order>
            {
                new Order { OrderId = 101, CustomerId = 1, Amount = 250 },
                new Order { OrderId = 102, CustomerId = 2, Amount = 450 },
                new Order { OrderId = 103, CustomerId = 1, Amount = 300 }
            };

            // Perform an inner join between customers and orders based on CustomerId using LINQ
            var result = customers
                .Join(orders, c => c.CustomerId, o => o.CustomerId, (c, o) => new
                {
                    c.Name,
                    o.OrderId,
                    o.Amount
                })
                // had to add OrderBy to match expected output
                .OrderBy(c => c.OrderId)
                .ToList();

            // Display the results
            foreach (var item in result)
            {
                Console.WriteLine($"Customer: {item.Name}, OrderId: {item.OrderId}, Amount: {item.Amount:C}");
            }


        }
    }
}
