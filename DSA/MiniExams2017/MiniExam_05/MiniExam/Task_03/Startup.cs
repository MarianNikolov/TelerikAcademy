using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(long.Parse)
                 .ToList();

            input.Sort();

            long result = input[input.Count - 1];
            result += input[input.Count - 2];

            for (int i = input.Count - 3; i >= 0; i--)
            {
                var currenResult = (long)Math.Abs((decimal)result);

                if (currenResult % 2 == 1 && input[i] <= 0)
                {
                    break;
                }

                result += input[i];
            }

            Console.WriteLine(result);
        }
    }
}
