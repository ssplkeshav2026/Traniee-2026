using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question4
    {
        public question4()
        {
            Console.Write("Enter First Number : ");
            double Number1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Second Number : ");
            double Number2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Third Number : ");
            double Number3 = Convert.ToInt32(Console.ReadLine());


            if (Number1 >= Number2 && Number1 >= Number3)
            {
                Console.WriteLine("Largest number is: " + Number1);
            }
            else if (Number2 >= Number3)
            {
                Console.WriteLine("Largest number is: " + Number2);
            }
            else
            {
                Console.WriteLine("Largest number is: " + Number3);
            }
        }

    }
}




