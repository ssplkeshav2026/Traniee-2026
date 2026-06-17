using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question22
    {
        public Question22() {
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }
               if(i == 1)
                {
                    Console.Write("* ");
                }
                else
                {
                    Console.Write("*");

                    for (int k = 1; k <= 2 * i - 3; k++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("* ");
                }
                
                Console.WriteLine();
            }


            for (int i = n - 1; i >= 1; i--)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }
                if (i == 1)
                {
                    Console.Write("* ");
                }
                else
                {
                    Console.Write("*");

                    for (int k = 1; k <= 2 * i - 3; k++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("* ");
                }

                Console.WriteLine();
            }




        }
    }
}
