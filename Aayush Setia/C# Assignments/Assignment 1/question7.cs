using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question7
    {
        public question7()
        {
            for (int i = 1; i <= 5; i++)
            {
                for(int j = 1; j <=i; j++)
                {
                    Console.Write("*");
                   
                } 
                Console.WriteLine();
            }
        }
    }
}
