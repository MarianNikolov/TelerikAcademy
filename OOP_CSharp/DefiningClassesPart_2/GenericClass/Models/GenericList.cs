namespace GenericClass.Models
{
    using System;
    using System.Text;

    class GenericList<T> where T : IComparable<T>
    {
        private T[] data;
        private int nextIndex = 0;

        public GenericList(int initialCapacity)
        {
            this.data = new T[initialCapacity];
        }

        public T this[int index]
        {
            get
            {
                if (index > this.nextIndex - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.data[index];
            }
            private set
            {
                this.data[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.nextIndex == this.data.Length)
            {
                // throw new IndexOutOfRangeException();
                this.AutoGrow();
            }
            this.data[nextIndex] = element;
            this.nextIndex++;
        }

        public void Remove(int index)
        {
            for (int i = index; i < this.nextIndex 
                && i < this.data.Length - 1; i++)
            {
                this.data[i] = this.data[i + 1];
            }

            this.nextIndex--;
            this.data[nextIndex] = default(T);
        }

        public void Insert(int index, T element)
        {
            if (this.nextIndex == this.data.Length)
            {
                // throw new IndexOutOfRangeException();
                this.AutoGrow();
            }

            for (int i = this.nextIndex; i >= index && i > 0; i--)
            {
                this.data[i] = this.data[i - 1];
            }

            this.data[index] = element;
            this.nextIndex++;
        }

        public void Clear()
        {
            this.data = new T[this.data.Length];
        }

        public T Min()
        {
            if (this.nextIndex == 0)
            {
                throw new ArgumentException(
                    "There are no element in the GenericList");
            }

            var min = this.data[0];

            foreach (T item in this.data)
            {
                if (min.CompareTo(item) > 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public T Max()
        {
            if (this.nextIndex == 0)
            {
                throw new ArgumentException(
                    "There are no element in the GenericList");
            }

            var max = this.data[0];

            foreach (T item in this.data)
            {
                if (max.CompareTo(item) < 0)
                {
                    max = item;
                }
            }

            return max;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.nextIndex; i++)
            {
                sb.Append(this.data[i]);
                if (i < this.nextIndex - 1)
                {
                    sb.Append(", ");
                }
            }
            return sb.ToString();
        }

        private void AutoGrow()
        {
            var newData = new T[this.data.Length * 2];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }
    }
}
