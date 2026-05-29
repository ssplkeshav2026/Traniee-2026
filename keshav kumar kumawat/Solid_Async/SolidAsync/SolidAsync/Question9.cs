using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolidAsync
{
    public class Question9
    {
        static async Task Main(string[] args)
        {
            var cts = new CancellationTokenSource();

            Console.WriteLine("Press any key to stop the count");

            var task = CountForever(cts.Token);

            Console.ReadKey();
            cts.Cancel();

            try 
            { 
                await task; 
            }
            catch (OperationCanceledException) 
            {
                Console.WriteLine("\nStopped!");
            }
        }
        static async Task CountForever(CancellationToken token)
        {
            int i = 0;
            while (true)
            {
                token.ThrowIfCancellationRequested();

                Console.Write($"\rCounting: {i++}");
                await Task.Delay(500, token);
            }
        }
    }
}
