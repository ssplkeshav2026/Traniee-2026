using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question5
    {
        public Question5()
        {

            Console.WriteLine("Enter number of family members:");
            int totalMembers = Convert.ToInt32(Console.ReadLine());
            int totalPrice = 0;


            for (int i = 1; i <= totalMembers; i++)
            {

                Console.WriteLine($"Enter age of member {i}:");
                int n = Convert.ToInt32(Console.ReadLine());

                if (n < 5)
                {
                    Console.WriteLine("Child price : Free");
                }
                else if (n >= 5 && n <= 12)
                {

                    totalPrice += getPrice(10);
                }
                else if (n >= 13 && n <= 60)
                {
                    totalPrice += getPrice(10);

                }

                else if (n > 60)
                {
                    totalPrice += getPrice(10);

                }
                else
                {
                    Console.WriteLine("Invalid Age ");
                }
            }



            Console.WriteLine($"Your Total price is : {totalPrice}");

        }

        public int getPrice(int dollar)
        {

            return dollar * 95;

        }
    }
}
