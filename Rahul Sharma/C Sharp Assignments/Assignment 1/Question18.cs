using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//18.Build a simple menu - driven console app for a factorial calculator that runs until the user exits.

using System;

namespace Assignment1
{
    internal class Question18
    {
        public Question18()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n===== Factorial Calculator =====");
                Console.WriteLine("1. Calculate Factorial");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter a number: ");
                        int num = int.Parse(Console.ReadLine());

                        if (num < 0)
                        {
                            Console.WriteLine("Factorial is not defined for negative numbers.");
                        }
                        else
                        {
                            long fact = 1;

                            for (int i = 1; i <= num; i++)
                            {
                                fact = fact * i;
                            }

                            Console.WriteLine("Factorial of " + num + " is: " + fact);
                        }
                        break;

                    case 2:
                        Console.WriteLine("Exiting program...");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }
    }
}