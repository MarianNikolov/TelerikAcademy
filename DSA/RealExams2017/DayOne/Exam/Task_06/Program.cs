using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_06
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            
            var answer = ConvertToPalindrome(input);
            Console.WriteLine(answer.Length - input.Length);

        }

        public static string ConvertToPalindrome(string str) // By only adding characters at the end
        {
            if (str.Length == 1) return str; // base case 1
            if (str.Length == 2 && str[0] == str[1]) return str; // base case 2
            else
            {
                if (str[0] == str[str.Length - 1]) // keep the extremes and call                
                    return str[0] + ConvertToPalindrome(str.Substring(1, str.Length - 2)) + str[str.Length - 1];
                else //Add the first character at the end and call
                    return str[0] + ConvertToPalindrome(str.Substring(1, str.Length - 1)) + str[0];
            }
        }


        //public static int[] computeLPSArray(string s)
        //{
        //    int n = s.Length;
        //    //Initializing LPS vector
        //    var LPS = new int[n];

        //    int len = 0;
        //    LPS[0] = 0;

        //    // from i to n-1
        //    int i = 1;
        //    while (i < n)
        //    {
        //        if (s[i] == s[len])
        //        {
        //            len++;
        //            LPS[i] = len;
        //            i++;
        //        }
        //        else // (s[i] != s[len])
        //        {
        //            if (len != 0)
        //            {
        //                len = LPS[len - 1];
        //            }
        //            else // if (len == 0)
        //            {
        //                LPS[i] = 0;
        //                i++;
        //            }
        //        }
        //    }

        //    return LPS;
        //}

        //// return min character required
        //public static int minCharRequired(string s)
        //{
        //    string rs1 = s;
        //    //reverse of the string
        //    var rs = rs1.Reverse();
        //    //reverse(rs.begin(), rs.end());

        //    // Get concatenation of string, special character
        //    // and reverse string
        //    string c = s + "$" + rs;

        //    // Build LPS arrat
        //    var LPS = computeLPSArray(c);

        //    // Length - last value
        //    return (s.Length - LPS[LPS.Length - 1]);
        //}



    }











    //public static bool isPaindrome(String s)
    //{
    //    int beg = 0;
    //    int end = s.Length - 1;

    //    while (beg < end)
    //    {
    //        if (s[beg] != s[end])
    //        {
    //            return false;

    //        }
    //        beg++;
    //        end--;
    //    }

    //    return true;

    //}

    //public static int MinInsert(string s)
    //{
    //    int min = 0;
    //    if (isPaindrome(s))
    //    {
    //        return min;
    //    }

    //    min++;

    //    while (true)
    //    {
    //        List<string> temp = comboes(s, min);
    //        if (hasPalindrome(temp))
    //        {
    //            return min;
    //        }
    //        else
    //            min++;
    //    }
    //}

    ///*
    // * Returns an arraylist of strings, in which n characters are removed
    //* 
    //*/

    //public static List<string> comboes(string s, int n)
    //{
    //    List<string> results = new List<string>();
    //    if (n == 1)
    //    {

    //        for (int i = 0; i < s.Length; i++)
    //        {
    //            string text = "";
    //            for (int j = 0; j < s.Length; j++)
    //            {
    //                if (i != j)
    //                {

    //                    text = text + "" + s[j];
    //                }
    //            }
    //            results.Add(text);
    //        }

    //    }
    //    else
    //    {
    //        List<string> temp = new List<string>();
    //        for (int i = 0; i < s.Length; i++)
    //        {
    //            String tempString = "";
    //            for (int j = 0; j < s.Length; j++)
    //            {
    //                if (i != j)
    //                {
    //                    tempString = tempString + s[j];
    //                }
    //            }
    //            temp = comboes(tempString, n - 1);

    //            for (int j = 0; j < temp.Count; j++)
    //            {
    //                results.Add("" + temp[j]);
    //            }
    //        }
    //    }
    //    return results;
    //}

    //public static bool hasPalindrome(List<string> text)
    //{
    //    foreach (string word in text)
    //    {
    //        if (isPaindrome(word))
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}












    //public static bool IsPalindrome(string s)
    //{
    //    var i1 = 0;
    //    var i2 = s.Length - 1;
    //    while (i2 > i1)
    //    {
    //        if (s[i1] != s[i2])
    //        {
    //            return false;
    //        }

    //        i1++;
    //        i2--;
    //    }
    //    return true;
    //}
}
