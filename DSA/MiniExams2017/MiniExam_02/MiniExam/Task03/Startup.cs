using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Program
    {
        private static HashSet<long> resultsNumbers = new HashSet<long>();

        static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine());
            string[] numbersStr = Console.ReadLine().Split(' ');
            HashSet<long> numbers = new HashSet<long>();
            for (int k = 0; k < numbersStr.Length; k++)
            {
                numbers.Add(long.Parse(numbersStr[k]));
            }

            long max = numbers.Max();

            resultsNumbers.Add(1);

            Recursion(max, 1, p);

            int[] result = new int[numbers.Count];
            int i = 0;

            foreach (var number in numbers)
            {
                int counter = 0;
                foreach (var numInHashSet in resultsNumbers)
                {
                    if (resultsNumbers.Contains(number - numInHashSet))
                    {
                        counter++;
                    }
                }

                if (counter == 2)
                {
                    result[i] = 1;
                }
                else
                {
                    result[i] = 0;
                }

                i++;
            }

            Console.WriteLine(string.Join(" ", result));

        }
        static void Recursion(long max, long current, int p)
        {
            if (current >= max)
            {
                return;
            }

            long left = p * current;
            var right = left + 1;

            resultsNumbers.Add(left);
            Recursion(max, left, p);

            resultsNumbers.Add(right);
            Recursion(max, right, p);
        }
    }
}