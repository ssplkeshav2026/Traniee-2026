using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//17.Write a program that checks if a number is an Armstrong number (e.g., 153 = 1 ^ 3 + 5 ^ 3 + 3 ^ 3 ) .

using System;

namespace Assignment1
{
    internal class Question17
    {
        public Question17()
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());

            int copy = num;
            int sum = 0;
            int digits = 0;

         
            int temp = num;
            while (temp > 0)
            {
                digits++;
                temp =temp/ 10;
            }

            temp = num;
            while (temp > 0)
            {
                int rem = temp % 10;

                int power = 1;
                for (int i = 0; i < digits; i++)
                {
                    power = power * rem;  
                }

                sum = sum+power;
                temp /= 10;
            }

            
            if (sum == copy)
                Console.WriteLine("Armstrong Number");
            else
                Console.WriteLine("Not an Armstrong Number");
        }
    }
}