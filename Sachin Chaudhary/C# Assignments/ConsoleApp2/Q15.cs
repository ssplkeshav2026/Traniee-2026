using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Q15
    {
        public Q15()
        {
            int rows = 5;
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 0; j < i; j++)
                {

                    Console.Write((char)(65 + j));
                }
                Console.WriteLine();
            }
        }
    }
}
