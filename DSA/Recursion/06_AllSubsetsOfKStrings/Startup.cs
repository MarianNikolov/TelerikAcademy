using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_AllSubsetsOfKStrings
{
    // 06. Write a program for generating and printing all subsets 
    // of k strings from given set of strings.
    // Example: s = {test, rock, fun}, k=2 → (test rock), (test fun), (rock fun)

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


        static void Main()
        {
            finalResults = new List<string>();

            GenerateAllCombinations(0, 0);

            Console.WriteLine(string.Join(", ", finalResults));
        }

        private static void GenerateAllCombinations(int index, int start)
        {
            if (index >= k)
            {
                AddResult();
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    results[index] = i;
                    GenerateAllCombinations(index + 1, i + 1);
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
