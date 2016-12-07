using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateNNestetLoops
{
    // Write a recursive program that simulates the execution of n nested loops from 1 to n.
    //   Examples:
    //        1 1
    // n= 2-> 1 2
    //        2 1
    //        2 2
    // ----------------------
    //        1 1 1
    //        1 1 2
    //        1 1 3
    //        1 2 1
    // n= 3-> .....
    //        3 2 3
    //        3 3 1
    //        3 3 2
    //        3 3 3

    public class Startup
    {
        static void Main()
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());
            var k = n;

            NestetLoopsWhitRecursion(n, k);
        }

        private static void NestetLoopsWhitRecursion(int n, int k, string vector = "")
        {
            if (n == 0)
            {
                Console.WriteLine(vector);
                return;
            }

            for (int i = 1; i <= k; i++)
            {
                NestetLoopsWhitRecursion(n - 1, k, vector + i); ;
            }
        }
    }
}
