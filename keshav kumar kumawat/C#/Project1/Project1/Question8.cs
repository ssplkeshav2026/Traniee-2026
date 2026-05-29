using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question8
    {
        public Question8()
        {
            int n = 5;
            for (int i = 1; i <= n; i++)
            {
                for (int s = 1; s <= (n - i + 1); s++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
