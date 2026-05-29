using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question10
    {
        public Question10()
        {
            int n = 5;
            // Outer loop
            for (int i = n; i >= 1; i--)
            {
                //Space
                for (int j = 1; j <= (n - i); j++)
                {
                    Console.Write(" ");
                }
                // Star
                for (int s = 1; s <= (2 * i - 1); s++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
