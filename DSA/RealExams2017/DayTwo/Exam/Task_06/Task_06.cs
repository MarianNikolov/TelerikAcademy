using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_06
{
    class Task_06
    {
        static void Main()
        {


            //var n = int.Parse(Console.ReadLine());



            Console.ReadLine();
            Console.ReadLine();

            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                 .ToList();
            Console.WriteLine(input.Sum() - input[0]);




        }
    }
}
