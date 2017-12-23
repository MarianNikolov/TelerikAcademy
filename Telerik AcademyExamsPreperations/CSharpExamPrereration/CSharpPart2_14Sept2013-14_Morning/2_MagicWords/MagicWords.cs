using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MagicWords
{
    static void Main()
    {
        int lenghtOfSequence = int.Parse(Console.ReadLine());
        var words = new List<string>();

        for (int i = 0; i < lenghtOfSequence; i++)
        {
            words.Add(Console.ReadLine());
        }

        for (int i = 0; i < lenghtOfSequence; i++)
        {
            var word = words[i];
            int newIndex = word.Length % (lenghtOfSequence + 1);

            words[i] = null; // new

            words.Insert(newIndex, word);

            words.Remove(null);
          //  if (newIndex < i)
          //  {
          //      words.RemoveAt(i + 1);                
          //  }
          //  else
          //  {
          //      words.RemoveAt(i);                
          //  }
        }

        StringBuilder result = new StringBuilder();

        int longestWord = 0;
        foreach (var word in words)
        {
            longestWord = Math.Max(longestWord, word.Length);
        }

       // int longestWord = words[0].Length;
       // for (int i = 1; i < words.Count; i++)
       // {
       //     if (words[i].Length > longestWord)
       //     {
       //         longestWord = words[i].Length;
       //     }
       // }



        for (int i = 0; i < longestWord; i++)
        {
            for (int j = 0; j < words.Count; j++)
            {
                if (i < words[j].Length)  
                {
                    result.Append(words[j].ElementAt(i));
                }
            }
        }
        Console.WriteLine(result.ToString());

    }
}

