using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question1
    {
        public Question1()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int currentYear = DateTime.Now.Year;
            int birthYear = currentYear - age;


            Console.WriteLine($"Hello {firstName} {lastName} you were born in {birthYear}");
        }

    }
}
