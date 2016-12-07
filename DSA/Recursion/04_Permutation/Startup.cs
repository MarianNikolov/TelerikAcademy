using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Permutation
{
    // Write a recursive program for generating and printing all permutations of the numbers 
    //1, 2, ..., n for given integer number n. Example:
        // n= 3 → {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

    public class Startup
    {
        private static int k;
        private static int[] results;
        private static IList<string> finalResults;

        public static void Main()
        {
            finalResults = new List<string>();

            k = 0;

            results = new int[] { 1, 2, 3};

            Permutations(results, k);

            Console.WriteLine(string.Join(", ", finalResults));
        }

        private static void Permutations(int[] results, int k)
        {
            if (k >= results.Length)
            {
                AddResult();
            }
            else
            {
                Permutations(results, k + 1);
                for (int i = k + 1; i < results.Length; i++)
                {
                    Swap(ref results[k], ref results[i]);
                    Permutations(results, k + 1);
                    Swap(ref results[k], ref results[i]);
                }
            }
        }

        private static void Swap(ref int first, ref int second)
        {
            var oldFirst = first;
            first= second;
            second = oldFirst;
        }

        private static void AddResult()
        {
            var currentResult = new StringBuilder();

            currentResult.Append("{");

            for (int i = 0; i < results.Length; i++)
            {
                currentResult.Append(results[i].ToString());

                if (i == results.Length - 1)
                {
                    currentResult.Append("}");
                }
                else
                {
                    currentResult.Append(" ");
                }
            }

            finalResults.Add(currentResult.ToString());
        }
    }
}
