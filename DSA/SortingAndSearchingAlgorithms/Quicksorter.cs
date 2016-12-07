namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var sortedItems = MyQuickSort(collection);

            for (int i = 0; i < sortedItems.Count; i++)
            {
                collection[i] = sortedItems[i];
            }
        }

        private IList<T> MyQuickSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            Random random = new Random();
            int pivotIndex = random.Next(0, collection.Count);
            T pivot = collection[pivotIndex];

            var left = new List<T>();
            var right = new List<T>();

            for (int i = 0; i < pivotIndex; i++)
            {
                if (collection[i].CompareTo(pivot) <= 0)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            for (int i = pivotIndex + 1; i < collection.Count; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            List<T> result = new List<T>();

            result.AddRange(MyQuickSort(left));
            result.Add(pivot);
            result.AddRange(MyQuickSort(right));

            return result;
        }
    }
}
