using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    //public static int SearchSubStringCount(string[] wordArray, string wantedWord)
    //{
    //    //int countSubString = 0;
    //    //int countCharacters = 0;

    //    foreach (var word in wordArray)
    //    {
    //        if (word.Length < wantedWord.Length)
    //        {
    //            continue;
    //        }



    //        //for (int i = 0; i < word.Length; i++)
    //        //{

    //        //    for (int j = 0; j < wantedWord.Length; j++)
    //        //    {
    //        //        if (i + j >= word.Length)
    //        //        {
    //        //            break;
    //        //        }
    //        //        if (word[i + j] == wantedWord[j])
    //        //        {
    //        //            countCharacters++;
    //        //        }
    //        //    }

    //        //    if (countCharacters == wantedWord.Length)
    //        //    {
    //        //        countSubString++;
    //        //    }
    //        //    countCharacters = 0;
    //        //}
    //    }
    //    return countSubString;
    //}

    static void Main()
    {
        string wantedWord = Console.ReadLine();
        wantedWord = wantedWord.ToLower();

        string word = Console.ReadLine();
        
        word = word.ToLower();

        int curentIndex = 0;
        int counter = 0;
        int index = 0;
        
        while (word.IndexOf(wantedWord, index) != -1)
        {
            curentIndex = word.IndexOf(wantedWord, index);
            counter++;
            index = curentIndex + wantedWord.Length;
        }

        Console.WriteLine(counter);

        //string a = Console.ReadLine();
        //string b = Console.ReadLine();

        //int result = b.Split(new char[] { ' ', ',', '.', '!', '-' }, StringSplitOptions.RemoveEmptyEntries).Count(word => word.ToLower().Contains(a.ToLower()));
        //Console.WriteLine(result);
    }


}
