using System;
using System.Linq;

namespace Project1
{
    public class Question19
    {
        public Question19()
        {
            int[] a = new int[10];
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
                sum = sum + a[i];
            }
            Console.WriteLine("Sum="+sum);

            float average = sum / 10;
            Console.WriteLine("Average="+average);

            Console.WriteLine("Maximum Number="+a.Max());
            Console.WriteLine("Minimum Number="+a.Min());

            // Reverse an array
            for(int i = 9; i >= 0; i--)
            {
                Console.Write(a[i]+" ");
            }
        }
    }
}