using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question18
    {
        public question18()
        {
            while (true)
            {
                Console.WriteLine("\nFactorial Calculator :-");
                Console.WriteLine("1. Calculate Factorial");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter a number: ");
                        int num = Convert.ToInt32(Console.ReadLine());

                        if (num < 0)
                        {
                            Console.WriteLine("Factorial is not defined for negative numbers.");
                            break;
                        }

                        long fact = 1;

                        for (int i = 1; i <= num; i++)
                        {
                            fact *= i;
                        }

                        Console.WriteLine($"Factorial of {num} = {fact}");
                        break;

                    case 2:
                        Console.WriteLine("Program Exit...");
                        return;

                    default:
                        Console.WriteLine("Invalid. Try again.");
                        break;
                }
            }
        }
    }
}
    

