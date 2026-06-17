using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question9
    {
        public question9()
        {
            int n = 5;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < n-i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 1; k <= (2*i-1); k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
         }

    }
}
