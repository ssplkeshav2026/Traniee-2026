using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//20.Write a program that takes a sentence and displays:
//Word count
//Character count (with and without spaces)
//Longest word
//Reversed sentence
using System;

namespace Assignment1
{
    internal class Question20
    {
        public Question20()
        {
            Console.WriteLine("Enter a Sentence ");
            string sen = Console.ReadLine();

       
            string[] words = sen.Split(' ');

            
            int wordCount = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != "")   
                {
                    wordCount++;
                }
            }


            int charWithSpaces = sen.Length;

            int charWithoutSpaces = 0;
            for (int i = 0; i < sen.Length; i++)
            {
                if (sen[i] != ' ')
                {
                    charWithoutSpaces++;
                }
            }

            
            string longestWord = "";
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > longestWord.Length)
                {
                    longestWord = words[i];
                }
            }

          
            string reversed = "";
            for (int i = sen.Length - 1; i >= 0; i--)
            {
                reversed += sen[i];
            }

  
            Console.WriteLine("Word Count: " + wordCount);
            Console.WriteLine("Character Count (with spaces): " + charWithSpaces);
            Console.WriteLine("Character Count (without spaces): " + charWithoutSpaces);
            Console.WriteLine("Longest Word: " + longestWord);
            Console.WriteLine("Reversed Sentence: " + reversed);
        }
    }
}
