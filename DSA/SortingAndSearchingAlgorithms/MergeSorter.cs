namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var sortetItems = MyMargeSort(collection);

            for (int i = 0; i < sortetItems.Count; i++)
            {
                collection[i] = sortetItems[i];
            }
        }

        private IList<T> MyMargeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int midIndex = collection.Count / 2;

            IList<T> left = collection.Take(midIndex).ToList();
            IList<T> right = collection.Skip(midIndex).ToList();

            left = MyMargeSort(left);
            right = MyMargeSort(right);

            return MargeItems(left, right);
        }

        private IList<T> MargeItems(IList<T> left, IList<T> right)
        {
            List<T> result = new List<T>();

            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            while (rightIndex < right.Count)
            {
                result.Add(right[rightIndex]);
                rightIndex++;
            }

            while (leftIndex < left.Count)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }

            return result;
        }
    }
}
