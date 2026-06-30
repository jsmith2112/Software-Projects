using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Jeffrey_Smith_Challenge2_Part2
{
    // Define the Product class with Category and Price properties
    public class Product
    {
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    internal class Jeffrey_Smith_Challenge2_Part2
    {
        static void Main(string[] args)
        {
            // Sample list of products
            var products = new List<Product>
            {
            new Product { Category = "Electronics", Price = 199.99M },
            new Product { Category = "Electronics", Price = 50.00M },
            new Product { Category = "Clothing", Price = 29.99M },
            new Product { Category = "Clothing", Price = 79.99M },
            new Product { Category = "Electronics", Price = 120.00M }
            };

            // Group products by Category and calculate total Price for each category using LINQ
            var result = products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    TotalPrice = g.Sum(p => p.Price)
                })
                .ToList();

            // Output the results
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Category}: {item.TotalPrice:C}");
            }


        }
    }
}
