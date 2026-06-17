
////9.Pyramid Pattern
////   *
////  ***
//// *****
////*******


using System;

namespace Assignment1
{
    internal class Question9
    {
        public Question9()
        {
            Console.WriteLine("Enter number of rows ");
            int row = int.Parse(Console.ReadLine());

            for (int i = 0; i < row; i++)
            {
                
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write(" ");
                }

                
                for (int k = 0; k < 2 * i + 1; k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}