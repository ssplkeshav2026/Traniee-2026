using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question10
    {
        public question10()
        {
            int n = 5;
            for (int i = n; i >= 1; i--)
            {
                for (int j = i; j < n ; j++)
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
