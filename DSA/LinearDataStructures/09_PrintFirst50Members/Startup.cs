using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_PrintFirst50Members
{
    // 09. We are given the following sequence:
    // S1 = N;
    // S2 = S1 + 1;
    // S3 = 2* S1 + 1;
    // S4 = S1 + 2;
    // S5 = S2 + 1;
    // S6 = 2* S2 + 1;
    // S7 = S2 + 2;
    // ...
    // Using the Queue<T> class write a program to print its first 50 members for given N.
    // Example: N= 2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

    public class Startup
    {
        private const int NumberOfSequence = 50;

        static void Main()
        {
            Queue<int> sequence = new Queue<int>();
            IList<int> result = new List<int>();
            Console.WriteLine("Enter number N:");
            var n = int.Parse(Console.ReadLine());

            sequence.Enqueue(n);

            var counter = 0;

            while (counter <= NumberOfSequence)
            {
                var currentNumber = sequence.Dequeue();

                result.Add(currentNumber);

                sequence.Enqueue(currentNumber + 1);
                sequence.Enqueue((2 * currentNumber) + 1);
                sequence.Enqueue(currentNumber + 2);

                counter += 3;
            }

            while (sequence.Count != 0)
            {
                result.Add(sequence.Dequeue());
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
