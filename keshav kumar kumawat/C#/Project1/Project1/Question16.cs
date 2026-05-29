using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question16
    {
        public Question16()
        {
            Console.Write("Enter the number of terms: ");
            int n = int.Parse(Console.ReadLine());

            int first = 0;
            int second = 1;
            int next;

            Console.Write(first + " " + second + " ");

            for (int i = 2; i < n; i++)
            {
                next = first + second;
                Console.Write(next + " ");
                first = second;
                second = next;
            }
        }
    }
}
  
//Fibonacci Series
// 0 1 1 2 3 5 8 13 21 ... .......
