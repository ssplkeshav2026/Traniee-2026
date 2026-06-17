using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//3.Build a simple calculator that continuously runs until the user chooses to exit. 
//    Display menu options for +, -, *, /, and exit.

namespace Assignment1
{
    internal class Question3
    {
        public Question3()
        {
            int a, b, Result;
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n===== Calculator Menu =====");
                Console.WriteLine("1. + (Addition)");
                Console.WriteLine("2. - (Subtraction)");
                Console.WriteLine("3. * (Multiplication)");
                Console.WriteLine("4. / (Division)");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "Exit"|| choice == "exit")
                {
                    Console.WriteLine("Exiting Calculator...");
                    break;  
                }
                switch (choice)
                {
                    case "+":
                        Console.WriteLine("Enter Two Numbers:");
                        a = int.Parse(Console.ReadLine());
                        b = int.Parse(Console.ReadLine());
                        Result = a + b;
                        Console.WriteLine("Addition is " + Result);
                        break;

                    case "-":
                        Console.WriteLine("Enter Two Numbers:");
                        a = int.Parse(Console.ReadLine());
                        b = int.Parse(Console.ReadLine());
                        Result = a - b;
                        Console.WriteLine("Subtraction is " + Result);
                        break;

                    case "*":
                        Console.WriteLine("Enter Two Numbers:");
                        a = int.Parse(Console.ReadLine());
                        b = int.Parse(Console.ReadLine());
                        Result = a * b;
                        Console.WriteLine("Multiplication is " + Result);
                        break;

                    case "/":
                        Console.WriteLine("Enter Two Numbers:");
                        a = int.Parse(Console.ReadLine());
                        b = int.Parse(Console.ReadLine());

                        if (b != 0)
                        {
                            Result = a / b;
                            Console.WriteLine("Division is " + Result);
                        }
                        else
                        {
                            Console.WriteLine("Cannot divide by zero!");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}






