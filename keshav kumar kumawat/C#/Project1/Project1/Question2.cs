using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question2
    {
        public Question2()
        {
            string s = Console.ReadLine();

            switch (s)
            {
                case "1":
                    double c = double.Parse(Console.ReadLine());
                    double f = (9 / 5f) * c + 32;
                    Console.WriteLine(f);
                    break;

                case "2":
                    double a = double.Parse(Console.ReadLine());
                    double d = ((5 * a) - 32 * 5) / 9;
                    Console.WriteLine(d);
                    break;

                case "3":
                    Console.WriteLine("Exit");
                    break;

                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }
    }
}