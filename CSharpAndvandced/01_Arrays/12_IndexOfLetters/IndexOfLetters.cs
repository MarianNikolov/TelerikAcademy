using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class IndexOfLetters
{
    static void Main()
    {
        // make alphabet string
        string alphabet = "";
        char latter = 'a';
        for (int i = 0; i < 26; i++)
        {
            alphabet += latter;
            latter++;
        }

        string word = Console.ReadLine();


        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (word[i] == alphabet[j])
                {
                    Console.WriteLine(j);
                    continue;
                }
            }
        }
    }
}
