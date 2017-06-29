using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    public class Startup
    {
        // Write a recursive program for generating and printing all permutations 
        // of the numbers 1, 2, ..., n for given integer number n.
        // Example:
        // n= 3 → { 1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}

        static int k;
        static int n;
        static int[] result;

        static void Main()
        {
            k = 0;
            n = int.Parse(Console.ReadLine());

            result = new int[n];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = i + 1;
            }

            PermutationsWithoutRepetition(result, k);
        }

        static void PermutationsWithoutRepetition(int[] arr, int k)
        {
            if (k >= arr.Length)
                Print(arr);
            else
            {
                PermutationsWithoutRepetition(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    PermutationsWithoutRepetition(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void Swap<T>(ref T t1, ref T t2)
        {
            T temp = t1;
            t1 = t2;
            t2 = temp;
        }

        public static void Print(int[] result)
        {
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
