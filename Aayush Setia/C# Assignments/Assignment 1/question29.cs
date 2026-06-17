using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question29
    { 
        class LibraryItem
        {
            public string Title;
            public int ID;
            public bool IsAvailable;

            public LibraryItem(string title, int id)
            {
                Title = title;
                ID = id;
                IsAvailable = true;
            }

            public virtual void Display()
            {
                Console.WriteLine("ID: " + ID);
                Console.WriteLine("Title: " + Title);
                Console.WriteLine("Available: " + IsAvailable);
            }
        }

       
        class Book : LibraryItem
        {
            public string Author;
            public string ISBN;

            public Book(string t, int id, string a, string isbn)
                : base(t, id)
            {
                Author = a;
                ISBN = isbn;
            }

            public override void Display()
            {
                base.Display();
                Console.WriteLine("Author: " + Author);
                Console.WriteLine("ISBN: " + ISBN);
            }
        }

       
        class Magazine : LibraryItem
        {
            public int IssueNumber;

            public Magazine(string t, int id, int issue)
                : base(t, id)
            {
                IssueNumber = issue;
            }

            public override void Display()
            {
                base.Display();
                Console.WriteLine("Issue No: " + IssueNumber);
            }
        }

        class DVD : LibraryItem
        {
            public int Duration;

            public DVD(string t, int id, int duration)
                : base(t, id)
            {
                Duration = duration;
            }

            public override void Display()
            {
                base.Display();
                Console.WriteLine("Duration: " + Duration + " mins");
            }
        }

        public question29()
        {
            List<LibraryItem> items = new List<LibraryItem>();
            int choice;

            do
            {
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Borrow Item");
                Console.WriteLine("3. Return Item");
                Console.WriteLine("4. Search Item");
                Console.WriteLine("5. Display All");
                Console.WriteLine("6. Exit");

                Console.Write("Enter Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                LibraryItem item = null;

                if (choice >= 2 && choice <= 4)
                {
                    Console.Write("Enter ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    item = items.Find(i => i.ID == id);

                    if (item == null)
                    {
                        Console.WriteLine("Item not found!");
                        continue;
                    }
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1. Book  2. Magazine  3. DVD");
                        int type = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter ID: ");
                        int newId = Convert.ToInt32(Console.ReadLine());

                        if (type == 1)
                        {
                            Console.Write("Enter Author: ");
                            string author = Console.ReadLine();

                            Console.Write("Enter ISBN: ");
                            string isbn = Console.ReadLine();

                            items.Add(new Book(title, newId, author, isbn));
                        }
                        else if (type == 2)
                        {
                            Console.Write("Enter Issue Number: ");
                            int issue = Convert.ToInt32(Console.ReadLine());

                            items.Add(new Magazine(title, newId, issue));
                        }
                        else if (type == 3)
                        {
                            Console.Write("Enter Duration: ");
                            int dur = Convert.ToInt32(Console.ReadLine());

                            items.Add(new DVD(title, newId, dur));
                        }

                        Console.WriteLine("Item Added!");
                        break;

                    case 2:
                        if (item.IsAvailable)
                        {
                            item.IsAvailable = false;
                            Console.WriteLine("Item Borrowed!");
                        }
                        else
                        {
                            Console.WriteLine("Already Borrowed!");
                        }
                        break;

                    case 3:
                        item.IsAvailable = true;
                        Console.WriteLine("Item Returned!");
                        break;

                    case 4:
                        Console.WriteLine("\n--- Item Found ---");
                        item.Display();
                        break;

                    case 5:
                        foreach (var i in items)
                        {
                            Console.WriteLine("\n--- Item ---");
                            i.Display();
                        }
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