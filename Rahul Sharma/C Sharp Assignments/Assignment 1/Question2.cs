using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2.Create a console-based temperature converter with a menu system:
//1.Celsius to Fahrenheit
//2.Fahrenheit to Celsius
//3. Exit

namespace Assignment1
{
    internal class Question2
    {
        public Question2()
        {
            
            Console.WriteLine("Enter \n 1.Celsius to Fahrenheit\r\n 2.Fahrenheit to Celsius \r\n 3. Exit ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
                {
                case 1:
                    Console.WriteLine("Enter Celsius Temperature ");
                    int ctemp=int.Parse(Console.ReadLine());
                    float Fahrenheit=(float)(ctemp * 9.0 / 5.0) + 32;
                    Console.WriteLine("Fahrenheit Temperature is " + Fahrenheit);
                    break;
                case 2:
                    Console.WriteLine("Enter  Fahrenheit Temperature ");
                    int ftemp = int.Parse(Console.ReadLine());
                    float celsius = (float)((ftemp - 32.0) * 5.0 / 9.0);
                    Console.WriteLine("celsiu Temperature is " + celsius);
                    break;

                case 3:
                    return;
                }


        }
    }
}
