using System.Collections;
using System.Collections.Generic;

namespace ImplementLinkedList
{
    public class LinkedList<T>
    {
        public LinkedList()
        {
        }

        public LinkedList(ListItem<T> firstItem)
        {
            this.FirstItem = firstItem;
        }

        public ListItem<T> FirstItem { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            var currentItem = this.FirstItem;

            while (currentItem != null)
            {
                yield return currentItem.Value;

                currentItem = currentItem.NextItem;
            }
        }
    }
}
