using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question1
    {
        public question1()
        {
            Console.Write("enter your firstname ");
            string firstname = Console.ReadLine();
            Console.Write("enter your lastname ");
            string lastname = Console.ReadLine();
            Console.Write("enter your age ");
            int age = Convert.ToInt32(Console.ReadLine());
            int birthyear = DateTime.Now.Year - age;

            Console.WriteLine("Hello" +" "+ firstname + " " + lastname +" "+ "You born in "+" " + birthyear);

        }
    }
}
