using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Student
    {
        public Student()
        {
            List<string> names = new List<string>();
            List<int> ids = new List<int>();
            List<List<int>> grades = new List<List<int>>();

            bool start = true;

            while (start)
            {
                Console.WriteLine("----Students----");
                Console.WriteLine("1.Add Student");
                Console.WriteLine("2.Add 4 subject marks");
                Console.WriteLine("3.Calculate Avg");
                Console.WriteLine("4.Display all student");
                Console.WriteLine("5.Search student by roll number");
                Console.WriteLine("6.Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        AddMarks();
                        break;

                    case 3:
                        CalculateAvg();
                        break;

                    case 4:
                        Display();
                        break;

                    case 5:
                        Search();
                        break;

                    case 6:
                        start = false;
                        break;
                }
            }

        

            void AddStudent()
            {
                Console.WriteLine("Enter student name:");
                string name = Console.ReadLine();

                  Console.WriteLine("Enter student ID:");
                int id = Convert.ToInt32(Console.ReadLine());

                names.Add(name);
                 ids.Add(id);
                   grades.Add(new List<int>());

                Console.WriteLine("Student added!");
            }

            void AddMarks()
            {
                Console.WriteLine("Enter student ID:");
                int searchId = Convert.ToInt32(Console.ReadLine());

                  int index = ids.IndexOf(searchId);

                if (index != -1)
                {
                    List<int> marks = new List<int>();

                      for (int i = 1; i <= 4; i++)
                    {
                         Console.WriteLine($"Enter marks for subject {i}:");
                           marks.Add(Convert.ToInt32(Console.ReadLine()));
                    }

                    grades[index] = marks;
                }
                else
                {
                    Console.WriteLine("Student not found");
                }
            }

            void CalculateAvg()
            {
                Console.WriteLine("Enter student ID:");
                   int searchId = Convert.ToInt32(Console.ReadLine());

                  int index = ids.IndexOf(searchId);

                if (index != -1 && grades[index].Count == 4)
                {
                     double sum = 0;
                       foreach (int m in grades[index])
                    {
                        sum += m;
                    }

                    Console.WriteLine("Average: " + (sum / 4));
                }
                else
                {
                    Console.WriteLine("Marks not added yet");
                }
            }

            void Display()
            {
                for (int i = 0; i < names.Count; i++)
                {
                    Console.Write($"Name: {names[i]}, ID: {ids[i]} ");

                    if (grades[i].Count == 4)
                    {
                        Console.Write("Marks: ");
                        foreach (int m in grades[i])
                        {
                            Console.Write(m + " ");
                        }
                    }
                    else
                    {
                        Console.Write("Marks not added");
                    }

                    Console.WriteLine();
                }
            }

            void Search()
            {
                Console.WriteLine("Enter ID:");
                int searchId = Convert.ToInt32(Console.ReadLine());

                int index = ids.IndexOf(searchId);

                if (index != -1)
                {
                    Console.WriteLine($"Name: {names[index]}");

                    if (grades[index].Count == 4)
                    {
                        Console.Write("Marks: ");
                        foreach (int m in grades[index])
                        {
                            Console.Write(m + " ");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Marks not added");
                    }
                }
                else
                {
                    Console.WriteLine("Student not found");
                }
            }
        }
    }
}