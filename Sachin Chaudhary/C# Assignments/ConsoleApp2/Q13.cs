using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Q13
    {
        public Q13()
        {
            int rows = 5;

            for (int i = 1; i <= rows; i++)
            {

                for(int k = 1; k <=rows-i; k++)
                {
                    Console.Write(" ");

                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }


                for (int j = i - 1; j >= 1; j--)
                {
                    Console.Write(j);
                }

                Console.WriteLine();
            }
        }
    }
}
