using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question17
    {
        public question17()
        {
            int num, temp, sum = 0, rem;

            Console.Write("Enter the number");
            num= Convert.ToInt32(Console.ReadLine());

            temp = num;
            while (num > 0)
            {
                rem = num % 10;
                sum = sum+(rem * rem * rem);
                num = num / 10;

            }
            if (temp == sum)
            {
                Console.Write("This is Armstrong Number");
            }
            else
            {
                Console.Write("This is Not a Armstrong number");
            }
            Console.WriteLine();
        }
    }
}
