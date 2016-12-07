using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CombinationsWithDuplicates
{
    // Modify the previous program to skip duplicates:
        // n=4, k=2 → (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)

    public class Startup
    {
        private static int n;
        private static int k;
        private static int[] results;
        private static IList<string> finalResults;

        public static void Main()
        {
            finalResults = new List<string>();

            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());

            Console.Write("k = ");
            k = int.Parse(Console.ReadLine());

            results = new int[k];

            AllCombinationsWithoutDuplications(0, 1);

            Console.WriteLine(string.Join(", ", finalResults));
        }

        private static void AllCombinationsWithoutDuplications(int index, int start)
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
                    AllCombinationsWithoutDuplications(index + 1, i + 1);
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
