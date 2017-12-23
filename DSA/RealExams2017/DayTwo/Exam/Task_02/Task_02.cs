using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task_02
{
    class Task_02
    {
        static Queue<string> personDependencies = new Queue<string>();
        static Dictionary<string, Dictionary<string, List<string>>> graph = new Dictionary<string, Dictionary<string, List<string>>>();
        static SortedSet<string> dependencies = new SortedSet<string>();

        static void Main()
        {
            var result = new StringBuilder();
            var currentResult = new List<string>();

            var n = int.Parse(Console.ReadLine());

            // build graph
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var currnetInput = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                var person = currnetInput[0];
                var dependsOn = currnetInput[1];
                var subject = input.Substring(currnetInput[0].Length + currnetInput[1].Length + 2);

                if (!graph.ContainsKey(subject))
                {
                    graph.Add(subject, new Dictionary<string, List<string>>());
                    graph[subject].Add(person, new List<string>());
                    graph[subject][person].Add(dependsOn);
                }
                else if (!graph[subject].ContainsKey(person))
                {
                    graph[subject].Add(person, new List<string>());
                    graph[subject][person].Add(dependsOn);
                }
                else
                {
                    if (!graph[subject][person].Contains(dependsOn))
                    {
                        graph[subject][person].Add(dependsOn);
                    }
                }
            }

            // solution
            var y = int.Parse(Console.ReadLine());
            for (int i = 0; i < y; i++)
            {
                var input = Console.ReadLine();
                var currnetInput = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var person = currnetInput[0];
                var subject = input.Substring(currnetInput[0].Length + 1);

                //if (!graph.ContainsKey(subject))
                //{
                //    continue;
                //}

                //if (!graph[subject].ContainsKey(person))
                //{
                //    result.AppendLine(person);
                //    continue;
                //}

                //if (graph[subject][person].Count == 0)
                //{
                //    result.AppendLine(person);
                //    continue;
                //}

                currentResult.Add(person);

                Recursion(currentResult, subject, person);

                currentResult.Reverse();
                result.AppendLine(string.Join(", ", currentResult));
                currentResult.Clear();
            }

            Console.WriteLine(result.ToString().Trim());
        }

        private static void Recursion(List<string> currentResult, string subject, string person)
        {
            if (!graph[subject].ContainsKey(person))
            {
                return;
            }

            for (int i = 0; i < graph[subject][person].Count; i++)
            {
                dependencies.Add(graph[subject][person][i]);
            }

            foreach (var item in dependencies)
            {
                if (currentResult.Contains(item))
                {
                    continue;
                }

                currentResult.Add(item);
                personDependencies.Enqueue(item);
            }

            dependencies.Clear();

            Recursion(currentResult, subject, personDependencies.Dequeue());

            if (personDependencies.Count == 0)
            {
                return;
            }
        }
    }
}
