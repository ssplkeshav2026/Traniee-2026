//using System;
//using System.Collections.Generic;
//using System.Linq;


//public class LibraryItem
//{
//    public string Title { get; set; }
//    public string ID { get; set; }
//    public bool IsAvailable { get; set; } = true;

//    public LibraryItem(string title, string id)
//    {
//        Title = title;
//        ID = id;
//    }

//    public virtual void DisplayInfo()
//    {
//        string status = IsAvailable ? "Available" : "Borrowed";
//        Console.WriteLine($"[{ID}] {Title} ({this.GetType().Name}) - Status: {status}");
//    }
//}

//public class Book : LibraryItem
//{
//    public string Author { get; set; }
//    public string ISBN { get; set; }
//    public Book(string title, string id, string author, string isbn) : base(title, id)
//    {
//        Author = author; ISBN = isbn;
//    }
//}

//public class Magazine : LibraryItem
//{
//    public int IssueNumber { get; set; }
//    public Magazine(string title, string id, int issueNum) : base(title, id)
//    {
//        IssueNumber = issueNum;
//    }
//}

//public class DVD : LibraryItem
//{
//    public string Duration { get; set; }
//    public DVD(string title, string id, string duration) : base(title, id)
//    {
//        Duration = duration;
//    }
//}

//class Program
//{
//    static List<LibraryItem> library = new List<LibraryItem>();

//    static void Main(String[] args)
//    {
//        while (true)
//        {
//            Console.WriteLine("\n--- Library Menu ---");
//            Console.WriteLine("1. Add Book  2. Borrow  3. Return  4. Search  5. Display All  6. Exit");
//            Console.Write("Chuno: ");
//            string choice = Console.ReadLine();

//            switch (choice)
//            {
//                case "1":
//                    library.Add(new Book("C# Basics", "B01", "sachin", "112233"));
//                    Console.WriteLine("Book add ho gayi!");
//                    break;
//                case "2":
//                    Console.Write("ID enter karein: ");
//                    var bItem = library.FirstOrDefault(i => i.ID == Console.ReadLine() && i.IsAvailable);
//                    if (bItem != null) { bItem.IsAvailable = false; Console.WriteLine("Borrowed!"); }
//                    else Console.WriteLine("N.");
//                    break;
//                case "3":
//                    Console.Write("ID enter karein: ");
//                    var rItem = library.FirstOrDefault(i => i.ID == Console.ReadLine());
//                    if (rItem != null) { rItem.IsAvailable = true; Console.WriteLine("Returned!"); }
//                    break;
//                case "4":
//                    Console.Write("Title search karein: ");
//                    string query = Console.ReadLine().ToLower();
//                    var results = library.Where(i => i.Title.ToLower().Contains(query));
//                    foreach (var res in results) res.DisplayInfo();
//                    break;
//                case "5":
//                    library.ForEach(i => i.DisplayInfo());
//                    break;
//                case "6": return;
//            }
//        }
//    }
//}
