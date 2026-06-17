using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question22
    {
        public question22()
        {
            int n = 5;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < n - i; j++)
                    Console.Write(" ");

                Console.Write("*");

                if (i > 1)
                    for (int j = 0; j < 2 * i - 3; j++)
                        Console.Write(" ");

                if (i > 1)
                    Console.Write("*");

                Console.WriteLine();


                //for (int j = i; j < n; j++)
                //{
                //    Console.Write(" ");
                //}

                //for (int k = 1; k <= (2 * i - 1); k++)
                //{
                //    Console.Write("*");
                //}

                //Console.WriteLine();

            }

            for (int i = n; i >= 1; i--)
            {
                for (int j = i; j < n; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                if (i > 1)
                    for (int j = 0; j < 2 * i - 3; j++)
                        Console.Write(" ");

                if (i > 1)
                    Console.Write("*");
                Console.WriteLine();
            }

        }
    }
}
