using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ReplaceTags
{
    static void Main()
    {
        var pattern = @"<\s*a.*?href\s*=\s*(?:""|')(.*?)(?:""|')[^>]*>(.*?)<\s*?\/\s*?a\s*?>";
        Console.WriteLine(Regex.Replace(Console.ReadLine(), pattern, "[$2]($1)"));


        //string input = Console.ReadLine();

        //StringBuilder print = new StringBuilder();

        //int indexForBuilderStart = 0;

        //int startIndex = 0;
        //int lastIndex = 0;
        //int secondStartIndex = 0;
        //int secondLastIndex = 0;

        //string site = string.Empty;
        //string http = string.Empty;


        //while (input.IndexOf("<a", startIndex) >= 0)
        //{
        //    startIndex = input.IndexOf("<a");
        //    lastIndex = input.IndexOf("href=\"");

        //    // dobavqm
        //    print.Append(input.Substring(indexForBuilderStart, startIndex - indexForBuilderStart));

        //    // premahvam ot "<a" do "hreh=";        
        //    input = input.Remove(startIndex, (lastIndex - startIndex) + 6);

        //    // zapisvam v promenlivi site i http 
        //    secondStartIndex = input.IndexOf("\">");
        //    secondLastIndex = input.IndexOf("</a>");

        //    http = input.Substring(startIndex, secondStartIndex - startIndex);
        //    site = input.Substring(secondStartIndex + 2, secondLastIndex - (secondStartIndex + 2));

        //    // premahvam ot inputa site i http i gi dobavqm v buildera
        //    input = input.Remove(startIndex, (secondLastIndex + 4) - startIndex); //29

        //    print.Append("[");
        //    print.Append(site);
        //    print.Append("]");

        //    print.Append("(");
        //    print.Append(http);
        //    print.Append(")");

        //    // update index for builder
        //    indexForBuilderStart = startIndex;
        //}

        //print.Append(input.Substring(indexForBuilderStart));

        //Console.WriteLine(print.ToString());
    }
}


