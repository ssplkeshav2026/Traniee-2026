using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//15.Alphabet Pattern
//A
//AB
//ABC
//ABCD
//ABCDE

using System;

namespace Assignment1
{
    internal class Question15
    {
        public Question15()
        {
            Console.Write("Enter number of rows: ");
            int rows = int.Parse(Console.ReadLine());

            for (int i = 1; i <= rows; i++)
            {
                char ch = 'A';  

                for (int j = 1; j <= i; j++)
                {
                    Console.Write(ch++);
                    
                }

                Console.WriteLine();
            }
        }
    }
}