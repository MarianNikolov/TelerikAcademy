using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Console.ReadLine();
            var days = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            long result = 0;
            long currentMax = 0;

            for (int i = days.Count - 1; i >= 0; i--)
            {
                if (currentMax < days[i])
                {
                    currentMax = days[i];
                    continue;
                }

                result += currentMax - days[i];
            }

            Console.WriteLine(result);
        }
    }
}
