using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRingsОfТheAcademy
{
    class Program
    {
        static long count = 0;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, int>();

            for (int i = 1; i <= n; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(currentNumber))
                {
                    numbers[currentNumber]++;
                }
                else
                {
                    numbers.Add(currentNumber, 1);
                }
            }

            var results = new List<long>();
            long finalResult = 1;
            foreach (var number in numbers.Values)
            {
                if (number > 1)
                {
                    var arr = new int[number];
                    for (int i = 0; i < number; i++)
                    {
                        arr[i] = i;
                    }

                    GeneratePermutations(arr, 0);
                    results.Add(count);
                    count = 0;
                }
            }

            for (int i = 0; i < results.Count; i++)
            {
                finalResult *= results[i];
            }

            Console.WriteLine(finalResult);
        }

        static void GeneratePermutations<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                count++;
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
