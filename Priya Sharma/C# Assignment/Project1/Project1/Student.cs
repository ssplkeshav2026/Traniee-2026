using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Project1
{
    public class Student
    {
        List<string> Name = new List<string>();
        List<Guid> Rollno = new List<Guid>();
        List<List<int>> Grades = new List<List<int>>();

        public void AddStudent()
        {
            Console.Write("Enter Student Name:");
            string name = Console.ReadLine();

            Guid roll = Guid.NewGuid();

            Name.Add(name);
            Rollno.Add(roll);
            Grades.Add(new List<int>());

            Console.WriteLine("Roll Number: " + roll);
            Console.WriteLine("Student Added Successfully");
        }

        public void AddGrades()
        {
            Console.Write("Enter Roll Number:");
            Guid roll = Guid.Parse(Console.ReadLine());

            int index = Rollno.IndexOf(roll);

            if (index != -1)
            {
                List<int> marks = new List<int>();

                string[] subjects = { "Physics", "Chemistry", "Maths", "Hindi", "English" };

                for (int i = 0; i < subjects.Length; i++)
                {
                    Console.WriteLine("Enter marks for {0} :" , subjects[i]);
                    int mark = Convert.ToInt32(Console.ReadLine());
                    marks.Add(mark);
                }

                Grades[index] = marks;

                int total = marks.Sum();
                Console.WriteLine("Total Grades: " + total);
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }

        public void Average()
        {
            Console.Write("Enter Roll Number:");
            Guid roll = Guid.Parse(Console.ReadLine());

            int index = Rollno.IndexOf(roll);

            if (index != -1 && Grades[index].Count == 5)
            {
                int total = Grades[index].Sum();
                double avg = total / 5.0;

                Console.WriteLine("Average of Grades: " + avg);
            }
            else
            {
                Console.WriteLine("Marks not added");
            }
        }

        public void Display()
        {
            for (int i = 0; i < Name.Count; i++)
            {
                Console.WriteLine("\nStudent Details");
                Console.WriteLine("Name: " + Name[i]);
                Console.WriteLine("Roll No: " + Rollno[i]);

                if (Grades[i].Count == 5)
                {
                    Console.WriteLine("Marks: " + string.Join(", ", Grades[i]));
                    Console.WriteLine("Total: " + Grades[i].Sum());
                    Console.WriteLine("Average: " + (Grades[i].Sum() / 5.0));
                }
                else
                {
                    Console.WriteLine("Marks not added");
                }
            }
        }

        public void Search()
        {
            Console.Write("Enter Roll Number:");
            Guid roll = Guid.Parse(Console.ReadLine());

            int index = Rollno.IndexOf(roll);

            if (index != -1)
            {
                Console.WriteLine("Name: " + Name[index]);
                Console.WriteLine("Roll No: " + Rollno[index]);

                if (Grades[index].Count == 5)
                {
                    Console.WriteLine("Marks: " + string.Join(", ", Grades[index]));
                    Console.WriteLine("Total: " + Grades[index].Sum());
                    Console.WriteLine("Average: " + (Grades[index].Sum() / 5.0));
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

        public void show()
        {
            int choice;
            do
            {
                Console.WriteLine("\nStudent Grade Management");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add 5 Subject Marks");
                Console.WriteLine("3. Calculate Average");
                Console.WriteLine("4. Display All Students");
                Console.WriteLine("5. Search Student by Roll Number");
                Console.WriteLine("6. Exit");
                Console.Write("Enter Choice:");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        AddGrades();
                        break;

                    case 3:
                        Average();
                        break;

                    case 4:
                        Display();
                        break;

                    case 5:
                        Search();
                        break;

                    case 6:
                        Console.WriteLine("Program Exits");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 6);
        }
    }
}
