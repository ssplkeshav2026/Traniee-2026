using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question13
    {
        public Question13()
        {
            int n = 5;
            // Outer loop
            for (int i = 1; i <= n; i++)
            {
                // Space
                for (int j = 1; j <= (n - i); j++)
                {
                    Console.Write(" ");
                }
                // Increasing numbers
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }

                // Decreasing numbers  Reverse Concept  Mirror image
                for (int j = i - 1; j >= 1; j--)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }
    }
}


   

   
