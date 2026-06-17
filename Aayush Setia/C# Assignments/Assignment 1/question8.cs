using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question8
    {
        public question8()
        {
            for (int i = 5; i > 1; i--)
            {
                for (int j = 1; j < i; j++)
                {
                     Console.Write("*");
                }
                Console.WriteLine();
               
            }
        }
    }
}
