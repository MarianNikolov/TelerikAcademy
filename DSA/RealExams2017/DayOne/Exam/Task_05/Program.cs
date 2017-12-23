using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            var memo = new long[n];
            long max = 0;
            var results = new long[n];
            long currentHeight = 0;
            for (int i = 0; i < input.Count; i++)
            {
                currentHeight = input[i];
                for (int j = i + 1; j < input.Count; j++)
                {
                    if (currentHeight < input[j])
                    {
                        // need memo
                        currentHeight = input[j];
                        results[i]++;

                        if (max < results[i])
                        {
                            max = results[i];
                        }
                    }
                }
            }

            //var max = results.Max();
            Console.WriteLine(max);
            Console.WriteLine(string.Join(" ", results));
        }
    }
}
