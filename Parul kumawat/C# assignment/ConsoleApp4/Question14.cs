using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question14
    {
        public Question14()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int count = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(count + " ");
                    count++;
                }
                Console.WriteLine();
            }

        }
    }
}
