using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_ValueThatOccurs
{
    // 08. The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
    // Write a program to find the majorant of given array(if exists).
    // Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} → 3


    public class Startup
    {
        private const string Message = "Sequence doesn't contain occurs number whit N/2 + 1";

        static void Main()
        {
            IList<int> sequence = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            Console.WriteLine("Sequence");
            Console.WriteLine(string.Join(", ", sequence));
            Console.WriteLine();

            Dictionary<int, int> numbersOfSequence = new Dictionary<int, int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                if (numbersOfSequence.ContainsKey(sequence[i]))
                {

                    numbersOfSequence[sequence[i]]++;
                }
                else
                {
                    numbersOfSequence.Add(sequence[i], 1);
                }
            }

            var occursAtLeast = (sequence.Count / 2) + 1;

            var result = numbersOfSequence.Where(x => x.Value >= occursAtLeast).Select(x => x.Key).ToList();

            if (result.Count > 0)
            {
                Console.WriteLine(string.Join(", ", result));
            }
            else
            {
                Console.WriteLine(Message);
            }
        }
    }
}
