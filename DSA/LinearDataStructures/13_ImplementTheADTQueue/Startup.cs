using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_ImplementTheADTQueue
{
    // 13. Implement the ADT queue as dynamic linked list.
        // Use generics(LinkedQueue<T>) to allow storing different data types in the queue.

    public class Startup
    {
        static void Main()
        {
            var customQueue = new CustomLinkedQueue<int>();
            new List<int> { 1, 2, 3, 4, 5 }.ForEach(x => customQueue.Enqueue(x));

            Console.WriteLine("CustomLinkedQueue:");
            Console.WriteLine();

            while (customQueue.Count > 0)
            {
                Console.WriteLine(customQueue.Dequeue());
            }

        }
    }
}
