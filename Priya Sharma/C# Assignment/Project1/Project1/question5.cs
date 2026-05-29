using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question5
    {
        public question5()
        {
                int TotalFamilyMembers, age, price, totalPrice = 0;

                Console.Write("Enter no. of family members: ");
                TotalFamilyMembers = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= TotalFamilyMembers; i++)
                {
                    Console.Write("Enter age of member " + i + ": ");
                    age = Convert.ToInt32(Console.ReadLine());

                    if (age < 5)
                    {
                        price = 0;
                    }
                    else if (age >= 5 && age <= 12)
                    {
                        price = 10;
                    }
                    else if (age >= 13 && age <= 60)
                    {
                        price = 25;
                    }
                    else
                    {
                        price = 15;
                    }

                    totalPrice = totalPrice + price;
                }

                Console.WriteLine("Total ticket price = $" + totalPrice);
            
        }

    }
}

