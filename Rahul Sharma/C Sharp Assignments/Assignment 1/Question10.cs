//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

////10.Inverted Pyramid

////    *********
////     *******
////      *****
////       ***
////        *

//using System;

//namespace Assignment1
//{
//    internal class Question10
//    {
//        public Question10()
//        {
//            Console.WriteLine("Enter number of rows ");
//            int row = int.Parse(Console.ReadLine());

//            for (int i = 0; i < row; i++)
//            {

//                for (int j =2 ; j<i-1  ; j++)
//                {
//                    Console.Write("-");
//                }


//                for (int k = ; k > ; k++)
//                {
//                    Console.Write("*");
//                }

//                Console.WriteLine();
//            }
//        }
//    }
//}



using System;

namespace Assignment1
{
    internal class Question10
    {
        public Question10()
        {
            Console.WriteLine("Enter number of rows: ");
            int row=int.Parse(Console.ReadLine());
            
              
                for (int i = 0; i < row; i++)
                {
                    
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write(" ");
                    }

                    for (int k = 0; k < (row - i) * 2 - 1; k++)
                    {
                        Console.Write("*");
                    }

        
                    Console.WriteLine();
                }
            
           
           
        }
    }
}
