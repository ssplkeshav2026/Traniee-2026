using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question15
    {
        public question15()
        {
            Console.Write("Enter no. of rows: ");
            int rows = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write((char)('A' + j));
                }
                Console.WriteLine();
            }
        }
    }
    
}
