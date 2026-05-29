using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question7
    {
        public Question7()
        {
            int n = 5;
            for (int i = 1; i <= n; i++)
            {
                for (int s = 1; s <= i; s++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
    }
}
