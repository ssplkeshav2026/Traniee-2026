using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question19
    {
        public question19()
        {
            int[] array = new int[10];
            int sum = 0;

            Console.WriteLine("Enter 10 numbers:");

            for (int i = 0; i < 10; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
                sum += array[i];
            }

            double avg = (double)sum / 10;

            int max = array[0], min = array[0];

            for (int i = 1; i < 10; i++)
            {
                if (array[i] > max) max = array[i];
                if (array[i] < min) min = array[i];
            }

            Console.WriteLine("Sum = "+ sum);
            Console.WriteLine("Average = " + avg);
            Console.WriteLine("Maximum = " + max);
            Console.WriteLine("Minimum = " + min);

            Console.WriteLine("Reverse order:");
            for (int i = 9; i >= 0; i--)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
