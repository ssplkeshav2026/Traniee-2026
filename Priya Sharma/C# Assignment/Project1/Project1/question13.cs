using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question13
    {
        public question13()
        {
            Console.Write("Enter no. of Rows : ");
            int rows = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= rows; i++)
            {
                for (int k = 1; k <= rows - i; k++)
                {
                    Console.Write(" ");
                }

                for (int num = 1; num <= i; num++)
                {
                    Console.Write(num);
                }

                for (int j= i - 1; j >= 1; j--)
                {
                    Console.Write(j);
                }

                Console.WriteLine();
            }
        }
    }
}
