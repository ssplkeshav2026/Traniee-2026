using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question2
    {
        public question2()
        {
            int choice;

            Console.WriteLine("1.  celsius to fahrenheit ");
            Console.WriteLine("2.  fahrenheit to celsius");
            Console.WriteLine("3. exit");

            Console.Write("Enter your choice ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter the celsius");
                double c = Convert.ToDouble(Console.ReadLine());

                double f = c * 9 / 5 + 32;
                Console.WriteLine("the value is " + f);
            }
            else if (choice == 2)
            {
                Console.Write("Enter the fahrenheit");
                double f = Convert.ToDouble(Console.ReadLine());

                double c = (f - 32) * 5 / 9;
                Console.WriteLine("the value is " + c);
            }
            else
            {
                Console.WriteLine("Exit");
            }
        }
    }
}
