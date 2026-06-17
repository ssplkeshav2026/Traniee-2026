
//22.Hollow Diamond
//          *
//         *  *
//        *    *
//       *      *
//        *    *
//         *  *
//          *

using System;

namespace Assignment1
{
    internal class Question22
    {
        public Question22()
        {
            Console.WriteLine("Enter number of rows ");
            int row = int.Parse(Console.ReadLine());

            // 🔼 Upper Part
            for (int i = 1; i <= row; i++)
            {
                // spaces
                for (int j = i; j < row; j++)
                {
                    Console.Write(" ");
                }

               
                for (int j = 1; j <= (2 * i - 1); j++)
                {
                    if (j == 1 || j == (2 * i - 1))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }

            for (int i = row - 1; i >= 1; i--)
            {
          
                for (int j = row; j > i; j--)
                {
                    Console.Write(" ");
                }

               
                for (int j = 1; j <= (2 * i - 1); j++)
                {
                    if (j == 1 || j == (2 * i - 1))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}