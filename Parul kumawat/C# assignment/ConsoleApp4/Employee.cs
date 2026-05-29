using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Employee
    {
        bool keepRun = true;

        private double salary;
        List<string> empNames = new List<string>();
        List<double> empSalary = new List<double>();
        List<int> empId = new List<int>();

        public Employee()
        {
            while (keepRun)
            {
                Console.WriteLine(" Menu ");
                Console.WriteLine("1 = Add Employee");
                Console.WriteLine("2 = Give Raise");
                Console.WriteLine("3 = Display Employee details");
                Console.WriteLine("4 = Calculate Annual salary");
                Console.WriteLine("5 = Exit");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());


                switch (option)
                {
                    case 1:
                        addEmployee();
                        break;

                    case 2:
                        giveRaise();
                        break;

                    case 3:
                        displayEmployeeDetails();
                        break;

                    case 4:
                        calculateAnnualSalary();
                        break;
                    case 5:
                        keepRun = false;
                        Console.WriteLine("exit");
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
        public void addEmployee()
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter ID: ");
            int eId = int.Parse(Console.ReadLine());
            Console.Write("Enter salary: ");
            int eSalary = int.Parse(Console.ReadLine());
            empNames.Add(name);
            empId.Add(eId);
            empSalary.Add(eSalary);
            Console.WriteLine("Employee added successfully.");
        }

        public void giveRaise()
        {
            Console.Write("Enter ID to give raise: ");
            int id = Convert.ToInt32(Console.ReadLine());
            int index = empId.IndexOf(id);

            if (index != -1)
            {
                Console.WriteLine("enter raise percentage amount :");
                double raisePercentage = Convert.ToDouble(Console.ReadLine());
                double raiseAmount = empSalary[index] * (raisePercentage / 100);
                empSalary[index] += raiseAmount;
                Console.WriteLine($"New Salary: {empSalary[index]}");

            }
            else
            {
                Console.WriteLine("employee not found");
            }
        }
        public void displayEmployeeDetails()
        {
            Console.Write("Enter Account Number to search: ");
            int id = Convert.ToInt32(Console.ReadLine());

            int eId = empId.IndexOf(id);

            if (eId != -1)
            {
                Console.WriteLine($"Employee Name : {empNames[eId]}, Employee salary : {empSalary[eId]}, EMployee ID : {empId[eId]}");
            }
            else
            {
                Console.WriteLine("employee not found");

            }
        }
        public void calculateAnnualSalary()
        {
            Console.Write("Enter Account Number to calculate employee annual salary: ");
            int id = Convert.ToInt32(Console.ReadLine());

            int eId = empId.IndexOf(id);

            if (eId != -1)
            {
                double totalSalary = empSalary[eId] * 12;
                Console.WriteLine($"Annual salary of this employee : {totalSalary}");
            }
        }
    }
}
