using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class Startup
    {
        static IDictionary<int, int> results;
        //static int index = 0;
        static void Main()
        {
            var input = Console.ReadLine();
            var numbers = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                var current = int.Parse(input[i].ToString());
                numbers.Add(current);
            }

            results = new Dictionary<int, int>();

            for (int i = 0; i < 10; i++)
            {
                results[i] = 0;
            }

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                Recursion(numbers, i);
            }

            Console.WriteLine(string.Join(" ", results.Values));
        }


        public static void Recursion(IList<int> numbers, int index)
        {
            if (numbers.Count == 1)
            {
                results[numbers[0]]++;
                return;
            }
            if (numbers.Count - 1 <= index)
            {
                return;
            }

            var a = numbers[index];
            var b = numbers[index + 1];

            var res = (a + b) * (a ^ b) % 10;

            var copiedNumbers = new List<int>(numbers);

            copiedNumbers.RemoveAt(index);
            copiedNumbers.RemoveAt(index);
            copiedNumbers.Insert(index, res);

            for (int i = 0; i < copiedNumbers.Count; i++)
            {
                Recursion(copiedNumbers, i);
            }
        }
    }
}
