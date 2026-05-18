using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SolidAsync
{
    public class Question8
    {
        static async Task Main(string[] args)
        {
            await MakeRequest("https://jsonplaceholder.typicode.com/posts");
        }

        static async Task MakeRequest(string url)
        {
            var client = new HttpClient();

            try
            {
                string result = await client.GetStringAsync(url);
                Console.WriteLine("Data downloaded successfully!");
                Console.WriteLine(result);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"General error: {e.Message}");
            }
            finally
            {
                Console.WriteLine("API call attempt finished.");
            }
        }
    }
}