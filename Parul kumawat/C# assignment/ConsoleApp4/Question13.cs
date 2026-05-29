using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question13
    {
        public Question13() {

            int n = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= n; i++)
                {
                    for (int s = 1; s <= n - i; s++)
                    {
                        Console.Write(" ");
                    }

                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write(j);
                    }

                    for (int j = i - 1; j >= 1; j--)
                    {
                        Console.Write(j);
                    }

                    Console.WriteLine();
                }
            }
        }




    }
  