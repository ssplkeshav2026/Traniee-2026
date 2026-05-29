using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question8
    {
        public question8()
        {
            Console.Write("Enter no.of rows : ");
            int rows = Convert.ToInt32(Console.ReadLine());

            for (int i = rows; i >= 1; --i)
            {
                for (int j = 1; j <= i; ++j)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
    
}
