using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question3
    {
        public question3()
        {   
                int choice;
                double num1, num2, result;

                do
                {
                    Console.WriteLine("\nSimple Calculator");
                    Console.WriteLine("1. (+) Addition");
                    Console.WriteLine("2. (-) Subtraction");
                    Console.WriteLine("3. (*) Multiplication");
                    Console.WriteLine("4. (/) Divide");
                    Console.WriteLine("5. Exit");

                    Console.Write("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice >= 1 && choice <= 4)
                    {
                        Console.Write("Enter first number: ");
                        num1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter second number: ");
                        num2 = Convert.ToDouble(Console.ReadLine());
                    }
                    else
                    {
                        num1 = 0;
                        num2 = 0;
                    }

                    switch (choice)
                    {
                        case 1:
                            result = num1 + num2;
                            Console.WriteLine("Result = " + result);
                            break;

                        case 2:
                            result = num1 - num2;
                            Console.WriteLine("Result = " + result);
                            break;

                        case 3:
                            result = num1 * num2;
                            Console.WriteLine("Result = " + result);
                            break;

                        case 4:
                            if (num2 != 0)
                            {
                                result = num1 / num2;
                                Console.WriteLine("Result = " + result);
                            }
                            else
                            {
                                Console.WriteLine("Cannot divide by zero");
                            }
                            break;

                        case 5:
                            Console.WriteLine("Program Exit");
                            break;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }

                } while (choice != 5);
            
        }

    }
}

