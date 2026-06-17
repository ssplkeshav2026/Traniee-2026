using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question19
    {
        public Question19() {

            int[] num = new int[10];
            Console.WriteLine("Enter any 10 values :");
            for(int i = 0; i < num.Length; i++)
            {
                num[i] = Convert.ToInt32(Console.ReadLine());
            }
            int sum = 0;
            double avg = 0;
            int max = 0;

            

            for(int i = 0; i < num.Length; i++)
            {
                sum += num[i];
               

            }
            avg = sum / num.Length;
            
            Console.WriteLine("Sum of elements : " + sum);
            Console.WriteLine("average of elements : " + avg);
            for (int i = 0; i < num.Length; i++)
            {
                    if(max < num[i])
                {
                    max = num[i];
                }

            }
            int min = max;

            for (int i = 0; i < num.Length; i++)
            {
                if (min > num[i])
                {
                    min = num[i];
                }

            }
            Console.WriteLine("Max number :" + max);
            Console.WriteLine("Min number :" + min);


            Console.Write("Reverse an array :");
            for (int j = num.Length - 1; j >= 0; j--)
            {
                Console.Write(num[j] + " ");
                
            }
            
            

        }



    }
}
