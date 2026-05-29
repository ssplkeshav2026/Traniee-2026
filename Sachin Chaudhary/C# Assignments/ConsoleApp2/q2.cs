//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ConsoleApp2
//{
//    public class q2
//    {
//     public  int f;

//        public void Menu()
//        {
//            bool start = true;
//            while (start)
//            {
//                Console.WriteLine("\n--- Temperature Converter ---");
//                Console.WriteLine("1. Celsius to Fahrenheit");
//                Console.WriteLine("2. Fahrenheit to Celsius");
//                Console.WriteLine("3. Exit");
//                Console.Write("Choice select karein: ");

//                string choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        celsius();
//                        break;
//                    case "2":
//                        Fahrenheit();
//                        break;
//                    case "3":
//                        start = false;
//                        Console.WriteLine("Bye!");
//                        break;
//                    default:
//                        Console.WriteLine("Invalid choice! Fir se try karein.");
//                        break;
//                }
//            }
//        }




//        public void celsius()
//        {


//            Console.WriteLine("enter the celsius");
//            int c = Convert.ToInt32(Console.ReadLine());
//            int f = (c * 9 / 5) + 32;

//            Console.WriteLine($"Fahrenheit:{f}");
//        }

//        public void Fahrenheit()
//        {
//            Console.WriteLine($"Converted in f:{f}");
//            Console.WriteLine("enter the f");
//            int cal = (f - 32) * 5 / 9;

//        } }
//    }






    

