using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_LongestSubsequenceOfEqualNumbers
{
    // 04. Write a method that finds the longest subsequence of equal numbers in given List 
    //     and returns the result as new List<int>.
    // Write a program to test whether the method works correctly.

    public class Startup
    {

        static void Main()
        {
            IList<int> sequence = new List<int>() { 3, 55, 2, 2, 2, 4 };

            var longestSubsequence = LongestSubsequence(sequence);

            Console.WriteLine(string.Join(", ", longestSubsequence));
        }

        public static IList<int> LongestSubsequence(IList<int> sequence)
        {
            var result = new List<int>();

            
            var endIndex = 0;
            var longestSequence = 1;
            var counter = 1;

            for (int i = 0; i < sequence.Count - 1; i++)
            {
                if (sequence[i] == sequence[i + 1])
                {
                    counter++;

                    if (counter > longestSequence)
                    {
                        longestSequence = counter;
                        endIndex = i + 1;
                    }
                }
                else
                {
                    counter = 1;
                }
            }

            var startIndex = endIndex - (longestSequence - 1);

            for (int i = startIndex; i <= endIndex; i++)
            {
                result.Add(sequence[i]);
            }

            return result;
        }
    }
}
