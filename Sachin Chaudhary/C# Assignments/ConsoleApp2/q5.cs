//using System;
//using System.Collections.Generic;
//using System.Numerics;
//using System.Text;

//namespace ConsoleApp2
//{
//    public class q5
//    {
//        public q5()
//        {

//            Console.WriteLine("enter the age of members");
//            int n=Convert.ToInt32(Console.ReadLine());
//            int n2 = Convert.ToInt32(Console.ReadLine());
//            int n3 = Convert.ToInt32(Console.ReadLine());
//            int n4 = Convert.ToInt32(Console.ReadLine());
//            List<int> familyAges = new List<int> { n, n2, n3, n4 };

//                int totalPrice = TotalPrice(familyAges);

//                Console.WriteLine($"The total price for the family is: ${totalPrice}");
//            }

//            static int TotalPrice(List<int> ages)
//            {
//                int total = 0;

//                foreach (int age in ages)
//                {
//                    if (age < 5)
//                    {
//                        total += 0;
//                    }
//                    else if (age >= 5 && age <= 12)
//                    {
//                        total += 10;
//                    }
//                    else if (age >= 13 && age <= 60)
//                    {
//                        total += 25;
//                    }
//                    else 
//                    {
//                        total += 15;
//                    }
//                }

//                return total;
//            }
//        }
//    }



