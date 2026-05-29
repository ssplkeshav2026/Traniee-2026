using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Question20
    {
        public Question20()
        {
            Console.WriteLine("Enter a sentence:");
            string sentence = Console.ReadLine();

            // Split words
            string[] words = sentence.Split(' ');

            int wordCount = 0;
            string longestWord = "";

            foreach (string word in words)
            {
                if (word != "")
                {
                    wordCount++;

                    if (word.Length > longestWord.Length)
                    {
                        longestWord = word;
                    }
                }
            }

            // Character counts
            int charWithSpaces = sentence.Length;

            int charWithoutSpaces = 0;
            foreach (char c in sentence)
            {
                if (c != ' ')
                {
                    charWithoutSpaces++;
                }
            }

            // Reverse sentence
            string reversed = "";
            for (int i = sentence.Length - 1; i >= 0; i--)
            {
                reversed = reversed + sentence[i];
            }

            Console.WriteLine("Word count: " + wordCount);
            Console.WriteLine("With Spaces: " + charWithSpaces);
            Console.WriteLine("Without Spaces: " + charWithoutSpaces);
            Console.WriteLine("Longest Word: " + longestWord);
            Console.WriteLine("Reversed Sentence: " + reversed);
        }
    }
}