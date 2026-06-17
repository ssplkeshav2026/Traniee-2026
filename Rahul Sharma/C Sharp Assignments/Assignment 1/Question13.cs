using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//13.Number Pyramid
//     1
//    121
//   12321
//  1234321
// 123454321

using System;

namespace Assignment1
{
    internal class Question13
    {
        public Question13()
        {
            Console.Write("Enter number of rows: ");
            int rows = int.Parse(Console.ReadLine());

            for (int i = 1; i <= rows; i++)
            {
              
                for (int j = 1; j <= rows - i; j++)
                {
                    Console.Write(" ");
                }

              
                for (int k = 1; k <= i; k++)
                {
                    Console.Write(k);
                }

             
                for (int l = i - 1; l >= 1; l--)
                {
                    Console.Write(l);
                }

                Console.WriteLine();
            }
        }
    }
}