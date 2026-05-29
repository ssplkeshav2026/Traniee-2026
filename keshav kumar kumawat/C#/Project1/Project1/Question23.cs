using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question23
    {
        public Question23()
        {
            int n = 5;
            // outer loop
            for(int i = 1; i <= n; i++)
            {
                // star
                for(int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                //Spaces
                for(int j = 1; j <= (2 * (n - i)); j++)
                {
                    Console.Write(" ");
                }
                // star
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            for (int i = n; i >= 1; i--)
            {
                // star
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                //Spaces
                for (int j = 1; j <= (2 * (n - i)); j++)
                {
                    Console.Write(" ");
                }
                // star
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
