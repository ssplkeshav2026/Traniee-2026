using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//21.Build a console-based contact book that stores names and phone numbers in arrays.
//Provide menu options to add, search, display all, and exit.

using System;

namespace Assignment1
{
    internal class Question21
    {
        public Question21()
        {
            string[] names = new string[100];
            string[] phones = new string[100];

            int count = 0;
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n--- Contact Book ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Search Contact");
                Console.WriteLine("3. Display All Contacts");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        
                        if (count < names.Length)
                        {
                            Console.Write("Enter Name: ");
                            names[count] = Console.ReadLine();

                            Console.Write("Enter Phone Number: ");
                            phones[count] = Console.ReadLine();

                            count++;
                            Console.WriteLine("Contact Added Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Contact list is full!");
                        }
                        break;

                    case 2:
               
                        Console.Write("Enter Name to Search: ");
                        string searchName = Console.ReadLine();

                        bool found = false;

                        for (int i = 0; i < count; i++)
                        {
                            if (names[i].Equals(searchName, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Found: " + names[i] + " - " + phones[i]);
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Contact not found!");
                        }
                        break;

                    case 3:
                        
                        if (count == 0)
                        {
                            Console.WriteLine("No contacts available.");
                        }
                        else
                        {
                            Console.WriteLine("\n--- All Contacts ---");
                            for (int i = 0; i < count; i++)
                            {
                                Console.WriteLine(names[i] + " - " + phones[i]);
                            }
                        }
                        break;

                    case 4:
                        
                        isRunning = false;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}