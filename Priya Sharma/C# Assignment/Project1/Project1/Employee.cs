using Project1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project1
{
    public class Employee
    {
        public string Name;
        public int EmployeeId ;
        private double Salary;
        private double UpdatedSalary;

        List<Employee> employees = new List<Employee>();


        public Employee(string name, double salary)
        {
            Name = name;
            EmployeeId = new Random().Next(1000, 9999);
            Salary = salary;
            UpdatedSalary = salary;
        }

        public Employee()
        {
            
        }
        public void GiveRaise(double percentage)
        {
            UpdatedSalary = Salary + (Salary * percentage / 100);
        }

        public void DisplayDetails()
        {
            Console.WriteLine("\nEmployee Details:");
            Console.WriteLine("Employee Name : " + Name);
            Console.WriteLine("Employee ID   : " + EmployeeId);
            Console.WriteLine("Basic Salary  : " + Salary);
            Console.WriteLine("Updated Salary: " + UpdatedSalary);
        }

        public void ShowTotalSalary()
        {
            Console.WriteLine("Total Salary after increment: " + UpdatedSalary);
        }

        public bool MatchEmployee(int id)
        {
            return EmployeeId == id;
        }

        public double GetUpdatedSalary()
        {
            return UpdatedSalary;
        }




        public void AddEmployee()
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            Employee emp = new Employee(name,salary);
            employees.Add(emp);

            Console.WriteLine("Employee ID: " + emp.EmployeeId);
            Console.WriteLine("Employee Added Successfully");
        }

        public Employee FindEmployee()
        {
           

            Console.Write("Enter Employee ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Employee emp in employees)
            {
                if (emp.EmployeeId == id)
                {
                    return emp;
                }
            }

            return null;
        }
        

        public void GiveRaise()
        {
                Employee emp = FindEmployee();

                if (emp != null)
                {
                    Console.Write("Enter Raise Percentage: ");
                    double percent = Convert.ToDouble(Console.ReadLine());

                    emp.GiveRaise(percent);

                    Console.WriteLine("Salary Updated Successfully");
                }
                else
                {
                    Console.WriteLine("Employee Not Found");
                }
        }

       

        public void DisplayEmployee()
        {
            Employee emp = FindEmployee();

            if (emp != null)
            {
                emp.DisplayDetails();
            }
            else
            {
                Console.WriteLine("Employee Not Found");
            }
        }

        public void ShowSalary()
        {
            Employee emp = FindEmployee();

            if (emp != null)
            {
                Console.WriteLine("Total Salary: " + emp.GetUpdatedSalary());
            }
            else
            {
                Console.WriteLine("Employee Not Found");
            }
        }

        
        public void Execute()
{
        int choice;

            do
            {
                Console.WriteLine("\nHR System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Give Raise");
                Console.WriteLine("3. Display Employee Details");
                Console.WriteLine("4. Show Annual Salary");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;

                    case 2:
                        GiveRaise();
                        break;

                    case 3:
                        DisplayEmployee();
                        break;

                    case 4:
                        ShowSalary();
                        break;

                    case 5:
                        Console.WriteLine("Program Exit");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            } while (choice != 5);
    }

}
}





































//mujhe ek console based menu banana h jisme mujhe option add karne h jaise ki 
//    1. option 1 add emplyee details jisme emplyee ka name user input karega employee id random number generate hoga 4 digit ka aur salary add hogi by user
//    2. option 2 mein emplyee ki salary mein updation hoga percentage ke basis pr jo ki user add karega ki kitne percent update karni h
//    3. option 3 mein employee ki details display karni using emplyee id. details mein employee ka name uski emplyee id or salary with increment
//    4. option 4 mein employee ki total salary shoe karni h (actual salary + updated percentage amount of salary)

//    Note: 1. employee ki salary ek private field hogi
//    2. salary unhi employees ki updte karni h jinki employee id ya name mein updation kiya ho
//    3. jitne bhi employees add ho unn sb ko ek list mein store karna h  