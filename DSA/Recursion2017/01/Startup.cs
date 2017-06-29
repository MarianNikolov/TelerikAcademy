using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    public class Startup
    {
        // Write a recursive program that simulates the execution of n nested loops from 1 to n.

        //           1 1
        //n=2  ->    1 2
        //           2 1
        //           2 2

        //           1 1 1
        //           1 1 2
        //           1 1 3
        //           1 2 1
        //n=3  ->    ...
        //           3 2 3
        //           3 3 1
        //           3 3 2
        //           3 3 3

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = n;
            NestedLoops(n, k);
        }

        public static void NestedLoops(int n, int k, string result = "")
        {
            if (n == 0)
            {
                Print(result);
                return;
            }

            for (int i = 1; i <= k; i++)
            {
                
                NestedLoops(n - 1, k, result + i);
            }

        }

        public static void Print(string result)
        {
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
