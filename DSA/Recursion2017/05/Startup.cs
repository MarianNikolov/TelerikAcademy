using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    public class Startup
    {
        // Write a recursive program for generating and printing all ordered 
        // k-element subsets from n-element set(variations Vkn).
        // Example: n=3, k=2, set = {hi, a, b} → 
        // (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)

        private static int n;
        private static int k;
        private static int[] result;
        private static string[] parameters;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            parameters = Console.ReadLine().Split(' ');

            result = new int[k];

            VariationsWithRepetitions(0);
        }

        static void VariationsWithRepetitions(int index)
        {
            if (index >= k)
                Print(result);
            else
                for (int i = 0; i < n; i++)
                {
                    result[index] = i;
                    VariationsWithRepetitions(index + 1);
                }
        }

        public static void Print(int[] result)
        {
      
    }
}
