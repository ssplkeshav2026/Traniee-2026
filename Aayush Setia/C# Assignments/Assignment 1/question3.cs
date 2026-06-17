using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question3
    {
        public question3()
        {
            int choice;
            double num1, num2;

            Console.WriteLine("1. Add");
            Console.WriteLine("2. Sub");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Div");
            Console.WriteLine("5. Exit");

            Console.Write("Enter You Choice  ");
            choice = Convert.ToInt32(Console.ReadLine());


            if(choice >= 1 && choice <=4)
            {
                Console.Write("Enter the First Number");
                num1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the Second Number");
                num2 = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Result" + (num1 + num2));
                    Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Result " + (num1 - num2));
                    Console.ReadLine();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Result" + (num1 * num2));
                    Console.ReadLine();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Result" + (num1 / num2));
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Exit");
                    Console.ReadLine();
                }
            }
        }
    }
}
