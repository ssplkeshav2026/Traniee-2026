

//26.Student Grade Management Console App: Create a Student class and implement:
//1.Add Student
//2. Add Grades for a Student
//3. Calculate Average
//4. Display All Students
//5. Search Student by Roll Number
//6. Exit

using System;
using System.Collections.Generic;

namespace Assignment1
{
    internal class Student
    {
        public int RollNo;
        public string Name;
        public List<double> Grades = new List<double>();
    }

    internal class StudentApp
    {
        public StudentApp()
        {
            List<Student> students = new List<Student>();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n--- Student Management ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Grades");
                Console.WriteLine("3. Calculate Average");
                Console.WriteLine("4. Display All Students");
                Console.WriteLine("5. Search Student by Roll No");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    
                    case 1:
                        Student s = new Student();

                        Console.Write("Enter Roll No: ");
                        s.RollNo = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        s.Name = Console.ReadLine();

                        students.Add(s);
                        Console.WriteLine("Student Added!");
                        break;

                   
                    case 2:
                        Console.Write("Enter Roll No: ");
                        int roll = int.Parse(Console.ReadLine());

                        Student found = null;

                        foreach (Student st in students)
                        {
                            if (st.RollNo == roll)
                            {
                                found = st;
                                break;
                            }
                        }

                        if (found != null)
                        {
                            Console.Write("Enter Grade: ");
                            double grade = double.Parse(Console.ReadLine());

                            found.Grades.Add(grade);
                            Console.WriteLine("Grade Added!");
                        }
                        else
                        {
                            Console.WriteLine("Student Not Found!");
                        }
                        break;

            
                    case 3:
                        Console.Write("Enter Roll No: ");
                        int avgRoll = int.Parse(Console.ReadLine());

                        Student avgStudent = null;

                        foreach (Student st in students)
                        {
                            if (st.RollNo == avgRoll)
                            {
                                avgStudent = st;
                                break;
                            }
                        }

                        if (avgStudent != null && avgStudent.Grades.Count > 0)
                        {
                            double sum = 0;

                            foreach (double g in avgStudent.Grades)
                            {
                                sum += g;
                            }

                            double avg = sum / avgStudent.Grades.Count;

                            Console.WriteLine("Average = " + avg);
                        }
                        else
                        {
                            Console.WriteLine("No Grades Found or Student Not Found!");
                        }
                        break;

                    
                    case 4:
                        foreach (Student st in students)
                        {
                            Console.WriteLine("------------------");
                            Console.WriteLine("Roll No: " + st.RollNo);
                            Console.WriteLine("Name: " + st.Name);
                            Console.WriteLine("Grades: " + string.Join(",", st.Grades));
                        }
                        break;

                 
                    case 5:
                        Console.Write("Enter Roll No: ");
                        int searchRoll = int.Parse(Console.ReadLine());

                        Student searchStudent = null;

                        foreach (Student st in students)
                        {
                            if (st.RollNo == searchRoll)
                            {
                                searchStudent = st;
                                break;
                            }
                        }

                        if (searchStudent != null)
                        {
                            Console.WriteLine("Name: " + searchStudent.Name);
                            Console.WriteLine("Grades: " + string.Join(",", searchStudent.Grades));
                        }
                        else
                        {
                            Console.WriteLine("Student Not Found!");
                        }
                        break;

                  
                    case 6:
                        isRunning = false;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }
    }
}
