using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogLoveSpaper
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var graph = new Dictionary<int, HashSet<int>>();
            var sb = new StringBuilder();
            var isFirstIteration = true;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var first = int.Parse(input[0]);
                var second = int.Parse(input[3]);
                var direction = input[2];

                if (!graph.ContainsKey(first))
                {
                    graph[first] = new HashSet<int>();
                }
                if (!graph.ContainsKey(second))
                {
                    graph[second] = new HashSet<int>();
                }

                switch (direction)
                {
                    case "after":
                        graph[first].Add(second);
                        break;
                    case "before":
                        graph[second].Add(first);
                        break;
                }
            }

            var initialGraphCount = graph.Count;

            while (graph.Count > 0)
            {
                if (initialGraphCount != graph.Count)
                {
                    isFirstIteration = false;
                }

                var currentMin = int.MaxValue;
                foreach (var key in graph.Keys)
                {
                    if (graph[key].Count == 0)
                    {
                        if (currentMin > key)
                        {
                            if (isFirstIteration && key == 0)
                            {
                                continue;
                            }
                            else
                            {
                                currentMin = key;
                            }
                        }
                    }
                }

                graph.Remove(currentMin);

                foreach (var key in graph.Keys)
                {
                    if (graph[key].Contains(currentMin))
                    {
                        graph[key].Remove(currentMin);
                    }
                }

                sb.Append(currentMin);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
