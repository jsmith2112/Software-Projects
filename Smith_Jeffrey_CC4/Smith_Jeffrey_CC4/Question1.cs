using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Smith_Jeffrey_CC4
{
    public class User 
    {
        public string Name { get; set; }
        public int Age { get; set; }
    };
    public class AsyncExample
    {
        public async Task DownloadDataAsync()
        {
            Console.Write("Starting data download..");
            await Task.Delay(2000);
            Console.Write("Data download completed.");
        }

        public async Task<User> GetUserDetailsAsync(int userId)
        {
            Console.Write($"Fetching details for user {userId}...");
            await Task.Delay(1000);
            return new User { Name = "John Doe", Age = 30 };
        }

        public async Task ButtonClickHandlerAsync(object sender, EventArgs e)
        {
            Console.Write("Button clicked, starting async operation...");
            await Task.Delay(1000);
            Console.Write("Button click operation completed.");
        }
    }  

        internal class Question1
        {
       
        public static async Task Main()
        {
            // Create instance of AsyncExample
            AsyncExample example = new AsyncExample();

            await example.DownloadDataAsync();
            var user = await example.GetUserDetailsAsync(1);
            Console.WriteLine($"User Details: Name = {user.Name}, Age = {user.Age}");
            await example.ButtonClickHandlerAsync(null, EventArgs.Empty);
            await Task.Delay(2000);

        }

    }
}
