using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question3
    {
        bool keepRun = true;
        public Question3()
        {
            while (keepRun)
            {
                Console.WriteLine(" Calculator Menu ");
                Console.WriteLine("+ = Addition");
                Console.WriteLine("- = Subtract");
                Console.WriteLine("* = Multiplication");
                Console.WriteLine("/ = Division");
                Console.WriteLine("e : Exit");
                Console.Write("Select an option: ");

                string option = Console.ReadLine().ToLower();

                if (option == "e")
                {
                    keepRun = false;
                    return;
                }
                if (option != "+" && option != "-" && option != "*" && option != "/")
                {
                    Console.WriteLine("Please choose correct option");
                    continue;
                }

                Console.WriteLine("enter first number");
                double n1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("enter second number");
                double n2 = Convert.ToDouble(Console.ReadLine());

                double res = 0;

                switch (option)
                {
                    case "+": res = n1 + n2; break;
                    case "-": res = n1 - n2; break;
                    case "*": res = n1 * n2; break;
                    case "/":
                        if (n2 != 0)
                        {
                            res = n1 / n2;
                        }
                        break;



                }
                Console.WriteLine($"The result is : {res}");

            }
        }
    }
}
