using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question21
    {
        public Question21()
        {
            string[] names = new string[20];
            string[] phones = new string[10];

            int count = 0;

            while (true)
            {
                Console.WriteLine("Add Contact");
                Console.WriteLine("Search Contact");
                Console.WriteLine("Show All Contacts");
                Console.WriteLine("Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                // ADD CONTACT
                if (choice == "1")
                {
                    Console.Write("Name: ");
                    names[count] = Console.ReadLine();

                    Console.Write("Phone: ");
                    phones[count] = Console.ReadLine();

                    count++;
                    Console.WriteLine("Contact saved!");
                }

                // SEARCH CONTACT
                else if (choice == "2")
                {
                    Console.Write("Enter name: ");
                    string search = Console.ReadLine();

                    bool found = false;

                    for (int i = 0; i < count; i++)
                    {
                        if (names[i].ToLower() == search.ToLower())
                        {
                            Console.WriteLine("Found: " + names[i] + " - " + phones[i]);
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Not found!");
                    }
                }

                // SHOW ALL
                else if (choice == "3")
                {
                    if (count == 0)
                    {
                        Console.WriteLine("No contacts yet.");
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + names[i] + " - " + phones[i]);
                        }
                    }
                }

                // EXIT
                else if (choice == "4")
                {
                    Console.WriteLine("Bye!");
                    break;
                }

                else
                {
                    Console.WriteLine("Wrong choice!");
                }
            }
        }
    }
}