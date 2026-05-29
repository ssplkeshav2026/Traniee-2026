using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question4
    {
        public Question4()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (a > b)
            {
                Console.WriteLine("Largest is a");
            }
            else if (b > c)
            {
                Console.WriteLine("Largest is b");
            }
            else
            {
                Console.WriteLine("Largest is c");
            }
        }
    }
}
