using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReverseString
{
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }


    static void Main()
    {
        string wordToReverse = Console.ReadLine();
        Console.WriteLine(Reverse(wordToReverse));
    }
}

