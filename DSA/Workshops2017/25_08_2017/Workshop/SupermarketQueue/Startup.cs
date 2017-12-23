using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;

namespace SupermarketQueue
{
    class Startup
    {
        public static void AddName(IDictionary<string, int> names, string name)
        {
            if (!names.ContainsKey(name))
            {
                names[name] = 1;
            }
            else
            {
                names[name]++;
            }
        }

        static void Main()
        {
            var result = new StringBuilder();
            var queue = new BucketList<string>();
            var names = new Dictionary<string, int>();

            var input = Console.ReadLine();
            var currentCommand = Command.Parse(input);

            while (true)
            {
                string name = string.Empty;

                switch (currentCommand.Name)
                {
                                        case "Append":
                        name = currentCommand.Parameters[0];
                        AddName(names, name);

                        queue.Add(name);
                        result.AppendLine("OK");
                        break;

                    

                    case "Insert":
                        var position = int.Parse(currentCommand.Parameters[0]);
                        name = currentCommand.Parameters[1];
                        AddName(names, name);

                        if (position > queue.Size || position < 0)
                        {
                            result.AppendLine("Error");
                            break;
                        }

                        queue.Insert(position, name);
                        result.AppendLine("OK");
                        break;

                                        case "Find":
                        name = currentCommand.Parameters[0];

                        if (!names.ContainsKey(name))
                        {
                            result.AppendLine("0");
                        }
                        else
                        {
                            result.AppendLine(names[name].ToString());
                        }
                        break;

                    

                    case "Serve":
                        var count = int.Parse(currentCommand.Parameters[0]);

                        if (count > queue.Size || count < 0)
                        {
                            result.AppendLine("Error");
                            break;
                        }

                        var currentResult = new List<string>();
                        for (int i = 0; i < count; i++)
                        {
                            currentResult.Add(queue[0]);
                            queue.Remove(0);
                        }

                        for (int i = 0; i < currentResult.Count; i++)
                        {
                            names[currentResult[i]]--;
                        }

                        result.AppendLine(string.Join(" ", currentResult));
                        break;

                    case "End":
                        Console.WriteLine(result.ToString());
                        return;
                }

                input = Console.ReadLine();
                currentCommand = Command.Parse(input);
            }

        }
    }

    public class Command
    {
        public string Name { get; private set; }

        public IList<string> Parameters { get; private set; }

        public static Command Parse(string input)
        {
            string[] splitedInput = input.Split(' ');

            var splitedInputParameters = new List<string>();
            for (int i = 1; i < splitedInput.Length; i++)
            {
                splitedInputParameters.Add(splitedInput[i]);
            }

            return new Command
            {
                Name = splitedInput[0],
                Parameters = splitedInputParameters
            };
        }
    }


    class Bucket<T>
    {
        private T[] buffer;
        private int startIndex;
        private int endIndex;
        private int size;

        public Bucket(int bucketSize)
        {
            buffer = new T[bucketSize];
            startIndex = 0;
            endIndex = 0;
            size = 0;
        }

        public Bucket(Bucket<T> left, Bucket<T> right)
        {
            size = left.size + right.size;
            buffer = new T[size];
            startIndex = 0;
            endIndex = 0;

            for (int i = 0; i < left.size; ++i)
            {
                buffer[i] = left[i];
            }
            for (int i = 0; i < right.size; i++)
            {
                buffer[left.size + i] = left[i];
            }
        }

        public Bucket(bool left, Bucket<T> both)
        {
            size = both.buffer.Length / 2;
            buffer = new T[size];
            startIndex = 0;
            endIndex = 0;

            for (int i = 0, j = left ? 0 : size;
                i < size;
                ++i, ++j)
            {
                buffer[i] = both[j];
            }
        }

        public bool Full => size == buffer.Length;
        public bool Empty => size == 0;

        public T this[int index]
        {
            get
            {
                return buffer[AdaptIndex(index)];
            }
            set
            {
                buffer[AdaptIndex(index)] = value;
            }
        }

        public void ShiftRight(T value)
        {
            startIndex = PrevIndex(startIndex);
            buffer[startIndex] = value;

            if (Full)
            {
                endIndex = startIndex;
            }
            else
            {
                ++size;
            }
        }

        public void ShiftLeft(T value)
        {
            buffer[endIndex] = value;
            endIndex = NextIndex(endIndex);
            startIndex = endIndex;
        }

        public void PopFirst()
        {
            buffer[startIndex] = default(T);
            startIndex = NextIndex(startIndex);
            --size;
        }

        public void PopBack()
        {
            --size;
        }

        public void Insert(int index, T value)
        {
            int realIndex = AdaptIndex(index);

            int destinationIndex = endIndex;

            if (Full)
            {
                destinationIndex = PrevIndex(destinationIndex);
            }
            int sourceIndex = PrevIndex(destinationIndex);

            while (destinationIndex != realIndex)
            {
                buffer[destinationIndex] = buffer[sourceIndex];
                destinationIndex = sourceIndex;
                sourceIndex = PrevIndex(sourceIndex);
            }

            buffer[realIndex] = value;

            if (!Full)
            {
                endIndex = NextIndex(endIndex);
                ++size;
            }
        }

        public void Remove(int index)
        {
            int destinationIndex = AdaptIndex(index);
            int sourceIndex = NextIndex(destinationIndex);
            while (sourceIndex != endIndex)
            {
                buffer[destinationIndex] = buffer[sourceIndex];
                destinationIndex = sourceIndex;
                sourceIndex = NextIndex(sourceIndex);
            }

            endIndex = PrevIndex(endIndex);
        }

        private int AdaptIndex(int index)
        {
            int realIndex = startIndex + index;
            if (realIndex >= buffer.Length)
            {
                realIndex -= buffer.Length;
            }
            return realIndex;
        }

        private int PrevIndex(int index)
        {
            if (index == 0)
            {
                return buffer.Length - 1;
            }

            return index - 1;
        }

        private int NextIndex(int index)
        {
            if (index == buffer.Length - 1)
            {
                return 0;
            }

            return index + 1;
        }
    }




    public class BucketList<T> : IBucketList<T>
    {
        private const int MIN_BUCKET_SIZE = 4;

        private int bucketSize;
        private List<Bucket<T>> buckets;

        public BucketList()
        {
            Clear();
        }

        public T this[int index]
        {
            get
            {
                return buckets[index / bucketSize][index % bucketSize];
            }

            set
            {
                buckets[index / bucketSize][index % bucketSize] = value;
            }
        }

        public int Size { get; private set; }

        public void Add(T value)
        {
            Insert(Size, value);
        }

        public void Clear()
        {
            bucketSize = MIN_BUCKET_SIZE;
            buckets = new List<Bucket<T>>();
            Size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; ++i)
            {
                yield return this[i];
            }
        }

        public void Insert(int index, T value)
        {
            if (buckets.Count == bucketSize * 2
                && buckets[buckets.Count - 1].Full)
            {
                var largerBuckets = new List<Bucket<T>>();

                largerBuckets.Capacity = buckets.Count / 2; // will work without

                for (int i = 0; i < buckets.Count; i += 2)
                {
                    largerBuckets.Add(
                        new Bucket<T>(buckets[i], buckets[i + 1]));
                }

                bucketSize *= 2;
                buckets = largerBuckets;
            }

            if (buckets.Count == 0 || buckets[buckets.Count - 1].Full)
            {
                var newBucket = new Bucket<T>(bucketSize);
                buckets.Add(newBucket);
            }

            int destinationBucketIndex = buckets.Count - 1;
            int sourceBucketIndex = destinationBucketIndex - 1;

            int targetBucketIndex = index / bucketSize;
            int targetIndexInBucket = index % bucketSize;

            while (destinationBucketIndex != targetBucketIndex)
            {
                buckets[destinationBucketIndex]
                    .ShiftRight(buckets[sourceBucketIndex][bucketSize - 1]);

                --destinationBucketIndex;
                --sourceBucketIndex;
            }

            buckets[targetBucketIndex].Insert(targetIndexInBucket, value);
            ++Size;
        }

        public void Remove(int index)
        {
            // Needs debugging
            --Size;

            int targetBucketIndex = index / bucketSize;
            int targetIndexInBucket = index % bucketSize;

            buckets[targetBucketIndex].Remove(targetIndexInBucket);

            // This is a HACK!!!
            if (targetBucketIndex < buckets.Count - 1)
            {
                int destinationBucketIndex = targetBucketIndex;
                int sourceBucketIndex = destinationBucketIndex + 1;
                while (sourceBucketIndex < buckets.Count)
                {
                    buckets[destinationBucketIndex]
                        .ShiftLeft(buckets[sourceBucketIndex][0]);
                    ++sourceBucketIndex;
                    ++destinationBucketIndex;
                }

                buckets[buckets.Count - 1].PopFirst();
            }
            else
            {
                buckets[buckets.Count - 1].PopBack();
            }

            if (buckets[buckets.Count - 1].Empty)
            {

                buckets.RemoveAt(buckets.Count - 1);

                if (bucketSize == buckets.Count * 2
                    && buckets.Count >= MIN_BUCKET_SIZE)
                {
                    var smallerBuckets = new List<Bucket<T>>();
                    foreach (var bucket in buckets)
                    {
                        smallerBuckets.Add(
                            new Bucket<T>(true, bucket));
                        smallerBuckets.Add(
                            new Bucket<T>(false, bucket));
                    }

                    bucketSize /= 2;
                    buckets = smallerBuckets;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }




    public interface IBucketList<T> : IEnumerable<T>
    {
        T this[int index] { get; set; }

        int Size { get; }

        void Add(T value);

        void Insert(int index, T value);

        void Remove(int index);

        void Clear();
    }

}
