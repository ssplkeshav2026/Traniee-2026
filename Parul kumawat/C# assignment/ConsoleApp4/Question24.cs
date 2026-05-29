using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question24
    {
        public Question24()
        {
            int n = Convert.ToInt32(Console.ReadLine());
               for(int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }
                int value = 1;
                for (int k = 1; k <= i; k++)
                {
                    Console.Write(value+" ");
                    value = value * (i - k) / k; 

                }
                Console.WriteLine();
            }


        }
    }
}
