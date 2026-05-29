using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question20
    {
        public Question20()
        {
            characterCount();
            wordCount();
        }

        static void characterCount()
        {
            Console.WriteLine("enter any word :");

            string word = Console.ReadLine();
            int count = 0;
            char[] arr;
            arr = word.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                count++;
            }
            Console.WriteLine("total character count :" + count);
        }


        static void wordCount()
        {

            Console.WriteLine("enter a sentence :");
            string word = Console.ReadLine();
            string afterTrim = word.Trim();
            string[] arr = afterTrim.Split(' ');
            int wordCount = 0;
            string longestWord = "";

            foreach (string words in arr)
            {
                if (words == " ")
                {
                    continue;
                }
                else
                {
                    wordCount++;
                }

                if (words.Length > longestWord.Length)
                {
                    longestWord = words;
                }


            }
            
            Console.WriteLine("total Words count : " + wordCount);

            Console.WriteLine("longest word in this sentence : " + longestWord);


            Console.Write("reversed sentence : ");

            for (int i = arr.Length - 1; i >=0; i--)
            {
                Console.Write(arr[i]+" ");
            }

        }


        
    }
}
