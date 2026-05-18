using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SolidAsync
{
    public class Question7
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var urls = new List<string>
            {
                "https://microsoft.com",
                "https://google.com",
                "https://github.com"
            };

            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);

            var stopwatch = Stopwatch.StartNew();

            Console.WriteLine("Starting concurrent downloads...");

            var tasks = new List<Task<byte[]>>();

            foreach (var url in urls)
            {
                tasks.Add(DownloadAsync(client, url));
            }

            var results = await Task.WhenAll(tasks);

            stopwatch.Stop();

            Console.WriteLine($"Downloaded {results.Length} files:");

            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine($"{urls[i]} -> {results[i].Length} bytes");
            }

            Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds} ms");
        }

        static async Task<byte[]> DownloadAsync(HttpClient client, string url)
        {
            try
            {
                return await client.GetByteArrayAsync(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed: {url} -> {ex.Message}");
                return Array.Empty<byte>();
            }
        }
    }
}