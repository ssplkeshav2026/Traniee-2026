using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question10
    {
        public Question10()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= (2 * i - 1); k++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

        }
    }
}
