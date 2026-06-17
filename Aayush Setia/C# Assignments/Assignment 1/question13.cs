using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question13
    {
        public question13()
        {
            int n = 5;
            for (int i = 1; i <= n; i++)
            {
           
                for (int j = i; j < n; j++)
                {
                    Console.Write(" ");
                    
                }

                for (int k = 1; k <= i; k++)
                {
                    Console.Write(k);
                }
                for(int j = i - 1; j >= 1; j--)
                {
                    Console.Write(j);
                }

                Console.WriteLine();
            }
        }
    }
}
