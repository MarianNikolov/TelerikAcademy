namespace Problem1_StringBuilderSubstring
{
    using System;
    using System.Text;

    class Test
    {
/*
Problem 1. StringBuilder.Substring

Implement an extension method Substring(int index, int length) 
for the class StringBuilder that returns new StringBuilder 
//and has the same functionality as Substring in the class String.
*/
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Telerik academy is cool!");
            Console.WriteLine(sb.MySubstring(0, 7)); 
        }
    }
}
