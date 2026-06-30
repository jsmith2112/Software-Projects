using System;
using System.IO;
using System.Threading.Tasks;


namespace Smith_Jeffrey_CC4_2
{
    public class AsyncIOExample
    {
        public async Task ReadFileAsync(string filePath)
        {
            Console.WriteLine("Starting to read file...");
            // Use StreamReader with await reader.ReadToEndAsync()
            // Print first 100 characters of sample.txt
            filePath = "../../../sample.txt";
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = await reader.ReadToEndAsync();
                Console.WriteLine("File read complete. First 100 characters:");
                Console.WriteLine(content.Substring(0, Math.Min(100, content.Length)));
            }
        }
    }
    internal class Question2
    {
        

        public static async Task Main(string[] args)
        {
            // Create instance of AsyncIOExample
            AsyncIOExample example = new AsyncIOExample();
            string filePath = "sample.txt";
            await example.ReadFileAsync(filePath);
        }

    }
}
