//using System;
//using System.Collections.Generic;

//namespace program
//{
//    class Employee
//    {
//        private static int choice;
//        private double salary;
       
//        static List<string> employee = new List<string>();
//        static List<double> salaries = new List<double>();

//        static void Main(string[] args)
//        {
//            bool start = true;

//            while (start)
//            {
//                Console.WriteLine("--- HR System ---");
//                Console.WriteLine("1. Add Employee");
//                Console.WriteLine("2. Give Raise");
//                Console.WriteLine("3. Display Employee");
//                Console.WriteLine("4. Calculate Annual Salary");
//                Console.WriteLine("5. Exit");

//                choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        addemp();
//                        break;

//                    case 2:
//                        Console.WriteLine("Enter raise amount:");
//                        double amount = Convert.ToDouble(Console.ReadLine());
//                        GiveRaise(amount);
//                        break;

//                    case 3:
//                        Display();
//                        break;

//                    case 4:
//                        AnnualSalary();
//                        break;

//                    case 5:
//                        start = false;
//                        Console.WriteLine("bye!");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid choice");
//                        break;
//                }
//            }
//        }

//        static void addemp()
//        {
//            Console.Write("Enter name: ");
//            employee.Add(Console.ReadLine());

//            Console.Write("Enter salary: ");
//            salaries.Add(Convert.ToDouble(Console.ReadLine()));

//            Console.WriteLine("Employee Added!");
//        }

//         static void GiveRaise(double amount)
//        {
//            Console.WriteLine("Enter employee name:");
//            string name = Console.ReadLine();

//            int index = employee.IndexOf(name);

//            if (index != -1)
//            {
//                salaries[index] += amount;
//                Console.WriteLine($"New Salary of {employee[index]}: {salaries[index]}");
//            }
//            else
//            {
//                Console.WriteLine("Employee not found");
//            }
//        }

//        static void Display()
//        {
//            Console.WriteLine("--- Employee List ---");

//            for (int i = 0; i < employee.Count; i++)
//            {
//                Console.WriteLine($"Name: {employee[i]}, Salary: {salaries[i]}");
//            }
//        }

//        static void AnnualSalary()
//        {
//            Console.WriteLine("Enter employee name:");
//            string name = Console.ReadLine();

//            int index = employee.IndexOf(name);

//            if (index != -1)
//            {
//                double annual = salaries[index] * 12;
//                Console.WriteLine($"Annual Salary of {employee[index]}: {annual}");
//            }
//            else
//            {
//                Console.WriteLine("Employee not found");
//            }
//        }
//    }
//}