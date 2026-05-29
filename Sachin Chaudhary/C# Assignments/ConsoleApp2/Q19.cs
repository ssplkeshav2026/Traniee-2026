using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleApp2
{
    internal class Q19
    {
        public Q19()
        {

            int[] arr = new int[10];
            Console.WriteLine("enter 10 values");
            for(int i = 0; i <10; i++)
            {
              arr[i] = Convert.ToInt32(Console.ReadLine());
               
            }
            int sum = 0;
          
            for (int i = 0; i <10; i++) {
                sum = sum + arr[i];
            
            }
            Console.WriteLine($"sum is :{sum}");

          
                int AVG = sum / 10;

            
            Console.WriteLine($"AVRAGE is :{AVG}");

            int MAX=0;
            for(int i = 0; i < 10; i++)
            {
                if (MAX < arr[i])
                MAX= arr[i];

            }
            Console.Write($"MAx val is:{MAX}");

            int MIN = MAX;
            for (int i = 0; i < 10; i++)
            {
                if (MIN > arr[i])
                    MIN= arr[i];

            }
            Console.Write($"MIN val is:{MIN}");

            for(int i = 9; i >= 0; i--)
            {
         Console.Write($" {arr[i]}");


            }


        }
    }
}
