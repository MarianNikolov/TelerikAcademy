using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03__SortsSequenceInIncreasingOrder
{
    // 03. Write a program that reads a sequence of integers(List<int>) ending with an empty line 
    //     and sorts them in an increasing order.

    public class Startup
    {
        static void Main()
        {
            var sequence = new List<int>();

            while (true)
            {
                string currentLine = Console.ReadLine();

                if (!string.IsNullOrEmpty(currentLine))
                {
                    sequence.Add(int.Parse(currentLine));
                }
                else
                {
                    sequence.Sort((a, b) => a.CompareTo(b));

                    for (int i = 0; i < sequence.Count; i++)
                    {
                        Console.WriteLine(sequence[i]);
                    }

                    Environment.Exit(1);
                }
            }
        }
    }
}
