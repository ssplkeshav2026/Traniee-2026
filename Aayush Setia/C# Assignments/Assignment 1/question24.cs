using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question24
    {
        public question24()
        {
            int n = 6;
            for (int i = 1; i < n; i++)
                
            {  int num = 1 ;
                

                for (int k = 0; k < n-i; k++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(num +" ");
                    num = num * (i - j) / (j +1 );
                }

                Console.WriteLine();
            }
        }
    }
}
