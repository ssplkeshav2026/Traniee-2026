using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class q24
    {
        public q24()
        {
            Console.Write("Enter the number of rows: ");
            int rows = int.Parse(Console.ReadLine());

           
            int[][] triangle = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
               
                triangle[i] = new int[i + 1];

              
                triangle[i][0] = 1;
                triangle[i][i] = 1;

               
                for (int j = 1; j < i; j++)
                {
                    triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                }
            }

    
            for (int i = 0; i < rows; i++)
            {
            
                Console.Write(new string(' ', (rows - i) * 2));

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(triangle[i][j] + "   ");
                }
                Console.WriteLine();
            }
        }
    }
}
