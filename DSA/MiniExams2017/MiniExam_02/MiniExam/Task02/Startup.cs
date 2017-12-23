using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Startup
    {
        static HashSet<long> numbers = new HashSet<long>();

        static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine());
            string[] numbersStr = Console.ReadLine().Split(' ');
            HashSet<long> sums = new HashSet<long>();

            for (int k = 0; k < numbersStr.Length; k++)
            {
                numbers.Add(long.Parse(numbersStr[k]));
            }

            long max = numbers.Max();
            numbers.Add(1);

            Recursion(max, 1, p);

            int[] result = new int[numbers.Count];
            int i = 0;

            foreach (var number in numbers)
            {
                int counter = 0;

                foreach (var currentNumber in numbers)
                {
                    if (numbers.Contains(number - currentNumber))
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

            numbers.Add(left);
            Recursion(max, left, p);

            numbers.Add(right);
            Recursion(max, right, p);
        }
    }
}