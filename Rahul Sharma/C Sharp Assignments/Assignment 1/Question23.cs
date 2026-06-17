using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System;

namespace Assignment1
{
    internal class Question23
    {
        public Question23()
        {
            Console.Write("Enter number of rows: ");
            int n = int.Parse(Console.ReadLine());

           
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