using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question19
    {
        public question19()
        {
         
                int[] a = new int[10];
                int sum = 0;
                int max, min;

                for (int i = 0; i < 10; i++)
                {
                    Console.Write("Enter number: ");
                    a[i] = Convert.ToInt32(Console.ReadLine());
                    sum = sum + a[i];
                }

                max = a[0];
                min = a[0];

                for (int i = 1; i < 10; i++)
                {
                    if (a[i] > max)
                        max = a[i];

                    if (a[i] < min)
                        min = a[i];
                }

                Console.WriteLine("Sum = " + sum);
                Console.WriteLine("Average = " + (sum / 10.0));
                Console.WriteLine("Max = " + max);
                Console.WriteLine("Min = " + min);

                Console.WriteLine("Reverse Order:");

                for (int i = 9; i >= 0; i--)
                {
                    Console.Write(a[i] + " ");
                }
            
        }
    }
}