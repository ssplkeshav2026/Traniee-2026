using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project1
{
    public class Student
    {
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        //public Student(int roll, string name)
        //{
        //    RollNumber = roll;
        //    Name = name;
        //    Grades = new List<double>();
        //}

        public Student()
        {

        }
        public void AddGrade(double grade)
        {
            Grades.Add(grade);
        }

        public double CalculateAverage()
        {
            if (Grades.Count == 0)
            {
                return 0;
            }
            else
            {
                return Grades.Average();
            }
        }

        public void Display()
        {
            Console.WriteLine($"Roll No: {RollNumber},Name:{Name},Avg:{CalculateAverage():0.00}");
        }


        public void finalCode()
        {
            Student s = new Student();
            List<Student> students = new List<Student>();

            while (true)
            {
                Console.WriteLine("\n1. Add Student");
                Console.WriteLine("2. Add Grades");
                Console.WriteLine("3. Calculate Average");
                Console.WriteLine("4. Display All Students");
                Console.WriteLine("5. Search Student by Roll Number");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1:
                        Console.Write("Enter Roll Number: ");
                        int roll = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Student s1 = new Student();

                        s1.RollNumber = roll;
                        s1.Name = name;

                        students.Add(s1);

                        Console.WriteLine("Student added successfully!");
                        break;

                    case 2:
                        Console.Write("Enter Roll Number: ");
                        int rollForGrade = int.Parse(Console.ReadLine());

                        Student foundStudent = null;

                        foreach (var st in students)
                        {
                            if (st.RollNumber == rollForGrade)
                            {
                                foundStudent = st;
                                break;
                            }
                        }

                        if (foundStudent != null)
                        {
                            Console.Write("Enter Grade: ");
                            double grade = double.Parse(Console.ReadLine());

                            foundStudent.AddGrade(grade);
                            Console.WriteLine("Grade added!");
                        }
                        else
                        {
                            Console.WriteLine("Student not found!");
                        }
                        break;

                    case 3:
                        Console.Write("Enter Roll Number: ");
                        int rollForAvg = int.Parse(Console.ReadLine());

                        Student student2 = null;

                        foreach (var st in students)
                        {
                            if (st.RollNumber == rollForAvg)
                            {
                                student2 = st;
                                break;
                            }
                        }

                        if (student2 != null)
                        {
                            Console.WriteLine("Average: " + student2.CalculateAverage());
                        }
                        else
                        {
                            Console.WriteLine("Student not found!");
                        }
                        break;

                    case 4:
                        if (students.Count == 0)
                        {
                            Console.WriteLine("No students available.");
                        }
                        else
                        {
                            foreach (var st in students)
                            {
                                st.Display();
                            }
                        }
                        break;

                    case 5:
                        Console.Write("Enter Roll Number: ");
                        int searchRoll = int.Parse(Console.ReadLine());

                        Student student3 = null;

                        foreach (var st in students)
                        {
                            if (st.RollNumber == searchRoll)
                            {
                                student3 = st;
                                break;
                            }
                        }

                        if (student3 != null)
                        {
                            student3.Display();
                        }
                        else
                        {
                            Console.WriteLine("Student not found!");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}