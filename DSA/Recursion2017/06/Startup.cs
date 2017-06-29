using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06
{
    public class Startup
    {
        // Write a program for generating and printing all subsets of k strings from given set of strings.
        //Example: s = {test, rock, fun}, k=2 → (test rock), (test fun), (rock fun)

        private static int n;
        private static int k;
        private static int[] result;
        private static string[] parameters;

        static void Main()
        {
            parameters = Console.ReadLine().Split(' ');
            n = parameters.Length;
            k = int.Parse(Console.ReadLine());

            result = new int[k];

            CombinationsWithoutRepetition(0, 0);

        }

        static void CombinationsWithoutRepetition(int index, int start)
        {
            if (index >= k)
                Print();
            else
                for (int i = start; i < n; i++)
                {
                    result[index] = i;
                    CombinationsWithoutRepetition(index + 1, i + 1);
                }
        }

        public static void Print()
        {
            for (int i = 0; i < result.Length; i++)
            {
                var currentIndex = result[i];
                Console.Write(parameters[currentIndex] + " ");

            }

            Console.WriteLine();
        }
    }
}
