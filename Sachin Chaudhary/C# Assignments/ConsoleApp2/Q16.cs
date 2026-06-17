using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Q16
    {
        public Q16()
        {
            Console.WriteLine("enter the number:");
            int num = Convert.ToInt32(Console.ReadLine());
            int a = 0;
            int b = 1;
            int c;
            for (int i = 0; i <= num; i++)
            {
                Console.Write(a + " ");
                c = a + b;
                a = b;
                b = c;
            }
        }
    }
}
