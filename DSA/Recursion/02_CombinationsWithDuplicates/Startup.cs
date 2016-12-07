using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CombinationsWithDuplicates
{
    // 02. Write a recursive program for generating and printing all the combinations 
    // with duplicates of k elements from n-element set.
    // Example:
    // n= 3, k= 2 → (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)

    public class Startup
    {
        private static int n;
        private static int k;
        private static int[] results;
        private static IList<string> finalResults;

        static void Main()
        {
            finalResults = new List<string>();

            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());

            Console.Write("k = ");
            k = int.Parse(Console.ReadLine());

            results = new int[k];

            AllCombinationsWithDuplications(0, 1);

            Console.WriteLine(string.Join(", ", finalResults));
        }

        private static void AllCombinationsWithDuplications(int index, int start)
        {
            if (index >= k)
            {
                PrintVariations();
            }
            else
            {
                for (int i = start; i <= n; i++)
                {
                    results[index] = i;
                    AllCombinationsWithDuplications(index + 1, i);
                }
            }
        }

        private static void PrintVariations()
        {
            var currentResult = new StringBuilder();

            currentResult.Append("(");

            for (int i = 0; i < results.Length; i++)
            {
                currentResult.Append(results[i].ToString());

                if (i == results.Length - 1)
                {
                    currentResult.Append(")");
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
