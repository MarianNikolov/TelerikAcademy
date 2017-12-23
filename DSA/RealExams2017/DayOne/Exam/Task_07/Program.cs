using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task_07
{
    class Program
    {
        static void Main()
        {
            var numbers = new Dictionary<int, NumberWithValue>();
            var numbersSet = new List<NumberWithValue>();
            var result = new StringBuilder();

            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = input[0];
            var currentValue = int.Parse(input[1]);


            while (command != "END")
            {
                switch (command)
                {
                    case "ADD":
                        NumberWithValue currentNumberWithValue;
                        if (!numbers.ContainsKey(currentValue))
                        {
                            currentNumberWithValue = new NumberWithValue(currentValue);
                            numbers.Add(currentValue, currentNumberWithValue);
                            numbersSet.Add(currentNumberWithValue);
                        }
                        else
                        {
                            numbers[currentValue].CountOfFrequents++;
                        }

                        result.AppendLine(string.Format("Ok: {0} added", currentValue));
                        break;

                    case "REMOVE":
                        if (!numbers.ContainsKey(currentValue))
                        {
                            result.AppendLine(string.Format("Error: Number {0} not found", currentValue));
                        }
                        else
                        {
                            var currentForUpdate = numbers[currentValue];
                            currentForUpdate.CountOfFrequents -= 1;

                            if (numbers[currentValue].CountOfFrequents == 0)
                            {
                                var forRemove = numbers[currentValue];
                                numbersSet.Remove(forRemove);
                                numbers.Remove(currentValue);
                            }

                            result.AppendLine(string.Format("Ok: Number {0} removed", currentValue));
                        }
                        break;

                    case "GET":
                        if (currentValue > numbersSet.Count || currentValue <= 0)
                        {
                            result.AppendLine(string.Format("Error: {0} is invalid K", currentValue));
                        }
                        else
                        {
                            var currentResult = numbersSet.ElementAt(currentValue - 1);

                            result.AppendLine(string.Format("Ok: Found {0}", currentResult.Value));
                        }

                        break;
                }

                input = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .ToList();

                if (input.Count == 1)
                {
                    break;
                }

                command = input[0];
                currentValue = int.Parse(input[1]);
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }

    class NumberWithValue : IComparable<NumberWithValue>
    {
        public int Value { get; set; }

        public int CountOfFrequents { get; set; }

        public NumberWithValue(int value)
        {
            this.Value = value;
            this.CountOfFrequents = 1;
        }

        public int CompareTo(NumberWithValue other)
        {
            int result = other.CountOfFrequents.CompareTo(this.CountOfFrequents);

            if (result == 0)
            {
                result = this.Value.CompareTo(other.Value);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            var other = obj as NumberWithValue;
            if (other == null)
            {
                return false;
            }

            return this.Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return 23 + this.CountOfFrequents.GetHashCode() >> 17 ^
                   (23 + this.Value.GetHashCode() >> 17);
        }
    }
}
