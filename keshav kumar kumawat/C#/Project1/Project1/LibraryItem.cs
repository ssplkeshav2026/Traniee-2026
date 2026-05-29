using Project1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class LibraryItem
    {
        public string Title {  get; set; }
        public string ID {  get; set; }

        public bool IsAvailable { get; set; }
        public LibraryItem(string title, string id)
        {
            Title = title;
            ID = id;
            IsAvailable = true;
        }

        public virtual void Display()
        {
            string status = IsAvailable ? "Available" : "Borrowed";
            Console.WriteLine($"[{this.GetType().Name}] ID: {ID} | Title: {Title} | Status: {status}");
        }

        public void finalCode()
        {
            LibraryItem l = new LibraryItem("C# Basics", "DD01");


            List<LibraryItem> library = new List<LibraryItem>();

            while (true)
            {
                Console.WriteLine("\n--- Library Menu ---");
                Console.WriteLine("1. Add Book  2. Borrow  3. Return  4. Search  5. Display All  6. Exit");
                Console.Write("Choose Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.Add(new Book("C# Basics", "B01", "keshav", "123"));
                        Console.WriteLine("Book is added");
                        break;

                    case "2":
                        Console.Write("Enter ID: ");
                        string bid = Console.ReadLine();

                        var bItem = library.FirstOrDefault(i => i.ID == bid && i.IsAvailable);

                        if (bItem != null)
                        {
                            bItem.IsAvailable = false;
                            Console.WriteLine("Book borrowed!");
                        }
                        else
                        {
                            Console.WriteLine("Not available or not found!");
                        }
                        break;

                    case "3":
                        Console.Write("Enter ID:");
                        string rid = Console.ReadLine();

                        var rItem = library.FirstOrDefault(i => i.ID == rid);

                        if (rItem != null)
                        {
                            rItem.IsAvailable = true;
                            Console.WriteLine("Returned!");
                        }
                        else
                        {
                            Console.WriteLine("Item not found!");
                        }
                        break;

                    case "4":
                        Console.Write("Search Title:");
                        string query = Console.ReadLine().ToLower();

                        var results = library.Where(i => i.Title.ToLower().Contains(query));

                        foreach (var res in results)
                            res.Display();
                        break;

                    case "5":
                        library.ForEach(i => i.Display());
                        break;

                    case "6":
                        return;
                }

            }
        }
    }
   public class Book : LibraryItem
    {
        public string Author {  get; set; }

        public string ISBN {  get; set; }

        public Book(string title, string id,string author,string isbn) : base(title, id)
        {
            Author = author;
            ISBN=isbn;
        }
    }
    public class Magazine : LibraryItem
    {
        public string IssueNumber { get; set; }
        public Magazine(string title, string id, string issueNum) : base(title, id)
        { 
            IssueNumber = issueNum; 
        }
    }

    public class DVD : LibraryItem
    {
        public string Duration { get; set; }
        public DVD(string title, string id, string duration) : base(title, id)
        { 
            Duration = duration;
        }
    }
}



