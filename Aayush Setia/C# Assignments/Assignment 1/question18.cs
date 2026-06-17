using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question18
    {
        public question18()
        {
            int num;
            int factorial = 1;
            Console.Write("Enter the Number");
            num = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                factorial *= i;
            }
            Console.WriteLine("the factorial is "+ factorial);
        }
    }
}
