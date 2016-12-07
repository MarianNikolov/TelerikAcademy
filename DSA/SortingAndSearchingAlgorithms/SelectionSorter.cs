namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            T currentItem = collection[0];

            for (int i = 1; i < collection.Count; i++)
            {
                for (int j = i; j < collection.Count; j++)
                {
                    if (currentItem.CompareTo(collection[j]) > 0)
                    {
                        Swap(collection, i-1, j);
                    }
                }

                currentItem = collection[i];
            }
        }

        private void Swap(IList<T> collection, int firstIndex, int secondIndex)
        {
            T oldFirstItem = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = oldFirstItem;
        }
    }
}
