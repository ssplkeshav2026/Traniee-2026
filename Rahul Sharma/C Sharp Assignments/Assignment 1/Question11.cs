
////11.Diamond Pattern
////     *
////    ***
////   *****
////  *******
////   *****
////    *** 
////     *

using System;

namespace Assignment1 
{
    internal class Question11 
    {
        public Question11() 
        {
            Console.Write("Enter number of rows half-height: ");
            int rows=int.Parse(Console.ReadLine());

           
            for (int i = 1; i <= rows; i++) 
            {
               
                for (int j = 1; j <= rows - i; j++) 
                    Console.Write(" ");

              
                for (int k = 1; k <= 2 * i - 1; k++) 
                    Console.Write("*");

                Console.WriteLine();
            }

          
            for (int i = rows - 1; i >= 1; i--) 
            {
             
                for (int j = 1; j <= rows - i; j++) 
                    Console.Write(" ");

              
                for (int k = 1; k <= 2 * i - 1; k++) 
                    Console.Write("*");

                Console.WriteLine();
            }
        }
    }
}
