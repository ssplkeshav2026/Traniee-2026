using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace assignment_c__1
{
    internal class question16
    {
        public question16()
        {
            int a = 0, b = 1, c, n;
            Console.Write("Enter the number");
            n = Convert.ToInt32(Console.ReadLine());

            Console.Write(  a + " "  + b+" ");
            for (int i = 3; i < n; i++)
            {
                c = a + b;
                Console.Write(c + " ");
                a = b;
                b = c;
            }
            Console.WriteLine();

        }
    }
}
