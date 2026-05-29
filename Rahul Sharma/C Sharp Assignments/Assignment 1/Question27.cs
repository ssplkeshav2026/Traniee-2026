using System;
using System.Collections.Generic;

class Employee
{
    public int Id;
    public string Name;

    private double salary;

    public Employee(int id, string name, double salary)
    {
        Id = id;
        Name = name;

        if (salary > 0)
            this.salary = salary;
        else
            this.salary = 0;
    }

    public void GiveRaise(double percentage)
    {
        if (percentage > 0)
        {
            double raiseAmount = salary * percentage / 100;
            salary = salary + raiseAmount;

            Console.WriteLine("Raise Amount: " + raiseAmount);
            Console.WriteLine("Updated Salary: " + salary);
        }
        else
        {
            Console.WriteLine("Invalid percentage!");
        }
    }

    public void DisplayDetails()
    {
        Console.WriteLine("\n--- Employee Details ---");
        Console.WriteLine("Employee Id: " + Id);
        Console.WriteLine("Employee Name: " + Name);
        Console.WriteLine("Monthly Salary: " + salary);
    }

    public void CalculateAnnualSalary()
    {
        double annualSalary = salary * 12;
        Console.WriteLine("Annual Salary is: " + annualSalary);
    }
}

class EmployeeDetail
{
    public EmployeeDetail()
    {
        List<Employee> employees = new List<Employee>();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n--- HR System Menu ---");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Give Raise");
            Console.WriteLine("3. Display All Employee Details");
            Console.WriteLine("4. Calculate Annual Salary");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Employee Id: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Employee Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Salary: ");
                    double salary = double.Parse(Console.ReadLine());

                    Employee emp = new Employee(id, name, salary);
                    employees.Add(emp);

                    Console.WriteLine("Employee Added Successfully!");
                    break;

                case 2:
                    Console.Write("Enter Employee Id: ");
                    int raiseId = int.Parse(Console.ReadLine());

                    Employee raiseEmp = null;

                    foreach (Employee e in employees)
                    {
                        if (e.Id == raiseId)
                        {
                            raiseEmp = e;
                            break;
                        }
                    }

                    if (raiseEmp != null)
                    {
                        Console.Write("Enter raise percentage: ");
                        double percentage = double.Parse(Console.ReadLine());

                        raiseEmp.GiveRaise(percentage);
                    }
                    else
                    {
                        Console.WriteLine("Employee not found!");
                    }

                    break;

                case 3:
                    if (employees.Count == 0)
                    {
                        Console.WriteLine("No employees available.");
                    }
                    else
                    {
                        foreach (Employee e in employees)
                        {
                            e.DisplayDetails();
                        }
                    }

                    break;

                case 4:
                    Console.Write("Enter Employee Id: ");
                    int annualId = int.Parse(Console.ReadLine());

                    Employee annualEmp = null;

                    foreach (Employee e in employees)
                    {
                        if (e.Id == annualId)
                        {
                            annualEmp = e;
                            break;
                        }
                    }

                    if (annualEmp != null)
                    {
                        annualEmp.CalculateAnnualSalary();
                    }
                    else
                    {
                        Console.WriteLine("Employee not found!");
                    }

                    break;

                case 5:
                    isRunning = false;
                    Console.WriteLine("Program Closed.");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}