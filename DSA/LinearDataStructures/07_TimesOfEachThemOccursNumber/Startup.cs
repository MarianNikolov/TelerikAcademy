using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_TimesOfEachThemOccursNumber
{
    // 07. Write a program that finds in given array of integers(all belonging to the range[0..1000]) 
    //     how many times each of them occurs.
    //
    // Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
    //      2 → 2 times
    //      3 → 4 times
    //      4 → 3 times

    public class Startup
    {
        static void Main()
        {
            IList<int> sequence = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            Console.WriteLine("Sequence");
            Console.WriteLine(string.Join(", ", sequence));
            Console.WriteLine();

            Dictionary<int, int> result = new Dictionary<int, int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                if (result.ContainsKey(sequence[i]))
                {

                    result[sequence[i]]++;
                }
                else
                {
                    result.Add(sequence[i], 1);
                }
            }

            foreach (var item in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
