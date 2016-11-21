using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _10_ShortestSequenceOfOperations.OperationProcessors;

namespace _10_ShortestSequenceOfOperations
{
    // 10. We are given numbers N and M and the following operations:
    // 
    // N = N+1
    // N = N+2
    // N = N*2
    // 
    // Write a program that finds the shortest sequence of operations from the list above 
    // that starts from N and finishes in M.
    // Hint: use a queue.
    // Example: N = 5, M = 16
    // Sequence: 5 → 7 → 8 → 16


    public class Startup
    {
        static void Main()
        {
            var sequence = GetSequence(5, 16);
            sequence.ForEach(Console.WriteLine);
        }

        private static IEnumerable<int> GetSequence(int start, int end)
        {
            IList<int> sequence = new List<int>();
            var processor = GetProcessor();

            var currentNumber = end;
            sequence.Add(currentNumber);

            while (currentNumber > start)
            {
                currentNumber = processor.GetProcessedResult(currentNumber, start);
                sequence.Add(currentNumber);
            }

            return sequence.OrderBy(x => x);
        }

        private static IOperationProcessor GetProcessor()
        {
            var plusOneOperation = new PlusOneOperation();
            var plusTwoOPeration = new PlusTwoOperations()
                {
                    LeftSuccesor = plusOneOperation
                };
            var doubleOperation = new DoubleOperation()
                {
                    RightSuccesor = plusOneOperation,
                    LeftSuccesor = plusTwoOPeration
                };

            return doubleOperation;
        }
    }

    public static class Extentions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (var item in enumeration)
            {
                action(item);
            }
        }

    }
}
