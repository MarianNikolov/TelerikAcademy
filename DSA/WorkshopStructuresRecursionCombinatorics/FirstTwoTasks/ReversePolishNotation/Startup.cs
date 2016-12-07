using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    public class Startup
    {
        private static long n;

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            PolishNotation(input);
        }

        static void PolishNotation(string[] input)
        {
            Stack<long> stack = new Stack<long>();

            foreach (var item in input)
            {
                bool isNumeric = false;

                try
                {
                    isNumeric = long.TryParse(item, out n);
                }
                catch (Exception ex)
                {
                }

                if (isNumeric)
                {
                    stack.Push(long.Parse(item));
                }
                else if (item[0] == '+')
                {
                    stack.Push(stack.Pop() + stack.Pop());
                }
                else if (item[0] == '-')
                {
                    var first = stack.Pop();
                    var second = stack.Pop();

                    stack.Push(second - first);
                }
                else if (item[0] == '*')
                {
                    stack.Push(stack.Pop() * stack.Pop());
                }
                else if (item[0] == '/')
                {
                    var first = stack.Pop();
                    var second = stack.Pop();

                    stack.Push(second / first);
                }
                else if (item[0] == '&')
                {
                    var first = stack.Pop();
                    var second = stack.Pop();

                    stack.Push(second & first);
                }
                else if (item[0] == '|')
                {
                    var first = stack.Pop();
                    var second = stack.Pop();

                    stack.Push(second | first);
                }
                else if (item[0] == '^')
                {
                    var first = stack.Pop();
                    var second = stack.Pop();

                    stack.Push(second ^ first);
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
