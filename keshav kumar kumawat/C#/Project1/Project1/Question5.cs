using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question5
    {
        public Question5()
        {
            int age = int.Parse(Console.ReadLine());
            int TotalPrice = 0;

            if (age < 5)
            {
                TotalPrice += 0;
                Console.WriteLine(TotalPrice);
            }
            else if (age > 5 && age < 12)
            {
                TotalPrice += 10;
                Console.WriteLine(TotalPrice);
            }
            else if (age > 13 && age < 60)
            {
                TotalPrice += 25;
                Console.WriteLine(TotalPrice);
            }
            else if (age > 60)
            {
                TotalPrice += 15;
                Console.WriteLine(TotalPrice);
            }
            else
            {
                Console.WriteLine("All Age people are free");
            }
        }
    }
}
