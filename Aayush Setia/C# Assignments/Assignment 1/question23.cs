using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question23
    {
        public question23()
        {

            {
                int n = 5;

                for (int i = 1; i <= n; i++)

                {

                    for (int j = 1; j <= i; j++)

                        Console.Write("*");

                    for (int k = 1; k <= 2 * (n - i); k++)

                        Console.Write(" ");

                    for (int l = 1; l <= i; l++)

                        Console.Write("*");

                    Console.WriteLine();

                }

                for (int i = n; i >= 1; i--)

                {

                    for (int j = 1; j <= i; j++)

                        Console.Write("*");

                    for (int k = 1; k <= 2 * (n - i); k++)

                        Console.Write(" ");

                    for (int l = 1; l <= i; l++)

                        Console.Write("*");

                    Console.WriteLine();
                }
            }
        }

    }
}

