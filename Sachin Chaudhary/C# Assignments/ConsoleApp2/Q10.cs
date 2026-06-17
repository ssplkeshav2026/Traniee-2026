using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Q10
    {
        public Q10()
        {
            for (int i = 5; i >= 1; i--)
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
        }
    }
}
