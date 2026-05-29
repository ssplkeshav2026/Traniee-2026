using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Q14
    {
        public Q14()
        {
            int i, j, n, num = 1;

            Console.Write("Enter the number of rows: ");

            n = int.Parse(Console.ReadLine());


            for (i = 1; i <= n; i++)
            {

                for (j = 1; j <= i; j++)
                {

                    Console.Write(num + " ");

                    num++;
                }

                Console.WriteLine();
            }
        }
    }
}
