using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question18
    {
        public Question18()
        {


            while (true)
            {
                Console.WriteLine("Enter number for factorial :");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }

                int n = Convert.ToInt32(Console.ReadLine());


                if (n < 1)
                {
                    Console.WriteLine("Invalid");
                }
                else
                {
                    int factOfnum = Factorial(n);
                    Console.WriteLine("factorial of this number :" + factOfnum);

                }

            }

        }

        static int Factorial(int n)
        {
           
           
                int f = 1;
                for (int i = 1; i <= n; i++)
                {
                    f *= i;
                }
                return f;
            }
        }
    }

