using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_ImplementTheADTQueue
{
    public class CustomLinkedQueue<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> internalList;

        public CustomLinkedQueue()
        {
            this.internalList = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.internalList.Count;
            }
        }

        public void Enqueue(T item)
        {
            this.internalList.AddLast(item);
        }

        public T Dequeue()
        {
            if (this.internalList.Count == 0)
            {
                throw new InvalidOperationException("No item to dequeue.");
            }

            var item = this.internalList.First;
            this.internalList.RemoveFirst();

            return item.Value;
        }

        public T Peek()
        {
            if (this.internalList.Count == 0)
            {
                throw new InvalidOperationException("No item to dequeue.");
            }

            return this.internalList.First.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.internalList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
