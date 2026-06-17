using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question11
    {
        public question11()
        {
            Console.Write("Enter no. of Rows : ");
            int row = Convert.ToInt32(Console.ReadLine());

            int space = row - 1;
            int star = 1;

            for (int i = 1; i < row * 2; i++)
            {
                for (int j = 1; j <= space; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 1; j <= star; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

                if (i < row)
                {
                    space--;
                    star += 2;
                }
                else
                {
                    space++;
                    star -= 2;
                }
            }
        }
    }
}
