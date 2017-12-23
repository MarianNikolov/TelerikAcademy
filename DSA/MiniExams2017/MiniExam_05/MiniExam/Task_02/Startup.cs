using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var N = int.Parse(input[0]);
            var M = int.Parse(input[1]);

            var bridges = new List<Bridge>();

            for (int i = 0; i < M; i++)
            {
                var currentInput = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();

                var from = currentInput[0];
                var to = currentInput[1];
                var weight = currentInput[2];

                var currentBridge = new Bridge() { From = from, To = to, Weight = weight };
                bridges.Add(currentBridge);
            }

            var busWeight = int.Parse(Console.ReadLine());

            bridges.Sort((firstNode, secondNode) => secondNode.Weight - firstNode.Weight);

            var total = 0;

            var unionFindArray = Enumerable.Range(0, M).ToArray();

            for (int i = 0; i < M; i++)
            {
                unionFindArray[i] = -1;
            }

            foreach (var bridge in bridges)
            {
                if (Union(unionFindArray, bridge.From, bridge.To))
                {
                    if (bridge.Weight < busWeight)
                    {
                        total += 1;
                    }
                }
            }

            Console.WriteLine(total);
        }

        static int Find(int[] array, int node)
        {
            if (array[node] == -1)
            {
                return node;
            }
            array[node] = Find(array, array[node]);
            return array[node];
        }

        static bool Union(int[] array, int firstNode, int secondNode)
        {
            firstNode = Find(array, firstNode);
            secondNode = Find(array, secondNode);

            if (firstNode == secondNode)
            {
                return false;
            }

            array[firstNode] = secondNode;
            return true;
        }
    }

    public struct Bridge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }
}
