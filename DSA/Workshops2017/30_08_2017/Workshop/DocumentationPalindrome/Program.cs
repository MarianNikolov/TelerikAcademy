using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentationPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower();

            // clear input 
            for (int i = 0; i < input.Length; i++)
            {
                var current = input[i];
                if (current == ' ' || current == ',' || current == '.' || current == '!' || current == '?')
                {
                    continue;
                }

            }

            // solve
            var length = input.Length;
            var leftIndrx = length - 1;
            var rightIndex = length - 1;
            var middleIndex = length / 2;
            long result = 0;

            for (int i = 0; i < middleIndex; i++)
            {


                if (input[leftIndrx] == input[rightIndex])
                {
                    continue;
                }

                // check if closest to 'z' or 'a'
                else
                {
                    while (input[leftIndrx] != input[rightIndex])
                    {
                        result++;
                    }
                }
            }

            Console.WriteLine(result);
        }








    }
}
