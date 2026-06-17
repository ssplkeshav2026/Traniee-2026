using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ConsoleApp2
{
    internal class Q21
    {
        public Q21()
        {

          
            List<string> names = new List<string>();
            List<string> numbers = new List<string>();
            bool start = true;
            while (start)
            {
                Console.WriteLine("----Contact book----");
                Console.WriteLine("1.add");
                Console.WriteLine("2.search");
                Console.WriteLine("3.Display all ");
                Console.WriteLine("4.Exit");
                int Choice=Convert.ToInt32(Console.ReadLine());


                switch (Choice)
                {
                    case 1:
                    
                        Console.Write("Enter Name: ");
                        names.Add(Console.ReadLine());
                        Console.Write("Enter Phone Number: ");
                        numbers.Add(Console.ReadLine());
                        Console.WriteLine("Contact added!");
                        break;


                    case 2:
                        Console.WriteLine("enter the name you want to search");
                        String searchname= Console.ReadLine();
                        int index=names.IndexOf(searchname);
                        if(index != -1)
                        {

                            Console.WriteLine($"found {names[index]}-Contects{numbers[index]}");
                        }
                        else
                        {
                            Console.WriteLine("index not found");
                        }

                        break;
                    case 3:
                        Console.WriteLine("All Contacts");
          
                        for (int i = 0; i < names.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {names[i]}: {numbers[i]}");
                        }
                        break;
                    case 4:
                       start= false;
                        Console.WriteLine("bye");
                        break;
                }

            }
         
        }
    }
}
