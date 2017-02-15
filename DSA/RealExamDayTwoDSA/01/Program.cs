using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _01
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            List<int> numbersToSwap = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            var collection = new BigList<int>();

            for (int i = 0; i < n; i++)
            {
                collection.Add(i + 1);
            }

            for (int i = 0; i < numbersToSwap.Count; i++)
            {
                int currentNumber = numbersToSwap[i];
                var currentIndex = 0;

                //for (int j = collection.Count - 1; j >= 0; j--)
                //{
                //    if (collection[j] == currentNumber)
                //    {
                //        currentIndex = j;
                //        break;
                //    }
                //}

                currentIndex = collection.IndexOf(currentNumber);

                var secondSub = collection.GetRange(currentIndex + 1, collection.Count - (currentIndex + 1));
                var firstSub = collection.GetRange(0, currentIndex);

                collection.Clear();
                collection.AddRange(secondSub);
                collection.Add(currentNumber);
                collection.AddRange(firstSub);
                
            }

            Console.WriteLine(string.Join(" ", collection));
        }
    }
}



//var firstSub = collection.Range(0, currentIndex);
//var secondSub = collection.Range(currentIndex + 1, collection.Count - (currentIndex + 1));

//for (int j = collection.Count - 1; j >= 0; j--)