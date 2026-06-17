using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question12
    {
        public question12()
        {
            Console.Write("Enter side : ");
            int side = Convert.ToInt32(Console.ReadLine());


            for (int i = 1; i <= side; i++)
            {
                for (int j = 1; j <= side; j++)
                {
                    if (i == 1 || i == side || j == 1 || j == side)
                        Console.Write("* ");
                    else
                        Console.Write("  ");
                }

                Console.WriteLine();   
                Console.WriteLine();  
            }
        }
        
    }
}
