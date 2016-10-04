using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExtractСentences
{
    static void Main()
    {
        string word = Console.ReadLine();
        string[] array = Console.ReadLine().Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> listForPrint = new List<string>(); 
        

        foreach (var sentences in array)
        {
            if (word.Length > sentences.Length)
            {
                continue;
            }


            // if sentences is == word
            if (sentences.Length == word.Length && sentences.Contains(word))
            {
                listForPrint.Add(sentences);
                continue;
            }


            // if word is in middle
            if (sentences.Contains(" " + word + " "))
            {
                listForPrint.Add(sentences);
                continue;
            }
            if (sentences.Contains(" " + word + ","))
            {
                listForPrint.Add(sentences);
                continue;
            }
            if (sentences.Contains(" " + word + "-"))
            {
                listForPrint.Add(sentences);
                continue;
            }
            if (sentences.Contains(" " + word + "!"))
            {
                listForPrint.Add(sentences);
                continue;
            }
            if (sentences.Contains(" " + word + "?"))
            {
                listForPrint.Add(sentences);
                continue;
            }
            if (sentences.Contains(" " + word + ":"))
            {
                listForPrint.Add(sentences);
                continue;
            }
            if (sentences.Contains(" " + word + "_"))
            {
                listForPrint.Add(sentences);
                continue;
            }
            if (sentences.Contains(" " + word + "#"))
            {
                listForPrint.Add(sentences);
                continue;
            }
            if (sentences.Contains(" " + word + "$"))
            {
                listForPrint.Add(sentences);
                continue;
            }
            if (sentences.Contains(" " + word + "*"))
            {
                listForPrint.Add(sentences);
                continue;
            }

            // if word is in last position
            if (sentences.Length > word.Length)
            {
                if (sentences.LastIndexOf(word) == sentences.Length - word.Length && sentences[sentences.Length - word.Length - 1] == ' ')
                {
                    listForPrint.Add(sentences);
                    continue;
                }
            }

            // if word starts from zero index
            if (sentences.Length > word.Length)
            {
                if (sentences.IndexOf(word) == 0 && sentences[word.Length] == ' ')
                {
                    listForPrint.Add(sentences);
                    continue;
                }
            }


        }
        for (int i = 0; i < listForPrint.Count; i++)
        {
            if (i == listForPrint.Count - 1)
            {
            Console.Write("{0}.", listForPrint[i]);
                
            }
            else
            {
                Console.Write("{0}.", listForPrint[i]);

            }
        }

    }
}




//       // proverka za nachaloto
//       for (int i = 0; i < word.Length; i++)
//       {
//           if (sentences[i] != word[i])
//           {
//               start = false;
//               break;
//           }
//       }
//       if (start && sentences[word.Length] == ' ')
//       {
//           listForPrint.Add(sentences);
//           continue;
//       }
//
//       // proverka za kraq
//     if (sentences.LastIndexOf(word) == sentences.Length - word.Length)
//     {
//         if (sentences[sentences.LastIndexOf(word) - 2] == ' ')
//         {
//         listForPrint.Add(sentences);
//         continue;
//         }
//     }
//
//
//       for (int i = 0; i < sentences.Length - word.Length; i++)
//       {
//           isWord = true;
//           for (int j = 0; j < word.Length; j++)
//           {
//               if (word[j] != sentences[i + j])
//               {
//                   isWord = false;
//                   break;
//               }
//           }
//           if (isWord)
//           {
//               if (i + 1 <= sentences.Length)
//               {
//                   if (sentences[i - 1] == ' ' && sentences[i + word.Length] == ' ')
//                   {
//                       listForPrint.Add(sentences);
//                   }
//               }
//           }
//       }
//   }
//
//   for (int i = 0; i < listForPrint.Count; i++)
//   {
//       Console.Write("{0}.", listForPrint[i]);


