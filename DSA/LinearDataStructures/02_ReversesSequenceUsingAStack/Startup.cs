using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ReversesSequenceUsingAStack
{
    // 02. Write a program that reads N integers from the console and reverses them using a stack.
        // Use the Stack<int> class.

    public class Startup
    {
        static void Main()
        {
            var stack = new Stack<int>();

            while (true)
            {
                string currentLine = Console.ReadLine();

                if (!string.IsNullOrEmpty(currentLine))
                {
                    stack.Push(int.Parse(currentLine));
                }
                else
                {
                    while (stack.Count != 0)
                    {
                        Console.WriteLine(stack.Pop());
                    }

                    Environment.Exit(1);
                }
            }
        }
    }
}
