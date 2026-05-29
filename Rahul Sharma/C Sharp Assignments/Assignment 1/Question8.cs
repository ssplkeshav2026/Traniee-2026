using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    //8. Inverted Right-Angled Triangle
    //     *****
    //     ****
    //     ***
    //     **
    //     *
    internal class Question8
    {
        public Question8()
        {

            Console.WriteLine("Enter number of rows ");
            int row = int.Parse(Console.ReadLine());

            for (int i = row; i >=0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }


        }
    }
}
