using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question4
    {
        public Question4()
        {

            Console.WriteLine("Enter numbers :");
            Console.WriteLine("Enter first Number :");
            int n1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second Number :");
            int n2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter third Number :");
            int n3 = Convert.ToInt32(Console.ReadLine());


            int maxNumber = Math.Max(n1, Math.Max(n2, n3));
            Console.WriteLine("Largest number among them is : " + maxNumber);


        }
    }
}
