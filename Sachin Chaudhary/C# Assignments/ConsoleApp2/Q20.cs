using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace ConsoleApp2
{
    internal class Q20
    {
        public Q20()
        {


     
                Console.WriteLine("Enter a sentence:");
                string sen = Console.ReadLine();

                    string[] words = sen.Split(' ');

                int wordCount = words.Length;

               
                    int countWithSpaces = sen.Length;
                int countWithoutSpaces = 0;

            
                for (int i = 0; i < words.Length; i++)
                {
                        countWithoutSpaces += words[i].Length;
                }

               
                string longestWord = "";
                     for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > longestWord.Length)
                       {
                        longestWord = words[i];
                      }
                }

              
                string reverse = "";
               
                     for (int i = words.Length - 1; i >= 0; i--)
                {
                    reverse += words[i] + " ";
                }

              
                   Console.WriteLine("--- Analysis Results ---");
                Console.WriteLine("Word count: " + wordCount);
                Console.WriteLine("Total characters (with spaces): " + countWithSpaces);
                   Console.WriteLine("Total characters (no spaces): " + countWithoutSpaces);
                Console.WriteLine("Longest word: " + longestWord);
                  Console.WriteLine("Reversed sentence: " + reverse.Trim());
            }
        }

    }



