using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ET.FakeText;

namespace SetOfWords
{
    // 03. Write a program that finds a set of words(e.g. 1000 words) in a large text(e.g. 100 MB text file).
    // Print how many times each word occurs in the text.

    public class Startup
    {
        public static void Main()
        {
            // Library from NuGet Packages 
            TextGenerator generator = new TextGenerator(WordTypes.Name);

            string names = generator.GenerateText(1000);
            Trie trie = new Trie();
            HashSet<string> words = new HashSet<string>();

            names.Split(' ').ToList().ForEach(
                x =>
                {
                    words.Add(x);
                    trie.AddWord(x);
                });

            var result = new StringBuilder();

            foreach (var word in words.OrderBy(x => x))
            {
                int occurenceCount;
                trie.TryFindWord(word, out occurenceCount);
                result.AppendFormat("{0} -> {1} times", word, occurenceCount).AppendLine();
            }

            Console.WriteLine(result);

            Console.WriteLine("Number of words: " + words.Count);
        }
    }
}
