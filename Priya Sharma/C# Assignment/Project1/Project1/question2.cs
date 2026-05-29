using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question2
    {
        public question2()
        {
             int Menu;

                do
            { 
                    Console.WriteLine("\nTemperature Converter");
                    Console.WriteLine("1. Celsius to Fahrenheit");
                    Console.WriteLine("2. Fahrenheit to Celsius");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");
                    Menu = Convert.ToInt32(Console.ReadLine());

                    switch (Menu)
                    {
                        case 1:
                            Console.Write("Enter temperature in Celsius: ");
                            double celsius = Convert.ToDouble(Console.ReadLine());
                            double fahrenheit = (celsius * 9 / 5) + 32;
                            Console.WriteLine("Temperature in Fahrenheit: " + fahrenheit);
                            break;

                        case 2:
                            Console.Write("Enter temperature in Fahrenheit: ");
                            double fah = Convert.ToDouble(Console.ReadLine());
                            double cel = (fah - 32) * 5 / 9;
                            Console.WriteLine("Temperature in Celsius: " + cel);
                            break;

                    case 3:
                        Console.WriteLine("Program Exit...");
                        break;

                    default:
                            Console.WriteLine("Invalid choice......");
                            break;
                    }

                } while (Menu != 3);
            
        }

    }
}

