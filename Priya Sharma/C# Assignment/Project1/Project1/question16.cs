using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question16
    {
        public question16()
        {
            Console.Write("Enter number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            int first = 0, second = 1;

            Console.WriteLine("Fibonacci Sequence:");

            for (int i = 1; i <= num; i++)
            {
                Console.Write(first + " ");

                int temp = first + second;
                first = second;
                second = temp;
            }
        }
    }
}
