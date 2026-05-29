using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//19.Create a console program that reads 10 numbers from the user, stores them in an array, and
//displays:
//Sum and average
//Maximum and minimum values
//Numbers in reverse order

namespace Assignment1
{
    internal class Question19
    {
        public Question19() {
           
            int[] arr=new int[10];

            Console.WriteLine("Enter array 10 elements ");
            for(int i=0; i<10; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            Console.Write("10 Array Elements are [" );
            for (int i = 0;i<10; i++)
            {
               Console.Write(arr[i]+" ");
            }
            Console.Write("]");
       
            int sum = 0;
            int avg;
            for (int i = 0; i < 10; i++)
            {
                sum = sum + arr[i];
            }
            avg=sum/10;
            Console.WriteLine();
            Console.WriteLine("1. Sum of array Elements is " + sum + " and Average is " + avg);

            int max = arr[0];
            int min = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }

                if (min > arr[i])
                {
                    min = arr[i];
                }
            }

            Console.WriteLine("2. Maximum element is " + max + " and Minimum element is " + min);


                 for (int i = 0; i < 10 / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[10 - 1 - i];
                arr[10 - 1 - i] = temp;
            }

            Console.Write("Reverse Array Elements are [");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write("]");


        }

    }
}
