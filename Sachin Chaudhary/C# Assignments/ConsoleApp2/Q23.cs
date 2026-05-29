using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Q23
    {
        public Q23()
        {
            int n = 5;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {

                    Console.Write("*");
                }
                for (int j = 1; j <= 2 * (n - i); j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();


            }



            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {

                    Console.Write("*");
                }
                for (int j = 1; j <= 2 * (n - i); j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();


            }

        }
    }
}
    

       
   
