using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question14
    {
        public question14()
        {
            Console.Write("Enter the no. of rows: ");
            int rows = Convert.ToInt32(Console.ReadLine());
            int value = 1;

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(value + " ");
                    value++;
                }
                Console.WriteLine();
            }
        }
    }
}
