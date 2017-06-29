using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    public class Startup
    {
        // Modify the previous program to skip duplicates:
        // n=4, k=2 → (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)

        static int n;
        static int k;
        static int[] result;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            result = new int[k];

            CombinationsWithoutDuplicates(0, 1);
        }

        static void CombinationsWithoutDuplicates(int index, int start)
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
                    CombinationsWithoutDuplicates(index + 1, i + 1);
                }
            }
        }

        public static void Print()
        {
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
