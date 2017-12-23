using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task_05
{
    class Task_05
    {
        static void Main()
        {
            var result = new StringBuilder();
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = input[0];

            var numbers = new OrderedBag<double>();
            
            while (command != "EXIT")
            {
                switch (command)
                {
                    case "ADD":
                        var number = double.Parse(input[1]);
                        numbers.Add(number);
                        break;

                    case "FIND":
                        int size = numbers.Count;
                        int mid = size / 2;
                        double median = (size % 2 != 0) ? (double)numbers[mid] : ((double)numbers[mid] + (double)numbers[mid - 1]) / 2;
                        result.AppendLine(median.ToString());
                        break;
                }


                input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

                command = input[0];
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
