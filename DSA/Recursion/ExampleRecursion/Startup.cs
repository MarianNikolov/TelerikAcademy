using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRecursion
{
    public class Startup
    {
        // *** This is test project for my recursion tests ***
        // ***      Homework is on another projects        ***

        static void Main()
        {
            //Console.WriteLine("Start");
            //Rec(3);
            //Console.WriteLine("Stop");

            //Console.WriteLine(Factorial(44)); 

            BinaryVectors(3);
        }

        static void BinaryVectors(int n, string vector = "")
        {
            if (n == 0)
            {
                Console.WriteLine(vector);
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                if (string.IsNullOrEmpty(vector) && i == 0 && n != 1)
                {
                    BinaryVectors(n - 1, "");
                }
                else
                {
                    BinaryVectors(n - 1, vector + i);
                }
            }
        }

        static long Factorial(long n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        static void Rec(int stepsLeft)
        {
            if (stepsLeft == 0)
            {
                return;
            }

            Console.WriteLine(stepsLeft + " before");

            Rec(stepsLeft - 1);

            Console.WriteLine(stepsLeft + " middle");

            Rec(stepsLeft - 1);

            Console.WriteLine(stepsLeft + " after");
        }
    }
}
