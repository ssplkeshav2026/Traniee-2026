//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ConsoleApp2
//{
//    public class q3
//    {
//        public int f;

//        public void Menu1()
//        {
//            bool start = true;
//            while (start)
//            {
//                Console.WriteLine("\n--- calculator  ---");
//                Console.WriteLine("1. sum");
//                Console.WriteLine("2. multiple");
//                Console.WriteLine("3. Divid");
//                Console.WriteLine("4. subtraction");
//                Console.WriteLine("5. Exit");
//                Console.Write("Choice select karein: ");

//                string choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        Console.WriteLine("enter the first value");
//                       int num1= Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine("enter the second value");
//                          int num2 = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine($"Sum:{num1+num2}");
//                        break;
//                    case "2":
//                        Console.WriteLine("enter the first value");
//                        int num3 = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine("enter the second value");
//                        int num4 = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine($"multiply:{num3 * num4}");
//                        break;
//                    case "3":
//                        Console.WriteLine("enter the first value");
//                        int n = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine("enter the second value");
//                        int n2 = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine($"divid:{n / n2}");
//                        break;
//                    case "4":
//                        Console.WriteLine("enter the first value");
//                        int n1 = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine("enter the second value");
//                        int n3 = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine($"multiple:{n1 - n3}");
//                        break;

//                    case "5":
//                        start = false;
//                        Console.WriteLine("Bye!");
//                        break;
//                    default:
//                        Console.WriteLine("Invalid ");
//                        break;
//                }
//            }
//        }




 
//    }
//}
