using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question24
    {
        public question24()
        {
                int k = 1;
                Console.Write("Enter no. of rows: ");  
                int row = Convert.ToInt32(Console.ReadLine());  

                for (int i = 0; i < row; i++)
                {
                    for (int temp = 1; temp <= row - i; temp++)
                        Console.Write("  ");  

                    for (int j = 0; j <= i; j++)
                    {
                        if (j == 0 || i == 0)
                            k = 1; 
                        else
                            k = k * (i - j + 1) / j; 

                        Console.Write("{0}  ", k); 
                    }
                    Console.Write("\n");  
                }
            
        }


    }

}

