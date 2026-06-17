using System;
using System.Collections.Generic;

namespace Assignment1
{
    internal class LibraryItem
    {
        public string TITLE;
        public int ID;
        public bool ISAVAILABLE;

        public LibraryItem(string title, int id, bool isAvailable)
        {
            TITLE = title;
            ID = id;
            ISAVAILABLE = isAvailable;
        }

        public void Borrow()
        {
            if (ISAVAILABLE)
            {
                ISAVAILABLE = false;
                Console.WriteLine("Item borrowed successfully.");
            }
            else
            {
                Console.WriteLine("Item is already borrowed.");
            }
        }

        public void ReturnItem()
        {
            if (!ISAVAILABLE)
            {
                ISAVAILABLE = true;
                Console.WriteLine("Item returned successfully.");
            }
            else
            {
                Console.WriteLine("Item is already available.");
            }
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine("Title: " + TITLE);
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Is Available: " + ISAVAILABLE);
        }
    }

    class Book : LibraryItem
    {
        string AUTHOR;
        string ISBN;

        public Book(string title, int id, bool isAvailable, string author, string isbn)
            : base(title, id, isAvailable)
        {
            AUTHOR = author;
            ISBN = isbn;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("Author: " + AUTHOR);
            Console.WriteLine("ISBN: " + ISBN);
        }
    }

    class Magazine : LibraryItem
    {
        int ISSUENUMBER;

        public Magazine(string title, int id, bool isAvailable, int issueNumber)
            : base(title, id, isAvailable)
        {
            ISSUENUMBER = issueNumber;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("Issue Number: " + ISSUENUMBER);
        }
    }

    class DVD : LibraryItem
    {
        int DURATION;

        public DVD(string title, int id, bool isAvailable, int duration)
            : base(title, id, isAvailable)
        {
            DURATION = duration;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("Duration: " + DURATION + " minutes");
        }
    }

    class LibrarySystem
    {
        public LibrarySystem()
        {
            List<LibraryItem> items = new List<LibraryItem>();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n--- Library Menu ---");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Magazine");
                Console.WriteLine("3. Add DVD");
                Console.WriteLine("4. Borrow Item");
                Console.WriteLine("5. Return Item");
                Console.WriteLine("6. Search Item");
                Console.WriteLine("7. Display All Items");
                Console.WriteLine("8. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();

                        Console.Write("Enter ISBN: ");
                        string isbn = Console.ReadLine();

                        items.Add(new Book(title, id, true, author, isbn));
                        Console.WriteLine("Book added successfully.");
                        break;

                    case 2:
                        Console.Write("Enter Title: ");
                        string mTitle = Console.ReadLine();

                        Console.Write("Enter ID: ");
                        int mId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Issue Number: ");
                        int issue = int.Parse(Console.ReadLine());

                        items.Add(new Magazine(mTitle, mId, true, issue));
                        Console.WriteLine("Magazine added successfully.");
                        break;

                    case 3:
                        Console.Write("Enter Title: ");
                        string dTitle = Console.ReadLine();

                        Console.Write("Enter ID: ");
                        int dId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Duration: ");
                        int duration = int.Parse(Console.ReadLine());

                        items.Add(new DVD(dTitle, dId, true, duration));
                        Console.WriteLine("DVD added successfully.");
                        break;

                    case 4:
                        Console.Write("Enter ID to borrow: ");
                        int borrowId = int.Parse(Console.ReadLine());

                        LibraryItem borrowItem = null;

                        foreach (LibraryItem item in items)
                        {
                            if (item.ID == borrowId)
                            {
                                borrowItem = item;
                                break;
                            }
                        }

                        if (borrowItem != null)
                            borrowItem.Borrow();
                        else
                            Console.WriteLine("Item not found.");

                        break;

                    case 5:
                        Console.Write("Enter ID to return: ");
                        int returnId = int.Parse(Console.ReadLine());

                        LibraryItem returnItem = null;

                        foreach (LibraryItem item in items)
                        {
                            if (item.ID == returnId)
                            {
                                returnItem = item;
                                break;
                            }
                        }

                        if (returnItem != null)
                            returnItem.ReturnItem();
                        else
                            Console.WriteLine("Item not found.");

                        break;

                    case 6:
                        Console.Write("Enter ID to search: ");
                        int searchId = int.Parse(Console.ReadLine());

                        LibraryItem searchItem = null;

                        foreach (LibraryItem item in items)
                        {
                            if (item.ID == searchId)
                            {
                                searchItem = item;
                                break;
                            }
                        }

                        if (searchItem != null)
                            searchItem.DisplayDetails();
                        else
                            Console.WriteLine("Item not found.");

                        break;

                    case 7:
                        if (items.Count == 0)
                        {
                            Console.WriteLine("No items available.");
                        }
                        else
                        {
                            foreach (LibraryItem item in items)
                            {
                                item.DisplayDetails();
                                Console.WriteLine("-------------------");
                            }
                        }
                        break;

                    case 8:
                        isRunning = false;
                        Console.WriteLine("Program closed.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}