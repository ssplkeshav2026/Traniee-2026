using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question17
    {
        public question17()
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            int Number = num;
            int sum = 0;

            int digits = num.ToString().Length;

            while (num > 0)
            {
                int remainder = num % 10;
                sum += (int)Math.Pow(remainder, digits);
                num /= 10;
            }

            if (sum == Number)
                Console.WriteLine(Number + " is an Armstrong Number");
            else
                Console.WriteLine(Number + " is not an Armstrong Number");
        }
    }
}
    

