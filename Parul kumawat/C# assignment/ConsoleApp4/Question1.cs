using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question1
    {
        private int _age;
        public Question1()
        {
            Console.WriteLine("Enter your details :");
            Console.WriteLine("Enter your firstName :");

            string fName = Console.ReadLine();

            Console.WriteLine("Enter your lastName :");

            string lName = Console.ReadLine();

            Console.WriteLine("Enter your Age :");
            _age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Hello {fName} {lName}, you were born in {BornYear()}");
        }
        public int BornYear()
        {
            int current = DateTime.Now.Year;
            return current - _age;

        }

    }

}

