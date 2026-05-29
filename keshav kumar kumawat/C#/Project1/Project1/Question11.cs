using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question11
    {
        public Question11()
        {
            int n = 4;
            // Outer loop
            for (int i = 1; i <= n; i++)
            {
                // Space
                for (int j = 1; j <= (n - i); j++)
                {
                    Console.Write(" ");
                }
                //star
                for (int j = 1; j <= (2 * i - 1); j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            //Reverse loop
            for (int i = n; i >= 1; i--)
            {
                // Space
                for (int j = 1; j <= (n - i); j++)
                {
                    Console.Write(" ");
                }
                //star
                for (int j = 1; j <= (2 * i - 1); j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
