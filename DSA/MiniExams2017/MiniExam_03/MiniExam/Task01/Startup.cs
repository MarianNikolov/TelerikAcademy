using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Startup
    {

        public static void Main()
        {
            int max = 20;
            int[] results = new int[max];
            results[0] = 0;

            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            results[1] = k - 1;
            results[2] = k * (k - 1);
            for (int i = 3; i <= n; i++)
            {
                results[i] = ((k - 1) * results[i - 1]) + ((k - 1) * results[i - 2]);
            }

            Console.WriteLine(results[n]);
        }
    }
}


