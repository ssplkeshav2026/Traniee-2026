using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question15
    {
        public question15()
        {
            int n = 6;
            
            for (int i = 1; i < n; i++)
            {
                char ch = 'A';
                for (int j = i - 1; j >= 0; j--)
                {
                    Console.Write(ch);
                    ch++;
                }
                Console.WriteLine();
            }
        }
    }
}
