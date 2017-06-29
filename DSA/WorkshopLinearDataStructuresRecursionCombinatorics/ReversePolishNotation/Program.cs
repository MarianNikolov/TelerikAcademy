using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    public class Program
    {
        static void Main()
        {
            // 254 488 & 61 / 771 24 | * 394 3 428 | 141 171 & + | / 654 *
            var expresion = Console.ReadLine().Split(' ');
            var stack = new Stack<long>();

            foreach (var currentSimbol in expresion)
            {
                long number;
                if (!long.TryParse(currentSimbol, out number))
                {
                    var first = stack.Pop();
                    var second = stack.Pop();

                    switch (currentSimbol)
                    {
                        case "+": number = second + first; break;
                        case "-": number = second - first; break;
                        case "/": number = second / first; break;
                        case "*": number = second * first; break;
                        case "&": number = second & first; break;
                        case "|": number = second | first; break;
                        case "^": number = second ^ first; break;
                        default:
                            break;
                    }

                }

                stack.Push(number);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
