

//16.Create a console program that displays the Fibonacci sequence up to n terms (user input).

using System;

namespace Assignment1
{
    internal class Question16
    {
        public Question16()
        {
            Console.Write("Enter number of terms: ");
            int n = int.Parse(Console.ReadLine());

            int a = 0, b = 1;

            Console.Write(a + " " + b + " ");

            for (int i = 3; i <= n; i++)
            {
                int next = a + b;
                Console.Write(next + " ");

                a = b;
                b = next;
            }
        }
    }
}