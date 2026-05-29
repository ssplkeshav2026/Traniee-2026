using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolidAsync
{
    public class Api
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("1. Synchronous Download");
            Console.WriteLine("2.Asynchronous Download");
            Console.WriteLine("Choose option:");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                SyncDownload();
            }
            else
            {
                await AsyncDownload();
            }

        }

        static void SyncDownload()
        {
            Console.WriteLine("Starting Synchronous Download...");

            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Downloading... {i * 20}%");
            }

            HttpClient client = new HttpClient();
            string data = client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/1").Result;

            Console.WriteLine("Download Complete!");
            Console.WriteLine("Data length: " + data.Length);
        }

        static async Task AsyncDownload()
        {
            Console.WriteLine("Starting Asynchronous Download...");

            for (int i = 1; i <= 5; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine($"Downloading... {i * 20}%");
            }

            HttpClient client = new HttpClient();
            string data = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/1");

            Console.WriteLine("Download Complete!");
            Console.WriteLine("Data length: " + data.Length);
        }
    }
}
