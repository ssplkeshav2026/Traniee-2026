using System;
//PascalTriangle
namespace Assignment1
{
    internal class Question24
    {
        public Question24()
        {
            Console.Write("Enter number of rows: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = 1;

               
                for (int s = i; s < n; s++)
                {
                    Console.Write(" ");
                }

             
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(number + " ");

                    number = number * (i - j) / (j + 1);
                }

                Console.WriteLine();
            }
        }
    }
}