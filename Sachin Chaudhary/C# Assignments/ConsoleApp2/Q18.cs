//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ConsoleApp2
//{
//    internal class Q18
//    {
//        public Q18()
//        {
//            bool start = true;
//            while (start)
//            {
//                Console.WriteLine("-----Factorial Calculator------");
//                Console.WriteLine("1.factorial");
//                Console.WriteLine("2.Exit");
//                int choice = Convert.ToInt32(Console.ReadLine());



//                switch (choice)
//                {
//                    case 1:
//                        Console.WriteLine("Enter the value");
//                        int num = Convert.ToInt32(Console.ReadLine());
//                        int facto = 1;
//                        if (num < 0) Console.WriteLine(-1);

//                        for (int i = 1; i <= num; i++)
//                        {
//                            facto = facto * i;

//                        }
//                        Console.WriteLine("factorial is:" + facto);
//                        break;
//                    case 2:
//                        Console.WriteLine("bye ");
//                        start = false;
//                        break;



//                }



//            }

//        }

//    }
//}
