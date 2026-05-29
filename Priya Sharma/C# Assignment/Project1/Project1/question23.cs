using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question23
    {
        public question23()
        {
            Console.Write("Enter no.of rows : ");
            int rows = Convert.ToInt32(Console.ReadLine());

                int k = 2 * rows - 1;
                int temp = 0;

                for (int i = 1; i <= 2 * rows - 1; i++)
                {

                    if (i <= rows)
                    {
                        k = k - 2;
                        temp++;
                    }

                    else
                    {
                        k = k + 2;
                        temp--;
                    }

                    for (int j = 1; j <= temp; j++)
                    {
                        Console.Write("*");
                    }

                    for (int j = 1; j <= k; j++)
                    {
                        Console.Write(" ");
                    }

                    for (int j = 1; j <= temp; j++)
                    {
                        if (j != rows)
                        {
                            Console.Write("*");
                        }
                    }

                    Console.WriteLine();
                }
            
        }

    }
    
}
