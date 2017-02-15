using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace OddNumber
{
    //    Description
    // You are given N numbers.Almost all of them will appear an even 
    // amount of times, only one of them will appear an odd amount of times.Find that number and print it to the console.
       
    // Input
    // N is read from the first line
    // On each of the next N lines there will be a number
       
    // Output
    // Output a number on a single line - the only number that is repeated odd amount of times

    public class Startup
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            LinkedList<long> set = new LinkedList<long>();

            Bag<long> bag = new Bag<long>();
            BigList<long> bigList = new BigList<long>();

            for (int i = 0; i < n; i++)
            {
                var currentNumber = long.Parse(Console.ReadLine());

                if (set.Contains(currentNumber))
                {
                    set.Remove(currentNumber);
                }
                else
                {
                    set.AddLast(currentNumber);
                }
            }

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }

            // 66 point in BgCoder

            //var dictionary = new Dictionary<long, int>();

            //for (int i = 0; i < n; i++)
            //{
            //    var currentNumber = long.Parse(Console.ReadLine());

            //    if (dictionary.ContainsKey(currentNumber))
            //    {
            //        dictionary[currentNumber]++;
            //    }
            //    else
            //    {
            //        dictionary.Add(currentNumber, 1);
            //    }
            //}

            //foreach (var item in dictionary)
            //{
            //    if (item.Value % 2 == 1)
            //    {
            //        Console.WriteLine(item.Key);
            //        break;
            //    }
            //}
        }
    }
}
