using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question14
    {
        public Question14()
        {
            int n = 5;
            int a = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(a+" ");
                    a++;
                }
                Console.WriteLine();
            }
        }
    }
}
