using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question20
    {
        public question20()
        {
            string s, revs=" ";
            Console.Write("Enter the sentance ");
            s = Console.ReadLine();

            int charcount = s.Length;

            string[] words = s.Split(' ');
            int wordcount= words.Length;

            string longest = words[0];
            for(int i = 1; i < wordcount; i++)
            {
                if(words[i].Length > longest.Length)
                {
                    longest = words[i];
                } 
            }
            for(int i = s.Length - 1; i >= 0; i--)
            {
                revs = revs + s[i];
            }
            Console.WriteLine(wordcount);
            Console.WriteLine(longest);
            Console.WriteLine(charcount);
            Console.WriteLine(revs);
        }
        
    }
}
