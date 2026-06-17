using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace ConsoleApp2
{
    internal class Q22
    {
        public Q22()
        {
            int n = 4; 

           
            for (int i = 1; i <= n; i++)
            {
               
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }

              
                Console.Write("*");

              
                if (i > 1)
                {
                    for (int j = 1; j <= 2 * (i - 1) - 1; j++)
                    {
                        Console.Write(" ");
                    }
                    
                    Console.Write("*");
                }
                Console.WriteLine();
            }

           
            for (int i = n - 1; i >= 1; i--)
            {
         
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }

               
                Console.Write("*");

              
                if (i > 1)
                {
                    for (int j = 1; j <= 2 * (i - 1) - 1; j++)
                    {
                        Console.Write(" ");
                    }
                 
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
