using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CompareCharArrays
{
    static void Main()
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();


        
        int result = first.CompareTo(second);
        switch (result)
        {
            case -1: Console.WriteLine("<"); break;
            case 1: Console.WriteLine(">"); break;
            case 0: Console.WriteLine("="); break;
            default:
                break;
        }

        //int counter = Math.Min(first.Length, second.Length);

        //for (int i = 0; i < counter; i++)
        //{
        //    if (first[i] == second[i])
        //    {
        //        continue;
        //    }

        //    else
        //    {
        //        if (first[i] > second[i])
        //        {
        //            Console.WriteLine(">");
        //        }
        //        else 
        //        {
        //            Console.WriteLine("<");
        //        }
        //        return;
        //    }
        //}
        //if (first.Length != second.Length)
        //{
        //    if (counter == first.Length)
        //    {
        //        Console.WriteLine("<");
        //    }
        //    else
        //    {
        //        Console.WriteLine(">");
        //    }
        //    return;
        //}
        //Console.WriteLine("=");
    }
}

