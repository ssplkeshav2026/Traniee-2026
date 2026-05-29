using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question20
    {
        public question20()
        {
                Console.Write("Enter a sentence: ");
                string sentence = Console.ReadLine(); 

                string[] words = sentence.Split(' ');
                Console.WriteLine("Total Words (Count): " + words.Length); // Count the Words


                Console.WriteLine("Number of Characters (with spaces): " + sentence.Length); // length with spaces


                int countWithoutSpaces = 0;
                foreach (char ch in sentence)
                {
                    if (ch != ' ')
                        countWithoutSpaces++;
                }
                Console.WriteLine(" Number of Characters (without spaces): " + countWithoutSpaces); // length without spaces


                string longest = "";
                foreach (string word in words)
                {
                    if (word.Length > longest.Length)
                        longest = word;
                }
                Console.WriteLine("Longest word in Sentence: " + longest); // Longest Word


                string reversed = "";
                for (int i = sentence.Length - 1; i >= 0; i--)
                {
                    reversed += sentence[i];
                }
                Console.WriteLine("Reversed Sentence: " + reversed); // Reversed 
            
        }
    }
}
