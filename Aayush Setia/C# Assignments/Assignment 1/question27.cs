using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question27
    {
        class Employee
        {
            public string Name { get; set; }
            private decimal salary;

            public Employee(string name, decimal initialSalary)
            {
                Name = name;
                salary = initialSalary;
            }

            public void GiveRaise(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Error: Raise must be positive.");
                    return;
                }
                salary += amount;
                Console.WriteLine("Raise Applied!");
            }

            public decimal GetAnnualSalary()
            {
                return salary * 12;
            }

            public void DisplayDetails()
            {
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Monthly Salary: " + salary);
                Console.WriteLine("Annual Salary: " + GetAnnualSalary());
            }
        }

        List<Employee> employees = new List<Employee>();

        public question27()
        {
            int choice;

            do
            {
                Console.WriteLine("\n1. Add Employee");
                Console.WriteLine("2. Give Raise");
                Console.WriteLine("3. Display Employee Details");
                Console.WriteLine("4. Calculate Annual Salary");
                Console.WriteLine("5. Exit");

                Console.Write("Enter Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                Employee emp = null;

                if (choice >= 2 && choice <= 4)
                {
                    Console.Write("Enter Employee Name: ");
                    string name = Console.ReadLine();

                    emp = employees.Find(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                    if (emp == null)
                    {
                        Console.WriteLine("Employee not found!");
                        continue;
                    }
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        string n = Console.ReadLine();

                        Console.Write("Enter Salary: ");
                        decimal s = Convert.ToDecimal(Console.ReadLine());

                        employees.Add(new Employee(n, s));
                        Console.WriteLine("Employee Added!");
                        break;

                    case 2:
                        Console.Write("Enter Raise Amount: ");
                        decimal r = Convert.ToDecimal(Console.ReadLine());
                        emp.GiveRaise(r);
                        break;

                    case 3:
                        emp.DisplayDetails();
                        break;

                    case 4:
                        Console.WriteLine("Annual Salary: " + emp.GetAnnualSalary());
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

            } while (choice != 5);
        }
    }
}