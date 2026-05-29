using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question15
    {
        public Question15()
        {
            int n = 5;
            
            for (int i = 1; i <= n; i++)
            {
                char ch = 'A';
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(ch + " ");
                    ch++;
                }
                
                Console.WriteLine();
            }
        }
    }
}
