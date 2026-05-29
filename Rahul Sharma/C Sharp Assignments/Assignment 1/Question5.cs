using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//5.Build a ticket pricing system:
//Age < 5: Free
//Age 5 - 12: $10
//Age 13-60: $25
//Age > 60: $15
//Display the total price for a family

namespace Assignment1
{
    internal class Question5
    {
        public Question5() 
        {
            Console.WriteLine("Enter Your Age ");
            int Age = int.Parse(Console.ReadLine());
            if (Age < 5)
                Console.WriteLine("Free");
            else if (Age >=5 && Age <=12)
                Console.WriteLine(" Price is $10");
            else if(Age >=13 && Age<=60)
                Console.WriteLine("Price is $25");
            else if(Age>60)
                Console.WriteLine("Price is $15");
        }
    }
}
