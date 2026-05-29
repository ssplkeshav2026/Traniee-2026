using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question9
    {
        public question9()
        {
            Console.Write("Enter no. of rows: ");
            int rows = int.Parse(Console.ReadLine());

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= rows - i; j++) 
                {
                    Console.Write(" ");
                }

                for (int k = 1; k <= (2 * i - 1); k++) 
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
