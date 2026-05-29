using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Student
    {
        bool keepRun = true;
        List<string> studentNames = new List<string>();
        List<int> studentId = new List<int>();
        Dictionary<int, List<double>> studentMarks = new Dictionary<int, List<double>>();


        public Student()
        {

            while (keepRun)
            {
                Console.WriteLine(" Menu ");
                Console.WriteLine("1 = Add Student");
                Console.WriteLine("2 = Add grades for a student");
                Console.WriteLine("3 = Calculate Average");
                Console.WriteLine("4 = Display All Students");
                Console.WriteLine("5 = Search student by Roll Number");
                Console.WriteLine("6 = Exit");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());


                switch (option)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        addGrade();
                        break;

                    case 3:
                        calculateAverage();
                        break;
                    case 4:
                        displayAllStudents();
                        break;
                    case 5:
                        searchById();
                        break;
                    case 6:
                        keepRun = false;
                        Console.WriteLine("exit");
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private void AddStudent()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter ID: ");
            int stdId = int.Parse(Console.ReadLine());
            studentNames.Add(name);
            studentId.Add(stdId);
            Console.WriteLine("Student added successfully.");
        }
        private void addGrade()
        {
            Console.Write("Enter Student ID to add grades for: ");
            int id = int.Parse(Console.ReadLine());

            if (!studentId.Contains(id))
            {
                Console.WriteLine("Student ID not found!");
                return;
            }

            Console.Write("Enter Math Marks: ");
            double mathMarks = double.Parse(Console.ReadLine());
            Console.Write("Enter Physics Marks: ");
            double physicsMarks = double.Parse(Console.ReadLine());
            Console.Write("Enter Science Marks: ");
            double scienceMarks = double.Parse(Console.ReadLine());
            List<double> marks = new List<double> { mathMarks, physicsMarks, scienceMarks };
            studentMarks[id] = marks;
            Console.WriteLine("Marks added successfully.");

            double totalMarks = mathMarks + physicsMarks + scienceMarks;
            double percentage = (totalMarks / 300.0) * 100;
            string grade;

            if (percentage >= 90)
            {
                grade = "A+";
                Console.WriteLine("Grade :" + grade);
            }
            else if (percentage >= 80)
            {
                grade = "A";
                Console.WriteLine("Grade :" + grade);

            }
            else if (percentage >= 70)
            {
                grade = "B";
                Console.WriteLine("Grade :" + grade);

            }
            else if (percentage >= 60)
            {
                grade = "C";
                Console.WriteLine("Grade :" + grade);

            }
            else
            {
                grade = "F";
                Console.WriteLine("Grade :" + grade);
                Console.WriteLine("You are fail");
            }
        }

        private void calculateAverage()
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());

            if (!studentMarks.ContainsKey(id))
            {
                Console.WriteLine("Marks not found for this student!");
                return;
            }

            List<double> marks = studentMarks[id];
            double sum = 0;

            foreach (double m in marks)
            {
                sum += m;
            }

            double avg = sum / marks.Count;

            Console.WriteLine("Average Marks: " + avg);

        }
        private void displayAllStudents()
        {
            Console.WriteLine("students lists : ");

            for (int i = 0; i < studentId.Count; i++)
            {
                Console.WriteLine($"Student ID: {studentId[i]}\n  Name: {studentNames[i]}");

            }
        }


        private void searchById()
        {
            Console.Write("Enter student ID to search: ");
            int id = int.Parse(Console.ReadLine());

            int index = studentId.IndexOf(id);
            if (index != -1)
            {
                Console.WriteLine($"Stuednt Name: {studentNames[index]}\n Student ID: {id}");
                if (studentMarks.ContainsKey(id))
                {
                    var m = studentMarks[id];
                    Console.WriteLine($"Scores: Math: {m[0]}, Physics: {m[1]}, Science: {m[2]}");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

    }
}

