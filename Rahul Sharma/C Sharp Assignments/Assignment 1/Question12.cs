

//12.Hollow Square
//  *****
//  -----
//  *---*
//  -----  
//  *---*
//  -----
//  *---*
//  -----
//  *---*
//  -----
//  *****

using System;

namespace Assignment1
{
    internal class Question12
    {
        public Question12()
        {
            Console.Write("Enter number of rows: ");
            int rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                   
                    if (i == 0 || i == rows - 1 || j == 0 || j == rows - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}