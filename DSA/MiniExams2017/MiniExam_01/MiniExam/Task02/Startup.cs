using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task02
{
    public class Startup
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            var nodes = new MyLinkedListNode[N + 1];

            for (int i = 1; i <= N; ++i)
            {
                nodes[i] = new MyLinkedListNode(nodes[i - 1], i);
            }

            var left = nodes[1];
            var right = nodes[N];

            foreach (int number in numbers)
            {
                var middle = nodes[number];
                var nRight = middle.Left;
                var nLeft = middle.Right;

                MyLinkedListNode.Detach(middle);

                MyLinkedListNode.Attach(right, middle);

                MyLinkedListNode.Attach(middle, left);

                left = nLeft ?? middle;
                right = nRight ?? middle;
            }

            var results = new int[N];

            for (int i = 0; i < N; ++i)
            {
                results[i] = left.Value;
                left = left.Right;
            }

            Console.WriteLine(string.Join(" ", results));
        }
    }


    public class MyLinkedListNode
    {
        public MyLinkedListNode Left { get; private set; }
        public MyLinkedListNode Right { get; private set; }

        public int Value { get; private set; }

        public MyLinkedListNode(MyLinkedListNode previous, int value)
        {
            this.Value = value;

            this.Left = previous;
            this.Right = null;

            if (previous != null)
            {
                previous.Right = this;
            }
        }

        public static void Detach(MyLinkedListNode x)
        {
            if (x.Left != null)
            {
                x.Left.Right = null;
            }
            if (x.Right != null)
            {
                x.Right.Left = null;
            }

            x.Left = null;
            x.Right = null;
        }

        public static void Attach(MyLinkedListNode left, MyLinkedListNode right)
        {
            if (left == right)
            {
                return;
            }

            left.Right = right;
            right.Left = left;
        }
    }
}
