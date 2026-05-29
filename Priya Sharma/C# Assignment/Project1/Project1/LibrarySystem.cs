using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    abstract class LibraryItem
    {
        public int Id;
        public string Title;
        public bool IsAvailable = true;

        public LibraryItem(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public abstract void Display();
    }

    class Book : LibraryItem
    {
        public string Author;
        public string ISBN;

        public Book(int id, string title, string author, string isbn)
            : base(id, title)
        {
            Author = author;
            ISBN = isbn;
        }

        public override void Display()
        {
            Console.WriteLine($"[Book] ID: {Id}, Title: {Title}, Available: {IsAvailable}");
            Console.WriteLine($"Author: {Author}, ISBN: {ISBN}");
        }
    }

    class Magazine : LibraryItem
    {
        public int IssueNumber;

        public Magazine(int id, string title, int issueNumber)
            : base(id, title)
        {
            IssueNumber = issueNumber;
        }

        public override void Display()
        {
            Console.WriteLine($"[Magazine] ID: {Id}, Title: {Title}, Available: {IsAvailable}");
            Console.WriteLine("Issue number: "+ IssueNumber);
        }
    }

    class DVD : LibraryItem
    {
        public int Duration;

        public DVD(int id, string title, int duration)
            : base(id, title)
        {
            Duration = duration;
        }

        public override void Display()
        {
            Console.WriteLine($"[DVD] ID: {Id}, Title: {Title}, Available: {IsAvailable}");
            Console.WriteLine($"Duration: {Duration} Hours");
        }
    }
    public class LibrarySystem
    {
        public void Show1()
        {
            List<LibraryItem> items = new List<LibraryItem>();

            while (true)
            {
                Console.WriteLine("\nLibrary System");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Display All");
                Console.WriteLine("3. Borrow Item");
                Console.WriteLine("4. Return Item");
                Console.WriteLine("5. Search Item");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("1. Book  2. Magazine  3. DVD");
                    int type = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine();

                    if (type == 1)
                    {
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();

                        Console.Write("Enter ISBN: ");
                        string isbn = Console.ReadLine();

                        items.Add(new Book(id, title, author, isbn));
                    }
                    else if (type == 2)
                    {
                        Console.Write("Enter Issue Number: ");
                        int issue = Convert.ToInt32(Console.ReadLine());

                        items.Add(new Magazine(id, title, issue));
                    }
                    else if (type == 3)
                    {
                        Console.Write("Enter Duration: ");
                        int duration = Convert.ToInt32(Console.ReadLine());

                        items.Add(new DVD(id, title, duration));
                    }
                }
                else if (choice == 2)
                {
                    foreach (var item in items)
                    {
                        item.Display();
                        Console.WriteLine();
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Enter Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    var item = items.Find(i => i.Id == id);

                    if (item != null && item.IsAvailable)
                    {
                        item.IsAvailable = false;
                        Console.WriteLine("Item borrowed.");
                    }
                    else
                    {
                        Console.WriteLine("Item not available.");
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Enter Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    var item = items.Find(i => i.Id == id);

                    if (item != null)
                    {
                        item.IsAvailable = true;
                        Console.WriteLine("Item returned.");
                    }
                }
                else if (choice == 5)
                {
                    Console.Write("Enter Title to search: ");
                    string search = Console.ReadLine();

                    var results = items.FindAll(i => i.Title.ToLower().Contains(search.ToLower()));


                    foreach (var item in results)
                    {
                        item.Display();
                        Console.WriteLine();
                    }
                }
                else if (choice == 6)
                {
                    break;
                }
            }
        }
    }
}