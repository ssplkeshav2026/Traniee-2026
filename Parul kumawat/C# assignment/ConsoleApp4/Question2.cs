using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question2
    {
        public Question2()
        {
            Console.WriteLine("Enter Celsius temperature:");

            double fahrenheit = CToFConvert();
        Console.WriteLine($"Temperature in Fahrenheit: {fahrenheit}");


            Console.WriteLine("Enter Fahrenheit temperature:");

            double Celsius = FToCConvert();
        Console.WriteLine($" Fahrenheit Temperature in Celsius: {Celsius}");


            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);


        }



        static double CToFConvert()
        {
            double val = Convert.ToDouble(Console.ReadLine());
            return (val * (9.0 / 5.0) + 32);
        }

        static double FToCConvert()
        {
            double far = Convert.ToDouble(Console.ReadLine());
            return ((far - 32) * 5.0 / 9.0);
        }

    }
}
