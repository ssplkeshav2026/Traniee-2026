using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question5
    {
        public question5()
        {
            int members;
            int age;
            int price = 0;

            Console.Write("Enter members");
            members = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i < members; i++)
            {
                Console.Write("Enter age of members" + i + " ");
                age = Convert.ToInt32(Console.ReadLine());


                if (age < 5)
                {
                    price = price + 0;
                }
                else if (age < 12)
                {
                    price = price + 10;
                }
                else if (age < 60)
                {
                    price = price + 25;
                }
                else
                {
                    price = price + 15;
                }
            }
            Console.WriteLine("total price for the tickets is" + price);
        }
        
    }
}
