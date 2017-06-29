using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    public class Startup
    {
        // Write a recursive program for generating and printing all 
        // the combinations with duplicates of k elements from n-element set.
        // Example:
        // n=3, k=2 → (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)

        static int n;
        static int k;
        static int[] result;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            result = new int[k];

            CombinationsWithDuplicates(0, 1);
        }

        public static void CombinationsWithDuplicates(int index, int start)
        {
            if (index >= k)
            {
                Print();
            }
            else
            {
                for (int i = start; i <= n; i++)
                {
                    result[index] = i;
                    CombinationsWithDuplicates(index + 1, i);
                }
            }
        }

        public static void Print()
        {
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
