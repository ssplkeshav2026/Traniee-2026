using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private double salary;
        public Employee()
        {

        }

        public void SetSalary(double amount)
        {
            if (amount > 0)
            {
                salary = amount;
            }
            else
            {
                Console.WriteLine("Invalid Salary");
            }
        }

        public double GetSalary()
        {
            return salary;
        }

        public void GiveRaise(double amount)
        {
            if (amount > 0)
            {
                salary = salary + amount;
                Console.WriteLine("Increase salary successfully");
            }
            else
            {
                Console.WriteLine("Invalid way of increasing salary");
            }
        }

        public double AnnualSalary()
        {
            return salary * 12;
        }

        public void Display()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Salary: " + salary);
        }

        public void finalCode()
        {
            Employee e = new Employee();

            List<Employee> employees = new List<Employee>();

            while (true)
            {
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Give Raise");
                Console.WriteLine("3. Display Employee Details");
                Console.WriteLine("4. Calculate Annual Salary");
                Console.WriteLine("5. Exit");

                Console.WriteLine("Enter choice");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Name: ");
                        string name = Console.ReadLine().Trim();

                        if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Name cannot be empty!");
                            break;
                        }


                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Name cannot be empty!");
                            break;
                        }

                        Console.WriteLine("Enter Salary: ");
                        double sal = double.Parse(Console.ReadLine());

                        Employee emp = new Employee();
                        emp.Id = id;
                        emp.Name = name;
                        emp.SetSalary(sal);

                        employees.Add(emp);

                        Console.WriteLine("Employee Added Successfully");
                        break;

                    case 2:
                        Console.WriteLine("Enter Employee ID:");
                        int raiseId = int.Parse(Console.ReadLine());

                        Employee foundEmp = null;

                        foreach (var e1 in employees)
                        {
                            if (e1.Id == raiseId)
                            {
                                foundEmp = e1;
                                break;
                            }
                        }

                        if (foundEmp != null)
                        {
                            Console.WriteLine("Enter raise amount");
                            double raise = double.Parse(Console.ReadLine());
                            foundEmp.GiveRaise(raise);
                        }
                        else
                        {
                            Console.WriteLine("Employee not found");
                        }
                        break;

                    case 3:

                        Console.WriteLine("Enter Employee ID:");
                        int searchId = int.Parse(Console.ReadLine());

                        Employee emp2 = null;

                        foreach (var e1 in employees)
                        {
                            if (e1.Id == searchId)
                            {
                                emp2 = e1;
                                break;
                            }
                        }

                        if (emp2 != null)
                        {
                            emp2.Display();
                        }

                        else
                        {
                            Console.WriteLine("Employee not found!");
                        }
                        break;

                    case 4:

                        Console.WriteLine("Enter Employee ID:");
                        int annualId = int.Parse(Console.ReadLine());

                        Employee emp3 = null;

                        foreach (var e1 in employees)
                        {
                            if (e1.Id == annualId)
                            {
                                emp3 = e1;
                                break;
                            }
                        }

                        if (emp3 != null)
                        {
                            double annualSalary = emp3.AnnualSalary();
                            Console.WriteLine("Monthly Salary: " + emp3.GetSalary());
                            Console.WriteLine("Annual Salary: " + annualSalary);
                        }
                        else
                        {
                            Console.WriteLine("Employee not found!");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Exit");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }

        }
    }
}
