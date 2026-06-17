using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question16
    {
        public Question16() { 
        
        int n = Convert.ToInt32 (Console.ReadLine());
            int a = 0;
            int b = 1;
            int next = 0;
            if(n < 1)
            {
                Console.WriteLine("Invalid");
            }
            for(int i = 0; i <= n; i++)
            {
                Console.Write(a + " ");
                next = a + b;
                a = b;
                b = next;
            }
        }
    }
}
