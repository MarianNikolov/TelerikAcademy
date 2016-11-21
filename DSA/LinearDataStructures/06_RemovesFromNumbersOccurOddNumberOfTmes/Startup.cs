using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_RemovesFromNumbersOccurOddNumberOfTmes
{
    // 06. Write a program that removes from given sequence all numbers that occur odd number of times.
    // Example: { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} → {5, 3, 3, 5}


public class Startup
    {
        static void Main()
        {
            IList<int> sequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            Console.WriteLine("Sequence");
            Console.WriteLine(string.Join(", ", sequence));
            Console.WriteLine();

            Dictionary<int, int> oddAndEvenNumbers = new Dictionary<int, int>();
            IList<int> result = new List<int>();


            for (int i = 0; i < sequence.Count; i++)
            {
                if (oddAndEvenNumbers.ContainsKey(sequence[i]))
                {
                    oddAndEvenNumbers[sequence[i]]++;
                }
                else
                {
                    oddAndEvenNumbers.Add(sequence[i], 1);
                }
            }

            for (int i = 0; i < sequence.Count; i++)
            {
                if (oddAndEvenNumbers[sequence[i]] % 2 == 0)
                {
                    result.Add(sequence[i]);
                }
            }

            Console.WriteLine("Numbers that occur odd number of times:");
            Console.WriteLine(string.Join(", ", result));
            Console.WriteLine();
        }
    }
}
