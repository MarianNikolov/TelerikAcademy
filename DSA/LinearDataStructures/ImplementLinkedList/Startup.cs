using System;

namespace ImplementLinkedList
{
    // 11. Implement the data structure linked list.
    // Define a class ListItem<T> that has two fields: value(of type T) and NextItem(of type ListItem<T>).
    // Define additionally a class LinkedList<T> with a single field FirstElement(of type ListItem<T>).

    public class Startup
    {
        static void Main()
        {
            var list = new LinkedList<int>();
            var firstItem = new ListItem<int>(1);

            list.FirstItem = firstItem;
            firstItem.NextItem = new ListItem<int>(2);

            list.FirstItem.NextItem.NextItem = new ListItem<int>(3);
            list.FirstItem.NextItem.NextItem.NextItem = new ListItem<int>(4);
            list.FirstItem.NextItem.NextItem.NextItem.NextItem = new ListItem<int>(5);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
