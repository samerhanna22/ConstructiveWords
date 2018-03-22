using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConstructiveWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"TestFiles\wordlist.txt";
            List<string> words = File.ReadAllLines(path).ToList();


            // List<string> words = new List<string>()
            //{
            //    "cat", "cats", "catsdogcats", "catxdogcatsrat", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat"
            //};

            List<string> constructiveWords = new List<string>();

            foreach (string wordItem in words)
            {
                //check the word with the rest of words
                var word = wordItem;
                int l = word.Length - 1;

                while (l > 0 && !String.IsNullOrWhiteSpace(word))
                {
                    foreach (string subWord in words.FindAll(w => w.Length == l && word.Contains(w)))
                    {
                        if (!String.IsNullOrWhiteSpace(subWord))
                        {
                            while (word.IndexOf(subWord) > -1)
                            {
                                word = word.Remove(word.IndexOf(subWord), subWord.Length);
                            }

                        }
                    }

                    l -= 1;

                }

                if (String.IsNullOrWhiteSpace(word))
                    constructiveWords.Add(wordItem);

            }

            string longestWord = constructiveWords.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
            Console.WriteLine("Longest word is: " + longestWord);
            Console.WriteLine("number of words : " + constructiveWords.Count);

            // furthermore, if we like to preview words that can be constructe from other list words, uncomment this ...
            // Console.WriteLine( String.Join<string>(",", constructiveWords.ToArray()));


            Console.ReadLine();
        }
    }
}
