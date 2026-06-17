using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question4
    {
        public question4()
        {
            int num1, num2, num3;
            Console.WriteLine("Enter the First Number");
            num1= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Second Number");
            num2= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Second Number");
            num3 = Convert.ToInt32(Console.ReadLine());


            if (num1 > num2 && num1>num3)
            {
                Console.WriteLine("Num1 is greatest number");
                Console.ReadLine();
               
            }
            else if(num2 > num1 && num2 > num3)
            {
                Console.WriteLine("num2 is the greatest number");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("num3 is the greatest number ");
            }
        }
    }
}
