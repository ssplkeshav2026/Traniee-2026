using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1
//2 3
//3 4 5
//6 7 8 9
//10 11 12 13


using System;

namespace Assignment1
{
    internal class Question14
    {
        public Question14()
        {
            Console.Write("Enter number of rows: ");
            int rows = int.Parse(Console.ReadLine());

            int num = 1;

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(num + " ");
                    num++;   
                }
                Console.WriteLine();
            }
        }
    }
}