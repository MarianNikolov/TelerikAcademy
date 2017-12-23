using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Nightmare_on_Code_Street
{
    class NightmareОnCodeStreet
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            long counter = 0;
            List<long> listOfIntegers = new List<long>();
            long convertedListNumbers = 0;
            long sum = 0;
            long newSum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 == 1 )
                {
                    if (char.IsDigit(text[i]))
                    {
                        listOfIntegers.Add(text[i]);
                        counter++;
                    }
                }
            }

            for (int i = 0; i < listOfIntegers.Count; i++)
            {
                convertedListNumbers = listOfIntegers[i] - 48;
                sum = convertedListNumbers;
                newSum += sum;
            }
            Console.WriteLine(counter + " " + newSum);
        }
    }
}
