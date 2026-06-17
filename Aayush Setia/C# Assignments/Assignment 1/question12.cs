using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question12
    {
        public question12()
        {
            int n = 5;
            for (int i = 1;i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == 1 || j == 1 || i == n || j == n)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
