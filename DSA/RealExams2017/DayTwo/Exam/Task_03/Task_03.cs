using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    class Task_03
    {
        static BigInteger[] memo;
        static void Main()
        {
            //var input = Console.ReadLine()
            //    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToList();

            var n = int.Parse(Console.ReadLine());
            memo = new BigInteger[n];
            Console.WriteLine(catalan(n));




        }

        static BigInteger catalan(int n)
        {
            BigInteger res = 0;
            
            // Base case
            if (n <= 1)
            {
                return 1;
            }
            for (int i = 0; i < n; i++)
            {
                if (memo[i] == 0)
                {
                    memo[i] = catalan(i);
                }
                if (memo[n - i - 1] == 0)
                {
                    memo[n - i - 1] = catalan(n - i - 1);
                }
                res += memo[i] * memo[n - i - 1];
            }


            return res;
        }

    }

}
