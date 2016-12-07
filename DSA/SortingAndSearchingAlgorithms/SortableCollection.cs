namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            bool isContains = false;

            for (int i = 0; i < this.items.Count; i++)
            {
                if (item.CompareTo(items[i]) == 0)
                {
                    isContains = true;

                    break;
                }
            }

            return isContains;
        }

        public bool BinarySearch(T item)
        {
            int currentIndex = 0;
            bool isContains = false;

            int leftIndex = 0;
            int rightIndex = this.items.Count - 1;

            while (leftIndex + 1 < rightIndex)
            {
                int midIndex = (leftIndex + rightIndex) / 2;

                if (item.CompareTo(this.items[midIndex]) == 0)
                {
                    isContains = true;

                    break;
                }
                else if (item.CompareTo(this.items[midIndex]) < 0)
                {
                    rightIndex = midIndex - 1;
                }
                else if (item.CompareTo(this.items[midIndex]) > 0)
                {
                    leftIndex = midIndex + 1;
                }
                
            }

            currentIndex++;

            return isContains;
        }

        public void Shuffle()
        {
            int currentIndex = 0;
            var random = new Random();

            for (int i = 1; i < this.items.Count - 1; i++)
            {
                var indexForSwap = random.Next(i, this.items.Count);

                Swap(currentIndex, indexForSwap);

                currentIndex++;
            }
            
        }

        private void Swap(int first, int second)
        {
            var temp = this.items[first];
            this.items[first] = this.items[second];
            this.items[second] = temp;
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
