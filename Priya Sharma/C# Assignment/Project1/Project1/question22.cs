using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question22
    {
        public question22()
        {
            Console.Write("Enter no. of Rows : ");
            int row = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= row; i++)
            {
                
                for (int j = i; j < row; j++)
                    Console.Write(" ");

                for (int k = 1; k <= (2 * i - 1); k++)
                {
                    if (k == 1 || k == (2 * i - 1))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }

            // Bottom of diamond.....

            for (int i = row - 1; i >= 1; i--)
            {
                for (int j = row; j > i; j--)
                    Console.Write(" ");

                for (int k = 1; k <= (2 * i - 1); k++)
                {
                    if (k == 1 || k == (2 * i - 1))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}
