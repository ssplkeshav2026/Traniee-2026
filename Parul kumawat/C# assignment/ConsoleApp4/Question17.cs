using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question17
    {
        public Question17() {

            int n = Convert.ToInt32(Console.ReadLine());
            int orig = n;
            int sum = 0;
            int digits = n.ToString().Length;
            if (n < 1)
            {
                Console.WriteLine("Invalid");
            }

            while (n > 0)
            {
                int temp = n % 10;
                sum += (int)Math.Pow(temp, digits);
                n = n / 10;
            }

            if(sum == orig)
            {
                Console.WriteLine("Armstrong number");
            }
            else
            {
                Console.WriteLine("not armstrong");
            }



        }
    }
}
