using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibunachi
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstNumber = 0;
            long secondNumber = 1;
            long thirdNumber;
            for (int i = 0; i < 10; i++)
            {
                thirdNumber = firstNumber + secondNumber;
                Console.WriteLine(thirdNumber);
                firstNumber = secondNumber;
                secondNumber = thirdNumber;
            }
        }
    }
}
