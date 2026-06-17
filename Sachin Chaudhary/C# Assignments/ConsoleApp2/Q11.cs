using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Q11
    {

        public Q11()
        {

          
            for (int i = 1; i <= 5; i++)
            {

                for (int j = 1; j <= 5 - i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 1; k <= (2 * i - 1); k++)
                {
                    Console.Write("*");
                }


                Console.WriteLine();
            }
            for (int i = 5-2; i >= 0; i--)
            {

                for (int j = 1; j <= 5 - i-1; j++)
                {
                    Console.Write(" ");
                }


                for (int k = 0; k < 2 * i + 1; k++)
                {
                    Console.Write("*");
                }


                Console.WriteLine();
            }

        }

    }
}
