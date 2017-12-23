using System;
using System.Collections.Generic;
using System.Linq;

namespace Aquapark
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var command = input[0];

                switch (command)
                {
                    case "add":
                        queue.Enqueue(input[1]);
                        Console.WriteLine(string.Format("Added {0}", input[1]).Trim()) ;
                        break;

                    case "slide":
                        var number = int.Parse(input[1]);
                        for (int j = 0; j < number; j++)
                        {
                            queue.Enqueue(queue.Dequeue());
                        }
                        Console.WriteLine(string.Format("Slided {0}", number).Trim());
                        break;

                    case "print":
                        Console.WriteLine(string.Join(" ", queue.Reverse()));
                        break;
                }
            }
        }
    }
}
