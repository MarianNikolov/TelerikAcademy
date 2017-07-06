using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diameter
{
    // A tree structure consisted of N nodes is given.Nodes are numbered from 0 to N-1.
    // The length of a path between two edges is the sum of the lengths of all the edges between them.
    // Find the length of the longest path in the tree.

    public class Startup
    {
        public static Graph graph = new Graph();
        public static long maxPath = 0;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                graph.AddNode(i, new Node(i));
            }

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x));

                //TODO attach edges to nodes
            }

            FindSumOfEdges(0, 0);

            Console.WriteLine(maxPath);
        }


        public static void FindSumOfEdges(int currentNodeValue, int index)
        {
            var currentNode = graph.Nodes[currentNodeValue];
            var suggestedMax = maxPath + currentNode.Edges[index].Distance;

            if (suggestedMax > maxPath)
            {
                maxPath = suggestedMax;
            }


            for (int i = 0; i < currentNode.Edges.Count; i++)
            {
                FindSumOfEdges(currentNodeValue + 1, i);
            }

        }
    }

    public class Graph
    {
        public IDictionary<int, Node> Nodes;

        public Graph()
        {
            this.Nodes = new Dictionary<int, Node>();
        }

        public void AddNode(int value, Node node)
        {
            this.Nodes[value] = node;
        }
    }

    public class Node
    {
        public IList<Edge> Edges;
        public int Value;

        public Node(int value)
        {
            this.Value = value;
            this.Edges = new List<Edge>();
        }
    }

    public class Edge
    {
        public Edge(Node target, long distance)
        {
            this.Target = target;
            this.Distance = distance;
        }

        public Node Target { get; private set; }

        public long Distance { get; private set; }
    }
}
