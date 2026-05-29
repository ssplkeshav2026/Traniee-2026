using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question21
    {
        bool keepRun = true;

        public Question21()
        {
            Dictionary<string, string> contactBook = new Dictionary<string, string>();


            while (keepRun)
            {
                Console.WriteLine(" Menu ");
                Console.WriteLine("1 = Add");
                Console.WriteLine("2 = Search");
                Console.WriteLine("3 = Display All Details");
                Console.WriteLine("4 = Exit");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter name : ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter phone number : ");
                        string phoneNumber = Console.ReadLine();
                        contactBook.Add(name, phoneNumber);
                        Console.WriteLine("Added successfully");
                        break;

                    case 2:
                        Console.Write("Enter name to search: ");
                        string search = Console.ReadLine();
                        if (contactBook.ContainsKey(search))
                        {
                            Console.WriteLine($"Name: {search}, Phone: {contactBook[search]}");
                        }
                        else
                        {
                            Console.WriteLine("Contact not found!");

                        }
                        break;


                    case 3:

                        if (contactBook.Count == 0)
                        {
                            Console.WriteLine("No contacts available");
                        }
                        else
                        {
                            foreach (var data in contactBook)


                                Console.WriteLine($"Name: {data.Key}, Phone: {data.Value}");
                        }
                        break;

                    case 4:
                        keepRun = false;
                        Console.WriteLine("exit");
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;



                }
            }
        }
    }
}
