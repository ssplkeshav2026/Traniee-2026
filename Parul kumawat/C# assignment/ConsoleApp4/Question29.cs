using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class LibraryItem
    {
        public string title;
        public int ID;
        public bool IsAvailable;

        public LibraryItem(string t, int id, bool isAvailable) {
            this.title = t;
            this.ID = id;
            this.IsAvailable = isAvailable;


        }

    }
    public class Book : LibraryItem
    {
        public string Author;
        public int ISBN;
        public Book(string t, int id, bool isAvailable, string author, int iSBN) : base(t, id, isAvailable)
        {
            Author = author;
            ISBN = iSBN;

        }

    }
    public class Magazine : LibraryItem
    {
        public int IssueNumber;
        public Magazine(string t, int id, bool isAvailable, int issueNumber) : base(t, id, isAvailable) {

            IssueNumber = issueNumber;


        }
    }
    public class DVD : LibraryItem
    {
        public int Duration;
        public DVD(string t, int id, bool isAvailable, int duration) : base(t, id, isAvailable)
        {

            Duration = duration;


        }
    }

    public class Question29
    {
        bool keepRun = true;
        static List<LibraryItem> items = new List<LibraryItem>();
        public Question29() {
            while (keepRun)
            {
                Console.WriteLine(" Menu ");
                Console.WriteLine("1 = Add items");
                Console.WriteLine("2 = Borrow");
                Console.WriteLine("3 = Return");
                Console.WriteLine("4 = Search");
                Console.WriteLine("5 = Display All");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());


                switch (option)
                {
                    case 1:
                        addBook();
                        break;

                    case 2:
                        borrowBook();
                        break;

                    case 3:
                        returnBook();
                        break;

                    case 4:
                        search();
                        break;

                    case 5:
                        displayAll();
                        break;
                }
            }
        }
        static void addBook()
        {
            Console.WriteLine("Enter book title:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter book ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Is book available (true/false):");
            bool isAvailable = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Enter book author:");
            string author = Console.ReadLine();

            Console.WriteLine("Enter book ISBN:");
            int isbn = Convert.ToInt32(Console.ReadLine());

            Book b = new Book(title, id, isAvailable, author, isbn);
            items.Add(b);

            Console.WriteLine("Book added successfully!");

        }

        static void borrowBook()
        {
            Console.WriteLine("Enter book ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            LibraryItem item = null;
            foreach (LibraryItem li in items)
            {
                if (li.ID == id)
                {
                    item = li;
                    break;
                }

            }
            if (item == null)
            {
                Console.WriteLine("Book not found");
            }
            else if (!item.IsAvailable)
            {
                Console.WriteLine("Book already borrowed");
            }
            else
            {
                item.IsAvailable = false;
                Console.WriteLine("Book borrowed successfully");
            }


        }
        static void returnBook()
        {
            Console.WriteLine("Enter book ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            LibraryItem item = null;
            foreach (LibraryItem li in items)
            {
                if (li.ID == id)
                {
                    item = li;
                    break;
                }
            }
            if (item == null)
            {
                Console.WriteLine("Book not found");
            }
            else if (item.IsAvailable)
            {
                Console.WriteLine("Book is already returned");
            }
            else
            {
                item.IsAvailable = true;
                Console.WriteLine("Book returned successfully");
            }

        }


        static void search()
        {
            Console.WriteLine("Enter book ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            LibraryItem item = null;
            foreach (LibraryItem li in items)
            {
                if (li.ID == id)
                {
                    item = li;
                    break;
                }
            }
            if (item == null)
            {
                Console.WriteLine("item not found");
            }
            else
            {
                Console.WriteLine("Item Details:");
                Console.WriteLine($"Title : {item.title}");
                Console.WriteLine($"ID : {item.ID}");
                Console.WriteLine($"Available : {item.IsAvailable}");

                if (!item.IsAvailable)
                {
                    Console.WriteLine("Status: Borrowed");
                }
                else
                {
                    Console.WriteLine("Status: Available");
                }
            }
        }
        
        static void displayAll()
        {
                if(items.Count == 0)
            {
                Console.WriteLine("No items available");
                return;
            }
            foreach (LibraryItem item in items)
            {
                Console.WriteLine("Items lists : ");
                Console.WriteLine($"Title: {item.title}");
                Console.WriteLine($"ID: {item.ID}");
                Console.WriteLine($"Available: {item.IsAvailable}");
            }
        }
    }
}

