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

            //lets start by sorting words
            Stack<string> words = new Stack<string>(File.ReadAllLines(path).OrderBy(w => w.Length));

                       
            // from the first item, which is the longest, loop through the rest to find out if it is can be constructed completely by other words
            // if not, move to the next item, which is the second longest.
            // print the first valid item, continue to the end to count all possible words that meet the criteria

            string LongestConstructiveWord = "";
            int totalConstructiveWords = 0;
            int minLength = words.Last().Length; // we keep this because words or size less than double min length will not be constructable 


            while (words.Any())
            {
                string wordItem = words.Pop();


                // skip words of less than double minimmum length word
                if (wordItem.Length >= minLength *2)
                {

                    string word = wordItem;

                    foreach (string subWord in words)
                    {
                        // skip subWord if its length > wordItem.length - minLength
                        if (subWord.Length > wordItem.Length - minLength ) continue;
                        

                        while (word != "" && word.IndexOf(subWord) > -1)
                        {
                            word = word.Remove(word.IndexOf(subWord), subWord.Length);
                        }

                        if (word == "") break; // already done, no need to iterate the rest
                    }

                    if (String.IsNullOrWhiteSpace(word))
                    {
                        if (LongestConstructiveWord == "") LongestConstructiveWord = wordItem;
                        totalConstructiveWords += 1;
                    }
                }


            }
            

            Console.WriteLine("Longest word is: " + LongestConstructiveWord);
            Console.WriteLine("number of words : " + totalConstructiveWords);

            // furthermore, if we like to preview words that can be constructe from other list words, uncomment this ...
            // Console.WriteLine( String.Join<string>(",", constructiveWords.ToArray()));


            Console.ReadLine();
        }

        
    }

   
}
