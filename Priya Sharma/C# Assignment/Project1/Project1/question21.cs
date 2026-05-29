using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question21
    {
        public question21()
        {
                string[] names = new string[10];
                string[] phones = new string[10];
                int count = 0;

                int choice;

                do
                {
                    Console.WriteLine("\nContact Book :-");
                    Console.WriteLine("1. Add");
                    Console.WriteLine("2. Search");
                    Console.WriteLine("3. Show All");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter choice: ");

                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.Write("Please enter name: ");
                        names[count] = Console.ReadLine();

                        Console.Write("Please enter phone: ");
                        phones[count] = Console.ReadLine();

                        count++;
                    }
                    else if (choice == 2)
                    {
                        Console.Write("Tell me the name you wanna search: ");
                        string search = Console.ReadLine();

                        bool found = false;

                        for (int i = 0; i < count; i++)
                        {
                            if (names[i] == search)
                            {
                                Console.WriteLine("Found: " + names[i] + " - " + phones[i]);
                                found = true;
                            }
                        }

                        if (found == false)
                        {
                            Console.WriteLine("Not found");
                        }
                    }
                    else if (choice == 3)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine(names[i] + " - " + phones[i]);
                        }
                    }

                } while (choice != 4);
            
        }

    }
    
}
