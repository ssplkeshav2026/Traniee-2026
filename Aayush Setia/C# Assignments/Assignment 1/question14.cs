using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question14
    {
        public question14()
        {
            int n = 5;
            int num = 1;
            for(int i = 1; i <n; i++)
            {
                for(int j = i-1; j >=0; j--)
                {
                    Console.Write(num );
                    num++;
                }
                Console.WriteLine();
            }
        }
    }
}
