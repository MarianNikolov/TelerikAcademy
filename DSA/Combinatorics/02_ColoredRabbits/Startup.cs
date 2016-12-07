using System;
using System.Collections.Generic;

namespace _02_ColoredRabbits
{
    public class Startup
    {
        public static void Main()
        {
            var groups = new Dictionary<int, int>();

            var answers = int.Parse(Console.ReadLine());

            for (int i = 0; i < answers; i++)
            {
                var currentAnswer = int.Parse(Console.ReadLine());

                if (groups.ContainsKey(currentAnswer))
                {
                    groups[currentAnswer]++;
                }
                else
                {
                    groups.Add(currentAnswer, 1);
                }
            }

            long result = 0;

            foreach (var group in groups)
            {
                var currentGroupCount = group.Key + 1;
                var currentGroupMembers = group.Value;

                if (currentGroupCount > currentGroupMembers)
                {
                    result += currentGroupCount;
                }
                else
                {
                    result += (long)Math.Ceiling(((decimal)currentGroupMembers / (decimal)currentGroupCount)) * currentGroupCount;
                }
            }

            Console.WriteLine(result);
        }
    }
}
