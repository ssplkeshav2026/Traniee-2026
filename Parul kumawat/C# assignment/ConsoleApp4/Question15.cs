using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question15
    {
        public Question15() {
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= n; i++)
            {
                char ch = 'A';
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(ch);
                    ch++;
                }
                Console.WriteLine();
            }

        }
    }
}
