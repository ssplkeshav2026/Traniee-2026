using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question24
    {
        public Question24()
        {

            int rows = 5; 

            for (int i = 0; i < rows; i++)
            {
                int value = 1;

            
                Console.Write(new string(' ', (rows - i) * 2));

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(value + "   ");

                    value = value * (i - j) / (j + 1);
                }
                Console.WriteLine();
            }

        }
    }
}