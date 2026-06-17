using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question1
    {
        public question1()
        {
            Console.Write("Enter Your First Name : ");
            string firstname = Console.ReadLine();

            Console.Write("Enter Your Last Name : ");
            string lastname = Console.ReadLine();

            Console.Write("Enter Your Age : ");
            int age = Convert.ToInt32(Console.ReadLine());

            int Year = DateTime.Now.Year - age;

            Console.WriteLine("Hello [" + firstname + " " + lastname + "]," + "you were born in [" + Year + "]");
        }
    }
}
