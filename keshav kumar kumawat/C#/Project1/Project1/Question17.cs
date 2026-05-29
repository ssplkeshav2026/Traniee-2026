using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question17
    {
        public Question17()
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());

            int originalNum = n;
            int sum = 0;
            int digits = n.ToString().Length;

            while (n > 0)
            {
                int digit = n % 10;
                sum += (int)Math.Pow(digit, digits);
                n=n/10;
            }

            if (sum == originalNum)
            {
                Console.WriteLine("Armstrong number");
            }
            else
            {
                Console.WriteLine("Not an Armstrong number");
            }
        }
    }
}