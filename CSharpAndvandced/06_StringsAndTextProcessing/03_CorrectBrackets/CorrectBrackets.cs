using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CorrectBrackets
{
    public static string BracketsArePutCorrectly(string word)
    {
        int countOpenBreackets = 0;
        int countCloseBreackets = 0;

        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == '(')
            {
                countOpenBreackets++;
            }

            if (word[i] == ')')
            {
                countCloseBreackets++;

                if (countCloseBreackets > countOpenBreackets)
                {
                    return "Incorrect";
                }
            }
        }
        if (countOpenBreackets > countCloseBreackets)
        {
            return "Incorrect";
        }
        else
        {
            return "Correct";
        }
    }


    static void Main()
    {
        string word = Console.ReadLine();

        Console.WriteLine(BracketsArePutCorrectly(word));


    }
}

