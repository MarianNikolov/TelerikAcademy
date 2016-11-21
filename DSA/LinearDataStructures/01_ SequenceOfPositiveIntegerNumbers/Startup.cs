using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__SequenceOfPositiveIntegerNumbers
{
    // 01. Write a program that reads from the console a sequence of positive integer numbers.
        // The sequence ends when empty line is entered.
        // Calculate and print the sum and average of the elements of the sequence.
        // Keep the sequence in List<int>.

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
                    Console.WriteLine($"Sum is {sequence.Sum()}");
                    Console.WriteLine($"Average is {sequence.Average()}");

                    Environment.Exit(1);
                }
            }
        }
    }
}
