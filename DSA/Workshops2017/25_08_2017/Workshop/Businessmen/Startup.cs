using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmen
{
    class Startup
    {
        static void Main()
        {
            long N = long.Parse(Console.ReadLine());

            long[] solutions = new long[71];
            solutions[0] = (long)1;

            for (long allPeople = 2; allPeople <= N; allPeople += 2)
            {
                for (long oneSidePeople = allPeople - 2; oneSidePeople >= 0; oneSidePeople -= 2)
                {
                    solutions[allPeople] += solutions[oneSidePeople] * solutions[allPeople - oneSidePeople - 2];
                }
            }

            Console.WriteLine(solutions[N]);
        }
    }
}
