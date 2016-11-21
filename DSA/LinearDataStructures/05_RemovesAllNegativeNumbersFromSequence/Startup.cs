using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_RemovesAllNegativeNumbersFromSequence
{
    // 05. Write a program that removes from given sequence all negative numbers.

    public class Startup
    {
        static void Main()
        {
            IList<int> sequence = new List<int>() { -3, 55, 2, 2, -2, 4, 5424, 4, -2321, 1, 64, -5};

            Console.WriteLine("Sequence");
            Console.WriteLine(string.Join(", ", sequence));
            Console.WriteLine();

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] < 0)
                {
                    sequence.Remove(sequence[i]);
                }
            }

            Console.WriteLine("Sequence without negative numbers:");
            Console.WriteLine(string.Join(", ", sequence));
            Console.WriteLine();
        }
    }
}
