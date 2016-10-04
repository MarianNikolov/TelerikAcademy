using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StringLength
{
    public static void FindIndexOfLetherInWord(string word, string findChar)
    {
        int curentIndex = word.IndexOf(findChar);

        while (curentIndex != -1)
        {
            Console.WriteLine(curentIndex);
            if (curentIndex + 1 >= word.Length)
            {
                break;
            }
            curentIndex = word.IndexOf(findChar, curentIndex + 1);
        }
    }

    static void Main()
    {
        string word = Console.ReadLine();
        int numberOfSymbols = 20;
        word = word.Replace("\\", string.Empty);

        if (word.Length < numberOfSymbols)
        {
            Console.Write(word);
            Console.Write(new string('*', numberOfSymbols - word.Length));
        }
        else if (word.Length > numberOfSymbols)
        {
            for (int i = 0; i < numberOfSymbols; i++)
            {
                Console.Write(word[i]);
            }
        }
        else
        {
            Console.WriteLine(word);
        }
    }
}

