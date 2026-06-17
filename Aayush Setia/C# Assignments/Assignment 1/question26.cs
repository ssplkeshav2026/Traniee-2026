using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment_c__1
{
    class Student
    {
        public int rollNo;
        public string name;
        public List<int> grades = new List<int>();

        public void AddStudent(int r, string n)
        {
            rollNo = r;
            name = n;
        }

        public void AddGrade(int grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                Console.WriteLine("Grade Added!");
            }
            else
            {
                Console.WriteLine("Invalid Grade!");
            }
        }

        public void CalculateAverage()
        {
            if (grades.Count == 0)
            {
                Console.WriteLine("No grades available.");
                return;
            }

            double avg = grades.Average();
            Console.WriteLine("Average Marks: " + avg);
        }

        public void Display()
        {
            Console.WriteLine("Roll No: " + rollNo);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Grades: " + (grades.Count > 0 ? string.Join(",", grades) : "No Grades"));
        }
    }

    class Program26
    {
        public void school()
        {
            List<Student> students = new List<Student>();
            int choice;

            do
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Grades for a Student");
                Console.WriteLine("3. Calculate Average");
                Console.WriteLine("4. Display All Students");
                Console.WriteLine("5. Search Student by Roll Number");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                Student stu = null;

                if (choice >= 2 && choice <= 3 || choice == 5)
                {
                    Console.Write("Enter Roll No: ");
                    int r = Convert.ToInt32(Console.ReadLine());

                    stu = students.Find(s => s.rollNo == r);

                    if (stu == null)
                    {
                        Console.WriteLine("Student not found!");
                        continue;
                    }
                }

                switch (choice)
                {
                    case 1:
                        Student s = new Student();

                        Console.Write("Enter Roll No: ");
                        int roll = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        s.AddStudent(roll, name);
                        students.Add(s);

                        Console.WriteLine("Student Added Successfully!");
                        break;

                    case 2:
                        Console.Write("Enter Grade: ");
                        int g = Convert.ToInt32(Console.ReadLine());
                        stu.AddGrade(g);
                        break;

                    case 3:
                        stu.CalculateAverage();
                        break;

                    case 4:
                        foreach (var student in students)
                        {
                            Console.WriteLine("\n--- Student ---");
                            student.Display();
                        }
                        break;

                    case 5:
                        Console.WriteLine("\n--- Student Found ---");
                        stu.Display();
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

            } while (choice != 6);
        }
    }
}