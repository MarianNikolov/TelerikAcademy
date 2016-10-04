using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorTask1
{
    class MutantSquirrels
    {
        // 100 points in BgCoder during exam
        static void Main()
        {
            double trees = double.Parse(Console.ReadLine());
            double branches = double.Parse(Console.ReadLine());
            double squirrels = double.Parse(Console.ReadLine());
            double averageNumberOfTails = double.Parse(Console.ReadLine());

            double sum = trees * branches * squirrels * averageNumberOfTails;
            bool hasDivisionWithResidue = sum % 2 == 1;

            if (hasDivisionWithResidue)
            {
                sum = sum / 7;

                Console.WriteLine("{0:F3}", sum);
            }
            else
            {
                sum = sum * 376439;

                Console.WriteLine("{0:F3}", sum);
            }
        }
    }
}
