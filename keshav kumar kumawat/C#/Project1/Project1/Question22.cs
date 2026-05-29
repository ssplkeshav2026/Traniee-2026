using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question22
    {
        public Question22()
        {

            int n = 4;

            // outer loop
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)

                    Console.Write(" ");
                    Console.Write("*");

                if (i > 1)
                {
                    for (int j = 1; j <= 2 * (i - 1) - 1; j++)
                        Console.Write(" ");
                        Console.Write("*");
                }
                Console.WriteLine();
            }

            for (int i = n - 1; i >= 1; i--)
            {
                for (int j = 1; j <= n - i; j++) 

                   Console.Write(" ");
                   Console.Write("*");

                if (i > 1)
                {
                    for (int j = 1; j <= 2 * (i - 1) - 1; j++) 
                        
                        Console.Write(" ");
                        Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}