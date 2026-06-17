using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//4.Create a console program that takes three numbers and finds the largest among them without using arrays.

namespace Assignment1
{
    internal class Question4
    {
        public Question4()
        {
            Console.WriteLine("Enter first Numbers:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Second Numbers:");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Third Numbers:");
            int c = int.Parse(Console.ReadLine());

            if(a>b &&a>c)
            {
                Console.WriteLine("A is Largest " + a);
            }
            else if(b>c)
            {
                Console.WriteLine("B is Largest " + b);
            }
            else
            {
                Console.WriteLine("C is Largest " + c);
            }

        }

    }
}
