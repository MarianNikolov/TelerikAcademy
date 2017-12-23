using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Startup
    {
        public static SortedSet<long> results = new SortedSet<long>();
        public static int p;

        static void Main(string[] args)
        {
            p = int.Parse(Console.ReadLine());

            List<long> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            var max = numbers.Max();

            results.Add(1);

            var currentRes = new List<long>();
            currentRes.Add(1);

            long currentMax = 1;

            Recursion(max, currentMax, currentRes);

            var findedSums = new Dictionary<long, int>();

            for (int i = 0; i < results.Count; i++)
            {
                var elementAtI = results.ElementAt(i);
                for (int j = i + 1; j < results.Count; j++)
                {
                    var sum = elementAtI + results.ElementAt(j);

                    if (findedSums.ContainsKey(sum))
                    {
                        findedSums[sum]++;
                    }
                    else
                    {
                        findedSums.Add(sum, 1);
                    }
                }
            }

            var finalRes = new List<byte>(numbers.Count);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (findedSums.ContainsKey(numbers[i]))
                {
                    if (findedSums[numbers[i]] == 1)
                    {
                        finalRes.Add(1);
                    }
                    else
                    {
                        finalRes.Add(0);
                    }
                }
                else
                {
                    finalRes.Add(0);
                }

            }

            Console.WriteLine(string.Join(" ", finalRes));
        }

        public static void Recursion(long max, long currentMax, List<long> currentRes)
        {
            if (max <= currentMax)
            {
                return;
            }

            long leftNumber = 0;
            long rightNumber = 0;
            List<long> currentR = new List<long>();

            for (int i = 0; i < currentRes.Count; i++)
            {
                leftNumber = p * currentRes[i];
                rightNumber = p * currentRes[i] + 1;

                results.Add(leftNumber);
                results.Add(rightNumber);

                currentR.Add(leftNumber);
                currentR.Add(rightNumber);

                Recursion(max, rightNumber, currentR);
            }
        }
    }
}
