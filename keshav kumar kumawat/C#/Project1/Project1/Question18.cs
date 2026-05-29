using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question18
    {
        static void CalculateFactorial()
        {
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                int f = 1;

                for (int i = 1; i <= n; i++)
                {
                    f = f * i;
                }

                Console.WriteLine($"Factorial of {n} is: {f}");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
        public Question18()
        {
            bool running = true;

            while (running)
            {
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CalculateFactorial();
                        break;

                    case "2":
                        running = false;
                        Console.WriteLine("Exit program");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}