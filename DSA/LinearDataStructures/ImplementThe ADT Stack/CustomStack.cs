using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementTheADTStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialSize = 5;

        private T[] initialArray;
        private int size;
        private int pointer;

        public CustomStack() : this(InitialSize)
        {
        }

        public CustomStack(int size)
        {
            this.initialArray = new T[size];
            this.pointer = -1;
            this.size = size;
        }

        public int Count
        {
            get
            {
                return this.pointer + 1;
            }
        }

        public void Push(T element)
        {
            ++this.pointer;

            if (this.pointer == this.size)
            {
                this.DoubleSize();
            }

            this.initialArray[this.pointer] = element;
        }

        public T Peek()
        {
            if (this.pointer < 0)
            {
                throw new NullReferenceException("Tha stack does not contain any elements");
            }

            return this.initialArray[this.pointer];
        }

        public T Pop()
        {
            if (this.pointer < 0)
            {
                throw new NullReferenceException("Tha stack does not contain any elements");
            }
            else
            {
                this.pointer--;
                return this.initialArray[this.pointer + 1];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.pointer; i++)
            {
                yield return this.initialArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void DoubleSize()
        {
            var temp = new T[this.size * 2];
            Array.Copy(this.initialArray, temp, this.initialArray.Length);
            this.initialArray = temp;
            this.size = this.initialArray.Length;
        }
    }
}
