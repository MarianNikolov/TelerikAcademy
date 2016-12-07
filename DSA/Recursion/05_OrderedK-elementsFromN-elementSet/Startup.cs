using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OrderedK_elementsFromN_elementSet
{
    // 05. Write a recursive program for generating and printing 
    // all ordered k-element subsets from n-element set(variations Vkn).
    // Example: n=3, k=2, set = {hi, a, b} → 
    // (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)

    public class Startup
    {
        private static IList<string> finalResults;

        private static int n = 3;
        private static int k = 2;
        private static int[] results = new int[k];

        private static string[] items = new string[] 
        {
            "CSKA",
            "Levski",
            "Ludogorec"
        };

        public static void Main()
        {
            finalResults = new List<string>();

            VariationsOfKElementsInNElementsSet(0);

            Console.WriteLine(string.Join(", ", finalResults));
        }

        private static void VariationsOfKElementsInNElementsSet(int index)
        {
            if (index >= k)
            {
                AddResult();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    results[index] = i;
                    VariationsOfKElementsInNElementsSet(index + 1);
                }
            }

        }

        private static void AddResult()
        {
            var currentResult = new StringBuilder();

            currentResult.Append("(");

            for (int i = 0; i < results.Length; i++)
            {
                currentResult.Append(items[results[i]]);

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
