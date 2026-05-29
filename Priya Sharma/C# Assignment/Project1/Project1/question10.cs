using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question10
    {
        public question10()
        {
            Console.Write("Enter no.of rows : ");
            int rows = Convert.ToInt32(Console.ReadLine());

            for (int i = rows; i >= 1; i--)
            {
                for (int j = 0; j < rows - i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 0; k < (2 * i - 1); k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}
