using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Question1
    {
        // Constructor
        public Question1()
        {   Console.WriteLine("Enter your Firstname");
            String firstname=Console.ReadLine();
            Console.WriteLine("Enter your Lastname");
            string lastname=Console.ReadLine();
            Console.WriteLine("Enter your age");
            int age=int.Parse(Console.ReadLine());
            int currentYear = DateTime.Now.Year;
            int birthYear = currentYear - age;

            Console.WriteLine("Hello " + firstname + " " + lastname + " you were born in " + birthYear);
        }
    }
}
