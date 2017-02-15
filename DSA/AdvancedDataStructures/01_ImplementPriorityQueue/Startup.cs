using System;

namespace _01_ImplementPriorityQueue
{
    // 01. Implement a class PriorityQueue<T> based on the data structure "binary heap".

    public class Startup
    {
        static void Main()
        {
            MinQueue();
            Console.WriteLine();
            MaxQueue();
        }

        private static void MinQueue()
        {
            Console.WriteLine("Min priority: ");
            var queue = new PriorityQueue<int>(true);

            Console.WriteLine("Count: " + queue.Count);

            queue.Enqueue(9);
            queue.Enqueue(7);
            queue.Enqueue(5);
            queue.Enqueue(3);
            queue.Enqueue(1);

            Console.WriteLine("Count: " + queue.Count);
            Console.WriteLine(queue.ToString());
            Console.WriteLine("Dequeue:");

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }

        private static void MaxQueue()
        {
            Console.WriteLine("Max priority: ");
            var queue = new PriorityQueue<int>(false);

            Console.WriteLine("Count: " + queue.Count);

            queue.Enqueue(0);
            queue.Enqueue(2);
            queue.Enqueue(4);
            queue.Enqueue(6);
            queue.Enqueue(8);

            Console.WriteLine("Count: " + queue.Count);
            Console.WriteLine(queue.ToString());
            Console.WriteLine("Dequeue:");

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}