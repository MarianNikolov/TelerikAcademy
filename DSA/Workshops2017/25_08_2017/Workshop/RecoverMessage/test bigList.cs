using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;

namespace SupermarketQueue
{
    class Test
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

        static void Main1()
        {
            var result = new StringBuilder();
            var queue = new BigList<string>();
            var names = new Dictionary<string, int>();

            var input = Console.ReadLine();
            var currentCommand = Command1.Parse(input);

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

                        if (position > queue.Count || position < 0)
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

                        if (count > queue.Count || count < 0)
                        {
                            result.AppendLine("Error");
                            break;
                        }

                        var currentResult = queue.GetRange(0, count);
                        queue.RemoveRange(0, count);

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
                currentCommand = Command1.Parse(input);
            }

        }
    }

    public class Command1
    {
        public string Name { get; private set; }

        public IList<string> Parameters { get; private set; }

        public static Command1 Parse(string input)
        {
            string[] splitedInput = input.Split(' ');

            var splitedInputParameters = new List<string>();
            for (int i = 1; i < splitedInput.Length; i++)
            {
                splitedInputParameters.Add(splitedInput[i]);
            }

            return new Command1
            {
                Name = splitedInput[0],
                Parameters = splitedInputParameters
            };
        }
    }





#if !PCL
    [Serializable]
#endif
    public class BigList<T> : ListBase<T>
#if !PCL
        , ICloneable
#endif
    {
        const uint MAXITEMS = int.MaxValue - 1;
#if DEBUG
        const int MAXLEAF = 8;
#else
        const int MAXLEAF = 120;               
#endif
        const int BALANCEFACTOR = 6; static readonly int[] FIBONACCI = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733, 1134903170, 1836311903, int.MaxValue }; const int MAXFIB = 44; private Node root; private int changeStamp; private void StopEnumerations()
        { ++changeStamp; }
        private void CheckEnumerationStamp(int startStamp)
        {
            if (startStamp != changeStamp)
            { throw new InvalidOperationException(Strings.ChangeDuringEnumeration); }
        }
        public BigList()
        { root = null; }
        public BigList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); root = NodeFromEnumerable(collection); CheckBalance();
        }
        public BigList(IEnumerable<T> collection, int copies)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); root = NCopiesOfNode(copies, NodeFromEnumerable(collection)); CheckBalance();
        }
        public BigList(BigList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (list.root == null)
                root = null;
            else
            { list.root.MarkShared(); root = list.root; }
        }
        public BigList(BigList<T> list, int copies)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (list.root == null)
                root = null;
            else
            { list.root.MarkShared(); root = NCopiesOfNode(copies, list.root); }
        }
        private BigList(Node node)
        { this.root = node; CheckBalance(); }
        public sealed override int Count
        {
            get
            {
                if (root == null)
                    return 0;
                else
                    return root.Count;
            }
        }
        public sealed override T this[int index]
        {
            get
            {
                if (root == null || index < 0 || index >= root.Count)
                    throw new ArgumentOutOfRangeException("index"); Node current = root; ConcatNode curConcat = current as ConcatNode; while (curConcat != null)
                {
                    int leftCount = curConcat.left.Count; if (index < leftCount)
                        current = curConcat.left;
                    else
                    { current = curConcat.right; index -= leftCount; }
                    curConcat = current as ConcatNode;
                }
                LeafNode curLeaf = (LeafNode)current; return curLeaf.items[index];
            }
            set
            {
                if (root == null || index < 0 || index >= root.Count)
                    throw new ArgumentOutOfRangeException("index"); StopEnumerations(); if (root.Shared)
                    root = root.SetAt(index, value); Node current = root; ConcatNode curConcat = current as ConcatNode; while (curConcat != null)
                {
                    int leftCount = curConcat.left.Count; if (index < leftCount)
                    {
                        current = curConcat.left; if (current.Shared)
                        { curConcat.left = current.SetAt(index, value); return; }
                    }
                    else
                    {
                        current = curConcat.right; index -= leftCount; if (current.Shared)
                        { curConcat.right = current.SetAt(index, value); return; }
                    }
                    curConcat = current as ConcatNode;
                }
                LeafNode curLeaf = (LeafNode)current; curLeaf.items[index] = value;
            }
        }
        public sealed override void Clear()
        { StopEnumerations(); root = null; }
        public sealed override void Insert(int index, T item)
        {
            StopEnumerations(); if ((uint)Count + 1 > MAXITEMS)
                throw new InvalidOperationException(Strings.CollectionTooLarge); if (index <= 0 || index >= Count)
            {
                if (index == 0)
                    AddToFront(item);
                else if (index == Count)
                    Add(item);
                else
                    throw new ArgumentOutOfRangeException("index");
            }
            else
            {
                if (root == null)
                    root = new LeafNode(item);
                else
                {
                    Node newRoot = root.InsertInPlace(index, item); if (newRoot != root)
                    { root = newRoot; CheckBalance(); }
                }
            }
        }
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            StopEnumerations(); if (collection == null)
                throw new ArgumentNullException("collection"); if (index <= 0 || index >= Count)
            {
                if (index == 0)
                    AddRangeToFront(collection);
                else if (index == Count)
                    AddRange(collection);
                else
                    throw new ArgumentOutOfRangeException("index");
            }
            else
            {
                Node node = NodeFromEnumerable(collection); if (node == null)
                    return;
                else if (root == null)
                    root = node;
                else
                {
                    if ((uint)Count + (uint)node.Count > MAXITEMS)
                        throw new InvalidOperationException(Strings.CollectionTooLarge); Node newRoot = root.InsertInPlace(index, node, true); if (newRoot != root)
                    { root = newRoot; CheckBalance(); }
                }
            }
        }
        public void InsertRange(int index, BigList<T> list)
        {
            StopEnumerations(); if (list == null)
                throw new ArgumentNullException("list"); if ((uint)Count + (uint)list.Count > MAXITEMS)
                throw new InvalidOperationException(Strings.CollectionTooLarge); if (index <= 0 || index >= Count)
            {
                if (index == 0)
                    AddRangeToFront(list);
                else if (index == Count)
                    AddRange(list);
                else
                    throw new ArgumentOutOfRangeException("index");
            }
            else
            {
                if (list.Count == 0)
                    return; if (root == null)
                { list.root.MarkShared(); root = list.root; }
                else
                {
                    if (list.root == root)
                        root.MarkShared(); Node newRoot = root.InsertInPlace(index, list.root, false); if (newRoot != root)
                    { root = newRoot; CheckBalance(); }
                }
            }
        }
        public sealed override void RemoveAt(int index)
        { RemoveRange(index, 1); }
        public void RemoveRange(int index, int count)
        {
            if (count == 0)
                return; if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("index"); if (count < 0 || count > Count - index)
                throw new ArgumentOutOfRangeException("count"); StopEnumerations(); Node newRoot = root.RemoveRangeInPlace(index, index + count - 1); if (newRoot != root)
            { root = newRoot; CheckBalance(); }
        }
        public sealed override void Add(T item)
        {
            if ((uint)Count + 1 > MAXITEMS)
                throw new InvalidOperationException(Strings.CollectionTooLarge); StopEnumerations(); if (root == null)
                root = new LeafNode(item);
            else
            {
                Node newRoot = root.AppendInPlace(item); if (newRoot != root)
                { root = newRoot; CheckBalance(); }
            }
        }
        public void AddToFront(T item)
        {
            if ((uint)Count + 1 > MAXITEMS)
                throw new InvalidOperationException(Strings.CollectionTooLarge); StopEnumerations(); if (root == null)
                root = new LeafNode(item);
            else
            {
                Node newRoot = root.PrependInPlace(item); if (newRoot != root)
                { root = newRoot; CheckBalance(); }
            }
        }
        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); StopEnumerations(); Node node = NodeFromEnumerable(collection); if (node == null)
                return;
            else if (root == null)
            { root = node; CheckBalance(); }
            else
            {
                if ((uint)Count + (uint)node.count > MAXITEMS)
                    throw new InvalidOperationException(Strings.CollectionTooLarge); Node newRoot = root.AppendInPlace(node, true); if (newRoot != root)
                { root = newRoot; CheckBalance(); }
            }
        }
        public void AddRangeToFront(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); StopEnumerations(); Node node = NodeFromEnumerable(collection); if (node == null)
                return;
            else if (root == null)
            { root = node; CheckBalance(); }
            else
            {
                if ((uint)Count + (uint)node.Count > MAXITEMS)
                    throw new InvalidOperationException(Strings.CollectionTooLarge); Node newRoot = root.PrependInPlace(node, true); if (newRoot != root)
                { root = newRoot; CheckBalance(); }
            }
        }
        public BigList<T> Clone()
        {
            if (root == null)
                return new BigList<T>();
            else
            { root.MarkShared(); return new BigList<T>(root); }
        }

#if !PCL

        object ICloneable.Clone()
        { return Clone(); }
        public BigList<T> CloneContents()
        {
            if (root == null)
                return new BigList<T>();
            else
            {
                bool itemIsValueType; if (!Util.IsCloneableType(typeof(T), out itemIsValueType))
                    throw new InvalidOperationException(string.Format(Strings.TypeNotCloneable, typeof(T).FullName)); if (itemIsValueType)
                    return Clone(); return new BigList<T>(Algorithms.Convert<T, T>(this, delegate (T item) {
                        if (item == null)
                            return default(T);
                        else
                            return (T)(((ICloneable)item).Clone());
                    }));
            }
        }

#endif

        public void AddRange(BigList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if ((uint)Count + (uint)list.Count > MAXITEMS)
                throw new InvalidOperationException(Strings.CollectionTooLarge); if (list.Count == 0)
                return; StopEnumerations(); if (root == null)
            { list.root.MarkShared(); root = list.root; }
            else
            {
                Node newRoot = root.AppendInPlace(list.root, false); if (newRoot != root)
                { root = newRoot; CheckBalance(); }
            }
        }
        public void AddRangeToFront(BigList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if ((uint)Count + (uint)list.Count > MAXITEMS)
                throw new InvalidOperationException(Strings.CollectionTooLarge); if (list.Count == 0)
                return; StopEnumerations(); if (root == null)
            { list.root.MarkShared(); root = list.root; }
            else
            {
                Node newRoot = root.PrependInPlace(list.root, false); if (newRoot != root)
                { root = newRoot; CheckBalance(); }
            }
        }
        public static BigList<T> operator +(BigList<T> first, BigList<T> second)
        {
            if (first == null)
                throw new ArgumentNullException("first"); if (second == null)
                throw new ArgumentNullException("second"); if ((uint)first.Count + (uint)second.Count > MAXITEMS)
                throw new InvalidOperationException(Strings.CollectionTooLarge); if (first.Count == 0)
                return second.Clone();
            else if (second.Count == 0)
                return first.Clone();
            else
            { BigList<T> result = new BigList<T>(first.root.Append(second.root, false)); result.CheckBalance(); return result; }
        }
        public BigList<T> GetRange(int index, int count)
        {
            if (count == 0)
                return new BigList<T>(); if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("index"); if (count < 0 || count > Count - index)
                throw new ArgumentOutOfRangeException("count"); return new BigList<T>(root.Subrange(index, index + count - 1));
        }
        public sealed override IList<T> Range(int index, int count)
        {
            if (index < 0 || index > this.Count || (index == this.Count && count != 0))
                throw new ArgumentOutOfRangeException("index"); if (count < 0 || count > this.Count || count + index > this.Count)
                throw new ArgumentOutOfRangeException("count"); return new BigListRange(this, index, count);
        }
        private IEnumerator<T> GetEnumerator(int start, int maxItems)
        {
            int startStamp = changeStamp; if (root != null && maxItems > 0)
            {
                ConcatNode[] stack = new ConcatNode[root.Depth]; bool[] leftStack = new bool[root.Depth]; int stackPtr = 0, startIndex = 0; Node current = root; LeafNode currentLeaf; ConcatNode currentConcat; if (start != 0)
                {
                    if (start < 0 || start >= root.Count)
                        throw new ArgumentOutOfRangeException("start"); currentConcat = current as ConcatNode; startIndex = start; while (currentConcat != null)
                    {
                        stack[stackPtr] = currentConcat; int leftCount = currentConcat.left.Count; if (startIndex < leftCount)
                        { leftStack[stackPtr] = true; current = currentConcat.left; }
                        else
                        { leftStack[stackPtr] = false; current = currentConcat.right; startIndex -= leftCount; }
                        ++stackPtr; currentConcat = current as ConcatNode;
                    }
                }
                for (;;)
                {
                    while ((currentConcat = current as ConcatNode) != null)
                    { stack[stackPtr] = currentConcat; leftStack[stackPtr] = true; ++stackPtr; current = currentConcat.left; }
                    currentLeaf = (LeafNode)current; int limit = currentLeaf.Count; if (limit > startIndex + maxItems)
                        limit = startIndex + maxItems; for (int i = startIndex; i < limit; ++i)
                    { yield return currentLeaf.items[i]; CheckEnumerationStamp(startStamp); }
                    maxItems -= limit - startIndex; if (maxItems <= 0)
                        yield break; startIndex = 0; for (;;)
                    {
                        ConcatNode parent; if (stackPtr == 0)
                            yield break; parent = stack[--stackPtr]; if (leftStack[stackPtr])
                        { leftStack[stackPtr] = false; ++stackPtr; current = parent.right; break; }
                        current = parent;
                    }
                }
            }
        }
        public sealed override IEnumerator<T> GetEnumerator()
        { return GetEnumerator(0, int.MaxValue); }
        private Node NodeFromEnumerable(IEnumerable<T> collection)
        {
            Node node = null; LeafNode leaf; IEnumerator<T> enumerator = collection.GetEnumerator(); while ((leaf = LeafFromEnumerator(enumerator)) != null)
            {
                if (node == null)
                    node = leaf;
                else
                {
                    if ((uint)(node.count) + (uint)(leaf.count) > MAXITEMS)
                        throw new InvalidOperationException(Strings.CollectionTooLarge); node = node.AppendInPlace(leaf, true);
                }
            }
            return node;
        }
        private LeafNode LeafFromEnumerator(IEnumerator<T> enumerator)
        {
            int i = 0; T[] items = null; while (i < MAXLEAF && enumerator.MoveNext())
            {
                if (i == 0)
                    items = new T[MAXLEAF]; items[i++] = enumerator.Current;
            }
            if (items != null)
                return new LeafNode(i, items);
            else
                return null;
        }
        private Node NCopiesOfNode(int copies, Node node)
        {
            if (copies < 0)
                throw new ArgumentOutOfRangeException("copies", Strings.ArgMustNotBeNegative); if (copies == 0 || node == null)
                return null; if (copies == 1)
                return node; if ((long)copies * (long)(node.count) > MAXITEMS)
                throw new InvalidOperationException(Strings.CollectionTooLarge); int n = 1; Node power = node, builder = null; while (copies > 0)
            {
                power.MarkShared(); if ((copies & n) != 0)
                {
                    copies -= n; if (builder == null)
                        builder = power;
                    else
                        builder = builder.Append(power, false);
                }
                n *= 2; power = power.Append(power, false);
            }
            return builder;
        }
        private void CheckBalance()
        {
            if (root != null && (root.Depth > BALANCEFACTOR && !(root.Depth - BALANCEFACTOR <= MAXFIB && Count >= FIBONACCI[root.Depth - BALANCEFACTOR])))
            { Rebalance(); }
        }
        internal void Rebalance()
        {
            Node[] rebalanceArray; int slots; if (root == null)
                return; if (root.Depth <= 1 || (root.Depth - 2 <= MAXFIB && Count >= FIBONACCI[root.Depth - 2]))
                return; for (slots = 0; slots <= MAXFIB; ++slots)
                if (root.Count < FIBONACCI[slots])
                    break; rebalanceArray = new Node[slots]; AddNodeToRebalanceArray(rebalanceArray, root, false); Node result = null; for (int slot = 0; slot < slots; ++slot)
            {
                Node n = rebalanceArray[slot]; if (n != null)
                {
                    if (result == null)
                        result = n;
                    else
                        result = result.PrependInPlace(n, !n.Shared);
                }
            }
            root = result; Debug.Assert(root.Depth <= 1 || (root.Depth - 2 <= MAXFIB && Count >= FIBONACCI[root.Depth - 2]));
        }
        private void AddNodeToRebalanceArray(Node[] rebalanceArray, Node node, bool shared)
        {
            if (node.Shared)
                shared = true; if (node.IsBalanced())
            {
                if (shared)
                    node.MarkShared(); AddBalancedNodeToRebalanceArray(rebalanceArray, node);
            }
            else
            { ConcatNode n = (ConcatNode)node; AddNodeToRebalanceArray(rebalanceArray, n.left, shared); AddNodeToRebalanceArray(rebalanceArray, n.right, shared); }
        }


        private void AddBalancedNodeToRebalanceArray(Node[] rebalanceArray, Node balancedNode)
        {
            int slot;
            int count;
            Node accum = null;
            Debug.Assert(balancedNode.IsBalanced());

            count = balancedNode.Count;
            slot = 0;
            while (count >= FIBONACCI[slot + 1])
            {
                Node n = rebalanceArray[slot];
                if (n != null)
                {
                    rebalanceArray[slot] = null;
                    if (accum == null)
                        accum = n;
                    else
                        accum = accum.PrependInPlace(n, !n.Shared);
                }
                ++slot;
            }


            if (accum != null)
                balancedNode = balancedNode.PrependInPlace(accum, !accum.Shared);
            for (;;)
            {
                Node n = rebalanceArray[slot];
                if (n != null)
                {
                    rebalanceArray[slot] = null;
                    balancedNode = balancedNode.PrependInPlace(n, !n.Shared);
                }

                if (balancedNode.Count < FIBONACCI[slot + 1])
                {
                    rebalanceArray[slot] = balancedNode;
                    break;
                }
                ++slot;
            }

#if DEBUG


            for (int i = 0; i < rebalanceArray.Length; ++i)
            {
                if (rebalanceArray[i] != null)
                    Debug.Assert(rebalanceArray[i].IsAlmostBalanced());
            }
#endif 

        }


        public new BigList<TDest> ConvertAll<TDest>(Converter<T, TDest> converter)
        { return new BigList<TDest>(Algorithms.Convert<T, TDest>(this, converter)); }
        public void Reverse()
        { Algorithms.ReverseInPlace<T>(this); }
        public void Reverse(int start, int count)
        { Algorithms.ReverseInPlace<T>(Range(start, count)); }
        public void Sort()
        { Sort(Comparers.DefaultComparer<T>()); }
        public void Sort(IComparer<T> comparer)
        { Algorithms.SortInPlace(this, comparer); }
        public void Sort(Comparison<T> comparison)
        { Sort(Comparers.ComparerFromComparison<T>(comparison)); }
        public int BinarySearch(T item)
        { return BinarySearch(item, Comparers.DefaultComparer<T>()); }
        public int BinarySearch(T item, IComparer<T> comparer)
        {
            int count, index; count = Algorithms.BinarySearch<T>(this, item, comparer, out index); if (count == 0)
                return (~index);
            else
                return index;
        }
        public int BinarySearch(T item, Comparison<T> comparison)
        { return BinarySearch(item, Comparers.ComparerFromComparison<T>(comparison)); }


#if DEBUG

        public void Validate()
        {
            if (root != null)
            { root.Validate(); Debug.Assert(Count != 0); }
            else
                Debug.Assert(Count == 0);
        }
        public void Print()
        {
            Console.WriteLine("SERIES: Count={0}", Count); if (Count > 0)
            {
                Console.Write("ITEMS: "); foreach (T item in this)
                { Console.Write("{0} ", item); }
                Console.WriteLine(); Console.WriteLine("TREE:"); root.Print("      ", "      ");
            }
            Console.WriteLine();
        }
#endif 



#if !PCL
        [Serializable]
#endif
        private abstract class Node
        {


            public int count;

            protected volatile bool shared;


            public int Count
            {
                get { return count; }
            }


            public bool Shared
            {
                get { return shared; }
            }


            public void MarkShared()
            {
                shared = true;
            }


            public abstract int Depth { get; }

            public abstract T GetAt(int index);


            public abstract Node Subrange(int first, int last);


            public abstract Node SetAt(int index, T item);


            public abstract Node SetAtInPlace(int index, T item);


            public abstract Node Append(Node node, bool nodeIsUnused);

            public abstract Node AppendInPlace(Node node, bool nodeIsUnused);


            public abstract Node AppendInPlace(T item);


            public abstract Node RemoveRange(int first, int last);

            public abstract Node RemoveRangeInPlace(int first, int last);

            public abstract Node Insert(int index, Node node, bool nodeIsUnused);

            public abstract Node InsertInPlace(int index, T item);

            public abstract Node InsertInPlace(int index, Node node, bool nodeIsUnused);

#if DEBUG

            public abstract void Validate();

            public abstract void Print(string prefixNode, string prefixChildren);
#endif


            public Node Prepend(Node node, bool nodeIsUnused)
            {
                if (nodeIsUnused)
                    return node.AppendInPlace(this, false);
                else
                    return node.Append(this, false);
            }
            public Node PrependInPlace(Node node, bool nodeIsUnused)
            {
                if (nodeIsUnused)
                    return node.AppendInPlace(this, !this.shared);
                else
                    return node.Append(this, !this.shared);
            }
            public abstract Node PrependInPlace(T item); public bool IsBalanced()
            { return (Depth <= MAXFIB && Count >= FIBONACCI[Depth]); }
            public bool IsAlmostBalanced()
            { return (Depth == 0 || (Depth - 1 <= MAXFIB && Count >= FIBONACCI[Depth - 1])); }
        }

#if !PCL
        [Serializable]
#endif
        private sealed class LeafNode : Node
        {
            public T[] items; public LeafNode(T item)
            { count = 1; items = new T[MAXLEAF]; items[0] = item; }
            public LeafNode(int count, T[] newItems)
            { Debug.Assert(count <= newItems.Length && count > 0); Debug.Assert(newItems.Length <= MAXLEAF); this.count = count; items = newItems; }
            public override int Depth
            { get { return 0; } }
            public override T GetAt(int index)
            { return items[index]; }
            public override Node SetAtInPlace(int index, T item)
            {
                if (shared)
                    return SetAt(index, item); items[index] = item; return this;
            }
            public override Node SetAt(int index, T item)
            { T[] newItems = (T[])items.Clone(); newItems[index] = item; return new LeafNode(count, newItems); }
            private bool MergeLeafInPlace(Node other)
            {
                Debug.Assert(!shared); LeafNode otherLeaf = (other as LeafNode); int newCount; if (otherLeaf != null && (newCount = otherLeaf.Count + this.count) <= MAXLEAF)
                {
                    if (newCount > items.Length)
                    { T[] newItems = new T[MAXLEAF]; Array.Copy(items, 0, newItems, 0, count); items = newItems; }
                    Array.Copy(otherLeaf.items, 0, items, count, otherLeaf.count); count = newCount; return true;
                }
                return false;
            }
            private Node MergeLeaf(Node other)
            {
                LeafNode otherLeaf = (other as LeafNode); int newCount; if (otherLeaf != null && (newCount = otherLeaf.Count + this.count) <= MAXLEAF)
                { T[] newItems = new T[MAXLEAF]; Array.Copy(items, 0, newItems, 0, count); Array.Copy(otherLeaf.items, 0, newItems, count, otherLeaf.count); return new LeafNode(newCount, newItems); }
                return null;
            }
            public override Node PrependInPlace(T item)
            {
                if (shared)
                    return Prepend(new LeafNode(item), true); if (count < MAXLEAF)
                {
                    if (count == items.Length)
                    { T[] newItems = new T[MAXLEAF]; Array.Copy(items, 0, newItems, 1, count); items = newItems; }
                    else
                    { Array.Copy(items, 0, items, 1, count); }
                    items[0] = item; count += 1; return this;
                }
                else
                { return new ConcatNode(new LeafNode(item), this); }
            }
            public override Node AppendInPlace(T item)
            {
                if (shared)
                    return Append(new LeafNode(item), true); if (count < MAXLEAF)
                {
                    if (count == items.Length)
                    { T[] newItems = new T[MAXLEAF]; Array.Copy(items, 0, newItems, 0, count); items = newItems; }
                    items[count] = item; count += 1; return this;
                }
                else
                { return new ConcatNode(this, new LeafNode(item)); }
            }
            public override Node AppendInPlace(Node node, bool nodeIsUnused)
            {
                if (shared)
                    return Append(node, nodeIsUnused); if (MergeLeafInPlace(node))
                { return this; }
                ConcatNode otherConcat = (node as ConcatNode); if (otherConcat != null && MergeLeafInPlace(otherConcat.left))
                {
                    if (!nodeIsUnused)
                        otherConcat.right.MarkShared(); return new ConcatNode(this, otherConcat.right);
                }
                if (!nodeIsUnused)
                    node.MarkShared(); return new ConcatNode(this, node);
            }
            public override Node Append(Node node, bool nodeIsUnused)
            {
                Node result; if ((result = MergeLeaf(node)) != null)
                    return result; ConcatNode otherConcat = (node as ConcatNode); if (otherConcat != null && (result = MergeLeaf(otherConcat.left)) != null)
                {
                    if (!nodeIsUnused)
                        otherConcat.right.MarkShared(); return new ConcatNode(result, otherConcat.right);
                }
                if (!nodeIsUnused)
                    node.MarkShared(); MarkShared(); return new ConcatNode(this, node);
            }
            public override Node InsertInPlace(int index, T item)
            {
                if (shared)
                    return Insert(index, new LeafNode(item), true); if (count < MAXLEAF)
                {
                    if (count == items.Length)
                    {
                        T[] newItems = new T[MAXLEAF]; if (index > 0)
                            Array.Copy(items, 0, newItems, 0, index); if (count > index)
                            Array.Copy(items, index, newItems, index + 1, count - index); items = newItems;
                    }
                    else
                    {
                        if (count > index)
                            Array.Copy(items, index, items, index + 1, count - index);
                    }
                    items[index] = item; count += 1; return this;
                }
                else
                {
                    if (index == count)
                    { return new ConcatNode(this, new LeafNode(item)); }
                    else if (index == 0)
                    { return new ConcatNode(new LeafNode(item), this); }
                    else
                    { T[] leftItems = new T[MAXLEAF]; Array.Copy(items, 0, leftItems, 0, index); leftItems[index] = item; Node leftNode = new LeafNode(index + 1, leftItems); T[] rightItems = new T[count - index]; Array.Copy(items, index, rightItems, 0, count - index); Node rightNode = new LeafNode(count - index, rightItems); return new ConcatNode(leftNode, rightNode); }
                }
            }
            public override Node InsertInPlace(int index, Node node, bool nodeIsUnused)
            {
                if (shared)
                    return Insert(index, node, nodeIsUnused); LeafNode otherLeaf = (node as LeafNode); int newCount; if (otherLeaf != null && (newCount = otherLeaf.Count + this.count) <= MAXLEAF)
                {
                    if (newCount > items.Length)
                    { T[] newItems = new T[MAXLEAF]; Array.Copy(items, 0, newItems, 0, index); Array.Copy(otherLeaf.items, 0, newItems, index, otherLeaf.Count); Array.Copy(items, index, newItems, index + otherLeaf.Count, count - index); items = newItems; }
                    else
                    { Array.Copy(items, index, items, index + otherLeaf.Count, count - index); Array.Copy(otherLeaf.items, 0, items, index, otherLeaf.count); }
                    count = newCount; return this;
                }
                else if (index == 0)
                { return PrependInPlace(node, nodeIsUnused); }
                else if (index == count)
                { return AppendInPlace(node, nodeIsUnused); }
                else
                { T[] leftItems = new T[index]; Array.Copy(items, 0, leftItems, 0, index); Node leftNode = new LeafNode(index, leftItems); T[] rightItems = new T[count - index]; Array.Copy(items, index, rightItems, 0, count - index); Node rightNode = new LeafNode(count - index, rightItems); leftNode = leftNode.AppendInPlace(node, nodeIsUnused); leftNode = leftNode.AppendInPlace(rightNode, true); return leftNode; }
            }
            public override Node Insert(int index, Node node, bool nodeIsUnused)
            {
                LeafNode otherLeaf = (node as LeafNode); int newCount; if (otherLeaf != null && (newCount = otherLeaf.Count + this.count) <= MAXLEAF)
                { T[] newItems = new T[MAXLEAF]; Array.Copy(items, 0, newItems, 0, index); Array.Copy(otherLeaf.items, 0, newItems, index, otherLeaf.Count); Array.Copy(items, index, newItems, index + otherLeaf.Count, count - index); return new LeafNode(newCount, newItems); }
                else if (index == 0)
                { return Prepend(node, nodeIsUnused); }
                else if (index == count)
                { return Append(node, nodeIsUnused); }
                else
                { T[] leftItems = new T[index]; Array.Copy(items, 0, leftItems, 0, index); Node leftNode = new LeafNode(index, leftItems); T[] rightItems = new T[count - index]; Array.Copy(items, index, rightItems, 0, count - index); Node rightNode = new LeafNode(count - index, rightItems); leftNode = leftNode.AppendInPlace(node, nodeIsUnused); leftNode = leftNode.AppendInPlace(rightNode, true); return leftNode; }
            }
            public override Node RemoveRangeInPlace(int first, int last)
            {
                if (shared)
                    return RemoveRange(first, last); Debug.Assert(first <= last); Debug.Assert(last >= 0); if (first <= 0 && last >= count - 1)
                { return null; }
                if (first < 0)
                    first = 0; if (last >= count)
                    last = count - 1; int newCount = first + (count - last - 1); if (count > last + 1)
                    Array.Copy(items, last + 1, items, first, count - last - 1); for (int i = newCount; i < count; ++i)
                    items[i] = default(T); count = newCount; return this;
            }
            public override Node RemoveRange(int first, int last)
            {
                Debug.Assert(first <= last); Debug.Assert(last >= 0); if (first <= 0 && last >= count - 1)
                { return null; }
                if (first < 0)
                    first = 0; if (last >= count)
                    last = count - 1; int newCount = first + (count - last - 1); T[] newItems = new T[newCount]; if (first > 0)
                    Array.Copy(items, 0, newItems, 0, first); if (count > last + 1)
                    Array.Copy(items, last + 1, newItems, first, count - last - 1); return new LeafNode(newCount, newItems);
            }
            public override Node Subrange(int first, int last)
            {
                Debug.Assert(first <= last); Debug.Assert(last >= 0); if (first <= 0 && last >= count - 1)
                { MarkShared(); return this; }
                else
                {
                    if (first < 0)
                        first = 0; if (last >= count)
                        last = count - 1; int n = last - first + 1; T[] newItems = new T[n]; Array.Copy(items, first, newItems, 0, n); return new LeafNode(n, newItems);
                }
            }

#if DEBUG
            public override void Validate()
            { Debug.Assert(count > 0); Debug.Assert(items != null); Debug.Assert(items.Length > 0); Debug.Assert(count <= MAXLEAF); Debug.Assert(items.Length <= MAXLEAF); Debug.Assert(count <= items.Length); }
            public override void Print(string prefixNode, string prefixChildren)
            {
                Console.Write("{0}LEAF {1} count={2}/{3} ", prefixNode, shared ? "S" : " ", count, items.Length); for (int i = 0; i < count; ++i)
                    Console.Write("{0} ", items[i]); Console.WriteLine();
            }
#endif 

        }

#if !PCL
        [Serializable]
#endif
        private sealed class ConcatNode : Node
        {
            public Node left, right; private short depth; public override int Depth
            { get { return depth; } }
            public ConcatNode(Node left, Node right)
            {
                Debug.Assert(left != null && right != null); this.left = left; this.right = right; this.count = left.Count + right.Count; if (left.Depth > right.Depth)
                    this.depth = (short)(left.Depth + 1);
                else
                    this.depth = (short)(right.Depth + 1);
            }
            private Node NewNode(Node newLeft, Node newRight)
            {
                if (left == newLeft)
                {
                    if (right == newRight)
                    { MarkShared(); return this; }
                    else
                        left.MarkShared();
                }
                else
                {
                    if (right == newRight)
                        right.MarkShared();
                }
                if (newLeft == null)
                    return newRight;
                else if (newRight == null)
                    return newLeft;
                else
                    return new ConcatNode(newLeft, newRight);
            }
            private Node NewNodeInPlace(Node newLeft, Node newRight)
            {
                Debug.Assert(!shared); if (newLeft == null)
                    return newRight;
                else if (newRight == null)
                    return newLeft; left = newLeft; right = newRight; count = left.Count + right.Count; if (left.Depth > right.Depth)
                    depth = (short)(left.Depth + 1);
                else
                    depth = (short)(right.Depth + 1); return this;
            }
            public override T GetAt(int index)
            {
                int leftCount = left.Count; if (index < leftCount)
                    return left.GetAt(index);
                else
                    return right.GetAt(index - leftCount);
            }
            public override Node SetAtInPlace(int index, T item)
            {
                if (shared)
                    return SetAt(index, item); int leftCount = left.Count; if (index < leftCount)
                {
                    Node newLeft = left.SetAtInPlace(index, item); if (newLeft != left)
                        return NewNodeInPlace(newLeft, right);
                    else
                        return this;
                }
                else
                {
                    Node newRight = right.SetAtInPlace(index - leftCount, item); if (newRight != right)
                        return NewNodeInPlace(left, newRight);
                    else
                        return this;
                }
            }
            public override Node SetAt(int index, T item)
            {
                int leftCount = left.Count; if (index < leftCount)
                { return NewNode(left.SetAt(index, item), right); }
                else
                { return NewNode(left, right.SetAt(index - leftCount, item)); }
            }
            public override Node PrependInPlace(T item)
            {
                if (shared)
                    return Prepend(new LeafNode(item), true); LeafNode leftLeaf; if (left.Count < MAXLEAF && !left.Shared && (leftLeaf = left as LeafNode) != null)
                {
                    int c = leftLeaf.Count; if (c == leftLeaf.items.Length)
                    { T[] newItems = new T[MAXLEAF]; Array.Copy(leftLeaf.items, 0, newItems, 1, c); leftLeaf.items = newItems; }
                    else
                    { Array.Copy(leftLeaf.items, 0, leftLeaf.items, 1, c); }
                    leftLeaf.items[0] = item; leftLeaf.count += 1; this.count += 1; return this;
                }
                else
                    return new ConcatNode(new LeafNode(item), this);
            }
            public override Node AppendInPlace(T item)
            {
                if (shared)
                    return Append(new LeafNode(item), true); LeafNode rightLeaf; if (right.Count < MAXLEAF && !right.Shared && (rightLeaf = right as LeafNode) != null)
                {
                    int c = rightLeaf.Count; if (c == rightLeaf.items.Length)
                    { T[] newItems = new T[MAXLEAF]; Array.Copy(rightLeaf.items, 0, newItems, 0, c); rightLeaf.items = newItems; }
                    rightLeaf.items[c] = item; rightLeaf.count += 1; this.count += 1; return this;
                }
                else
                    return new ConcatNode(this, new LeafNode(item));
            }
            public override Node AppendInPlace(Node node, bool nodeIsUnused)
            {
                if (shared)
                    return Append(node, nodeIsUnused); if (right.Count + node.Count <= MAXLEAF && right is LeafNode && node is LeafNode)
                    return NewNodeInPlace(left, right.AppendInPlace(node, nodeIsUnused)); if (!nodeIsUnused)
                    node.MarkShared(); return new ConcatNode(this, node);
            }
            public override Node Append(Node node, bool nodeIsUnused)
            {
                if (right.Count + node.Count <= MAXLEAF && right is LeafNode && node is LeafNode)
                    return NewNode(left, right.Append(node, nodeIsUnused)); this.MarkShared(); if (!nodeIsUnused)
                    node.MarkShared(); return new ConcatNode(this, node);
            }
            public override Node InsertInPlace(int index, T item)
            {
                if (shared)
                    return Insert(index, new LeafNode(item), true); int leftCount = left.Count; if (index <= leftCount)
                    return NewNodeInPlace(left.InsertInPlace(index, item), right);
                else
                    return NewNodeInPlace(left, right.InsertInPlace(index - leftCount, item));
            }
            public override Node InsertInPlace(int index, Node node, bool nodeIsUnused)
            {
                if (shared)
                    return Insert(index, node, nodeIsUnused); int leftCount = left.Count; if (index < leftCount)
                    return NewNodeInPlace(left.InsertInPlace(index, node, nodeIsUnused), right);
                else
                    return NewNodeInPlace(left, right.InsertInPlace(index - leftCount, node, nodeIsUnused));
            }
            public override Node Insert(int index, Node node, bool nodeIsUnused)
            {
                int leftCount = left.Count; if (index < leftCount)
                    return NewNode(left.Insert(index, node, nodeIsUnused), right);
                else
                    return NewNode(left, right.Insert(index - leftCount, node, nodeIsUnused));
            }
            public override Node RemoveRangeInPlace(int first, int last)
            {
                if (shared)
                    return RemoveRange(first, last); Debug.Assert(first < count); Debug.Assert(last >= 0); if (first <= 0 && last >= count - 1)
                { return null; }
                int leftCount = left.Count; Node newLeft = left, newRight = right; if (first < leftCount)
                    newLeft = left.RemoveRangeInPlace(first, last); if (last >= leftCount)
                    newRight = right.RemoveRangeInPlace(first - leftCount, last - leftCount); return NewNodeInPlace(newLeft, newRight);
            }
            public override Node RemoveRange(int first, int last)
            {
                Debug.Assert(first < count); Debug.Assert(last >= 0); if (first <= 0 && last >= count - 1)
                { return null; }
                int leftCount = left.Count; Node newLeft = left, newRight = right; if (first < leftCount)
                    newLeft = left.RemoveRange(first, last); if (last >= leftCount)
                    newRight = right.RemoveRange(first - leftCount, last - leftCount); return NewNode(newLeft, newRight);
            }
            public override Node Subrange(int first, int last)
            {
                Debug.Assert(first < count); Debug.Assert(last >= 0); if (first <= 0 && last >= count - 1)
                { MarkShared(); return this; }
                int leftCount = left.Count; Node leftPart = null, rightPart = null; if (first < leftCount)
                    leftPart = left.Subrange(first, last); if (last >= leftCount)
                    rightPart = right.Subrange(first - leftCount, last - leftCount); Debug.Assert(leftPart != null || rightPart != null); if (leftPart == null)
                    return rightPart;
                else if (rightPart == null)
                    return leftPart;
                else
                    return new ConcatNode(leftPart, rightPart);
            }

#if DEBUG
            public override void Validate()
            {
                Debug.Assert(left != null);
                Debug.Assert(right != null);
                Debug.Assert(Depth > 0);
                Debug.Assert(Count > 0);
                Debug.Assert(Math.Max(left.Depth, right.Depth) + 1 == Depth);
                Debug.Assert(left.Count + right.Count == Count);
                left.Validate();
                right.Validate();
            }

            public override void Print(string prefixNode, string prefixChildren)
            {
                Console.WriteLine("{0}CONCAT {1} {2} count={3} depth={4}", prefixNode, shared ? "S" : " ", IsBalanced() ? "B" : (IsAlmostBalanced() ? "A" : " "), count, depth);
                left.Print(prefixChildren + "|-L-", prefixChildren + "|  ");
                right.Print(prefixChildren + "|-R-", prefixChildren + "   ");
            }
#endif 

        }

#if !PCL
        [Serializable]
#endif
        private class BigListRange : ListBase<T>
        {
            private BigList<T> wrappedList; private int start; private int count; public BigListRange(BigList<T> wrappedList, int start, int count)
            { this.wrappedList = wrappedList; this.start = start; this.count = count; }
            public override int Count
            {
                get
                { return Math.Min(count, wrappedList.Count - start); }
            }
            public override void Clear()
            {
                if (wrappedList.Count - start < count)
                    count = wrappedList.Count - start; while (count > 0)
                { wrappedList.RemoveAt(start + count - 1); --count; }
            }
            public override void Insert(int index, T item)
            {
                if (index < 0 || index > count)
                    throw new ArgumentOutOfRangeException("index"); wrappedList.Insert(start + index, item); ++count;
            }
            public override void RemoveAt(int index)
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException("index"); wrappedList.RemoveAt(start + index); --count;
            }
            public override T this[int index]
            {
                get
                {
                    if (index < 0 || index >= count)
                        throw new ArgumentOutOfRangeException("index"); return wrappedList[start + index];
                }
                set
                {
                    if (index < 0 || index >= count)
                        throw new ArgumentOutOfRangeException("index"); wrappedList[start + index] = value;
                }
            }
            public override IEnumerator<T> GetEnumerator()
            { return wrappedList.GetEnumerator(start, count); }
        }
    }



#if !PCL
    [Serializable]
#endif
    public abstract class ListBase<T> : CollectionBase<T>, IList<T>, IList
    {
        protected ListBase()
        { }
        public abstract override int Count { get; }
        public abstract override void Clear(); public abstract T this[int index]
        { get; set; }
        public abstract void Insert(int index, T item); public abstract void RemoveAt(int index); public override IEnumerator<T> GetEnumerator()
        {
            int count = Count; for (int i = 0; i < count; ++i)
            { yield return this[i]; }
        }
        public override bool Contains(T item)
        { return (IndexOf(item) >= 0); }
        public override void Add(T item)
        { Insert(Count, item); }
        public override bool Remove(T item)
        {
            int index = IndexOf(item); if (index >= 0)
            { RemoveAt(index); return true; }
            else
            { return false; }
        }
        public virtual void CopyTo(T[] array)
        { this.CopyTo(array, 0); }
        public override void CopyTo(T[] array, int arrayIndex)
        { base.CopyTo(array, arrayIndex); }
        public virtual void CopyTo(int index, T[] array, int arrayIndex, int count)
        { Range(index, count).CopyTo(array, arrayIndex); }
        public virtual new IList<T> AsReadOnly()
        { return Algorithms.ReadOnly<T>(this); }
        public virtual T Find(Predicate<T> predicate)
        { return Algorithms.FindFirstWhere(this, predicate); }

        public virtual bool TryFind(Predicate<T> predicate, out T foundItem)
        { return Algorithms.TryFindFirstWhere<T>(this, predicate, out foundItem); }
        public virtual T FindLast(Predicate<T> predicate)
        { return Algorithms.FindLastWhere(this, predicate); }
        public virtual bool TryFindLast(Predicate<T> predicate, out T foundItem)
        { return Algorithms.TryFindLastWhere<T>(this, predicate, out foundItem); }
        public virtual int FindIndex(Predicate<T> predicate)
        { return Algorithms.FindFirstIndexWhere<T>(this, predicate); }
        public virtual int FindIndex(int index, Predicate<T> predicate)
        {
            int foundIndex = Algorithms.FindFirstIndexWhere<T>(Range(index, Count - index), predicate); if (foundIndex < 0)
                return -1;
            else
                return foundIndex + index;
        }
        public virtual int FindIndex(int index, int count, Predicate<T> predicate)
        {
            int foundIndex = Algorithms.FindFirstIndexWhere<T>(Range(index, count), predicate); if (foundIndex < 0)
                return -1;
            else
                return foundIndex + index;
        }
        public virtual int FindLastIndex(Predicate<T> predicate)
        { return Algorithms.FindLastIndexWhere<T>(this, predicate); }
        public virtual int FindLastIndex(int index, Predicate<T> predicate)
        { return Algorithms.FindLastIndexWhere<T>(Range(0, index + 1), predicate); }
        public virtual int FindLastIndex(int index, int count, Predicate<T> predicate)
        {
            int foundIndex = Algorithms.FindLastIndexWhere<T>(Range(index - count + 1, count), predicate); if (foundIndex >= 0)
                return foundIndex + index - count + 1;
            else
                return -1;
        }
        public virtual int IndexOf(T item)
        { return Algorithms.FirstIndexOf<T>(this, item, EqualityComparer<T>.Default); }
        public virtual int IndexOf(T item, int index)
        {
            int foundIndex = Algorithms.FirstIndexOf<T>(Range(index, Count - index), item, EqualityComparer<T>.Default); if (foundIndex >= 0)
                return foundIndex + index;
            else
                return -1;
        }
        public virtual int IndexOf(T item, int index, int count)
        {
            int foundIndex = Algorithms.FirstIndexOf<T>(Range(index, count), item, EqualityComparer<T>.Default); if (foundIndex >= 0)
                return foundIndex + index;
            else
                return -1;
        }
        public virtual int LastIndexOf(T item)
        { return Algorithms.LastIndexOf<T>(this, item, EqualityComparer<T>.Default); }
        public virtual int LastIndexOf(T item, int index)
        { int foundIndex = Algorithms.LastIndexOf<T>(Range(0, index + 1), item, EqualityComparer<T>.Default); return foundIndex; }
        public virtual int LastIndexOf(T item, int index, int count)
        {
            int foundIndex = Algorithms.LastIndexOf<T>(Range(index - count + 1, count), item, EqualityComparer<T>.Default); if (foundIndex >= 0)
                return foundIndex + index - count + 1;
            else
                return -1;
        }
        public virtual IList<T> Range(int start, int count)
        { return Algorithms.Range<T>(this, start, count); }
        private T ConvertToItemType(string name, object value)
        {
            try
            { return (T)value; }
            catch (InvalidCastException)
            { throw new ArgumentException(string.Format(Strings.WrongType, value, typeof(T)), name); }
        }
        int IList.Add(object value)
        { int count = Count; Insert(count, ConvertToItemType("value", value)); return count; }
        void IList.Clear()
        { Clear(); }
        bool IList.Contains(object value)
        {
            if (value is T || value == null)
                return Contains((T)value);
            else
                return false;
        }
        int IList.IndexOf(object value)
        {
            if (value is T || value == null)
                return IndexOf((T)value);
            else
                return -1;
        }


        void IList.Insert(int index, object value)
        { Insert(index, ConvertToItemType("value", value)); }
        bool IList.IsFixedSize
        { get { return false; } }
        bool IList.IsReadOnly
        { get { return ((ICollection<T>)this).IsReadOnly; } }
        void IList.Remove(object value)
        {
            if (value is T || value == null)
                Remove((T)value);
        }
        void IList.RemoveAt(int index)
        { RemoveAt(index); }
        object IList.this[int index]
        {
            get
            { return this[index]; }
            set
            { this[index] = ConvertToItemType("value", value); }
        }
    }

#if !PCL
    [Serializable]
#endif
    [DebuggerDisplay("{DebuggerDisplayString()}")]
    public abstract class CollectionBase<T> : ICollection<T>, ICollection
    {

        protected CollectionBase()
        { }
        public override string ToString()
        { return Algorithms.ToString(this); }
        #region ICollection<T>Members
        public virtual void Add(T item)
        { throw new NotImplementedException(Strings.MustOverrideOrReimplement); }
        public abstract void Clear(); public abstract bool Remove(T item); public virtual bool Contains(T item)
        {
            IEqualityComparer<T> equalityComparer = EqualityComparer<T>.Default; foreach (T i in this)
            {
                if (equalityComparer.Equals(i, item))
                    return true;
            }
            return false;
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            int count = this.Count;

            if (count == 0)
                return;

            if (array == null)
                throw new ArgumentNullException("array");
            if (count < 0)
                throw new ArgumentOutOfRangeException("count", Strings.ArgMustNotBeNegative);
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex", Strings.ArgMustNotBeNegative);
            if (arrayIndex >= array.Length || count > array.Length - arrayIndex)
                throw new ArgumentException("arrayIndex", Strings.ArrayTooSmall);

            int index = arrayIndex, i = 0;
            foreach (T item in (ICollection<T>)this)
            {
                if (i >= count)
                    break;

                array[index] = item;
                ++index;
                ++i;
            }
        }

        public virtual T[] ToArray()
        {
            int count = this.Count;

            T[] array = new T[count];
            CopyTo(array, 0);
            return array;
        }

        public abstract int Count { get; }

        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        public virtual ICollection<T> AsReadOnly()
        {
            return Algorithms.ReadOnly<T>(this);
        }

        #endregion

        #region Delegate operations
        public virtual bool Exists(Predicate<T> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate"); return Algorithms.Exists(this, predicate);
        }
        public virtual bool TrueForAll(Predicate<T> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate"); return Algorithms.TrueForAll(this, predicate);
        }
        public virtual int CountWhere(Predicate<T> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate"); return Algorithms.CountWhere(this, predicate);
        }
        public virtual IEnumerable<T> FindAll(Predicate<T> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate"); return Algorithms.FindWhere(this, predicate);
        }
        public virtual ICollection<T> RemoveAll(Predicate<T> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate"); return Algorithms.RemoveWhere(this, predicate);
        }
        public virtual void ForEach(Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException("action"); Algorithms.ForEach(this, action);
        }
        public virtual IEnumerable<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
        {
            if (converter == null)
                throw new ArgumentNullException("converter"); return Algorithms.Convert(this, converter);
        }

        #endregion

        #region IEnumerable<T> Members

        public abstract IEnumerator<T> GetEnumerator();

        #endregion

        #region ICollection Members

        void ICollection.CopyTo(Array array, int index)
        {
            int count = this.Count; if (count == 0)
                return; if (array == null)
                throw new ArgumentNullException("array"); if (index < 0)
                throw new ArgumentOutOfRangeException("index", Strings.ArgMustNotBeNegative); if (index >= array.Length || count > array.Length - index)
                throw new ArgumentException("index", Strings.ArrayTooSmall); int i = 0; foreach (object o in (ICollection)this)
            {
                if (i >= count)
                    break; array.SetValue(o, index); ++index; ++i;
            }
        }
        bool ICollection.IsSynchronized
        { get { return false; } }
        object ICollection.SyncRoot
        { get { return this; } }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (T item in this)
            {
                yield return item;
            }
        }

        #endregion

        internal string DebuggerDisplayString()
        {
            const int MAXLENGTH = 250; System.Text.StringBuilder builder = new System.Text.StringBuilder(); builder.Append('{'); bool firstItem = true; foreach (T item in this)
            {
                if (builder.Length >= MAXLENGTH)
                { builder.Append(",..."); break; }
                if (!firstItem)
                    builder.Append(','); if (item == null)
                    builder.Append("null");
                else
                    builder.Append(item.ToString()); firstItem = false;
            }
            builder.Append('}'); return builder.ToString();
        }

    }
    internal static class Strings
    { public static readonly string UncomparableType = "Type \"{0}\" does not implement IComparable<{0}> or IComparable."; public static readonly string ArgMustNotBeNegative = "The argument may not be less than zero."; public static readonly string ArrayTooSmall = "The array is too small to hold all of the items."; public static readonly string KeyNotFound = "The key was not found in the collection."; public static readonly string ResetNotSupported = "Reset is not supported on this enumerator."; public static readonly string CannotModifyCollection = "The \"{0}\" collection is read-only and cannot be modified."; public static readonly string KeyAlreadyPresent = "The key was already present in the dictionary."; public static readonly string WrongType = "The value \"{0}\" isn't of type \"{1}\" and can't be used in this generic collection."; public static readonly string MustOverrideOrReimplement = "This method must be overridden or re-implemented in the derived class."; public static readonly string MustOverrideIndexerGet = "The get accessor of the indexer must be overridden."; public static readonly string MustOverrideIndexerSet = "The set accessor of the indexer must be overridden."; public static readonly string OutOfViewRange = "The argument is outside the range of this View."; public static readonly string TypeNotCloneable = "Type \"{0}\" does not implement ICloneable."; public static readonly string ChangeDuringEnumeration = "Collection was modified during an enumeration."; public static readonly string InconsistentComparisons = "The two collections cannot be combined because they use different comparison operations."; public static readonly string CollectionIsEmpty = "The collection is empty."; public static readonly string BadComparandType = "Comparand is not of the correct type."; public static readonly string CollectionTooLarge = "The collection has become too large."; public static readonly string InvalidLoadFactor = "The load factor must be between 0.25 and 0.95."; public static readonly string CapacityLessThanCount = "The capacity may not be less than Count."; public static readonly string ListIsReadOnly = "The list may not be read only."; public static readonly string CollectionIsReadOnly = "The collection may not be read only."; public static readonly string IdentityComparerNoCompare = "The Compare method is not supported on an identity comparer."; }
    public delegate bool BinaryPredicate<T>(T item1, T item2);


    public static class Algorithms
    {
        #region Collection wrappers




#if !PCL
        [Serializable]
#endif
        private class ListRange<T> : ListBase<T>, ICollection<T>
        {
            private IList<T> wrappedList; private int start; private int count; public ListRange(IList<T> wrappedList, int start, int count)
            { this.wrappedList = wrappedList; this.start = start; this.count = count; }
            public override int Count
            {
                get
                { return Math.Min(count, wrappedList.Count - start); }
            }
            public override void Clear()
            {
                if (wrappedList.Count - start < count)
                    count = wrappedList.Count - start; while (count > 0)
                { wrappedList.RemoveAt(start + count - 1); --count; }
            }
            public override void Insert(int index, T item)
            {
                if (index < 0 || index > count)
                    throw new ArgumentOutOfRangeException("index"); wrappedList.Insert(start + index, item); ++count;
            }
            public override void RemoveAt(int index)
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException("index"); wrappedList.RemoveAt(start + index); --count;
            }
            public override bool Remove(T item)
            {
                if (wrappedList.IsReadOnly)
                    throw new NotSupportedException(string.Format(Strings.CannotModifyCollection, "Range"));
                else
                    return base.Remove(item);
            }
            public override T this[int index]
            {
                get
                {
                    if (index < 0 || index >= count)
                        throw new ArgumentOutOfRangeException("index"); return wrappedList[start + index];
                }
                set
                {
                    if (index < 0 || index >= count)
                        throw new ArgumentOutOfRangeException("index"); wrappedList[start + index] = value;
                }
            }
            bool ICollection<T>.IsReadOnly
            {
                get
                { return wrappedList.IsReadOnly; }
            }
        }

        public static IList<T> Range<T>(IList<T> list, int start, int count)
        {
            if (list == null)
                throw new ArgumentOutOfRangeException("list");
            if (start < 0 || start > list.Count || (start == list.Count && count != 0))
                throw new ArgumentOutOfRangeException("start");
            if (count < 0 || count > list.Count || count + start > list.Count)
                throw new ArgumentOutOfRangeException("count");

            return new ListRange<T>(list, start, count);
        }


#if !PCL
        [Serializable]
#endif
        private class ArrayRange<T> : ListBase<T>
        {
            private T[] wrappedArray; private int start; private int count; public ArrayRange(T[] wrappedArray, int start, int count)
            { this.wrappedArray = wrappedArray; this.start = start; this.count = count; }
            public override int Count
            {
                get
                { return count; }
            }
            public override void Clear()
            { Array.Copy(wrappedArray, start + count, wrappedArray, start, wrappedArray.Length - (start + count)); Algorithms.FillRange(wrappedArray, wrappedArray.Length - count, count, default(T)); count = 0; }
            public override void Insert(int index, T item)
            {
                if (index < 0 || index > count)
                    throw new ArgumentOutOfRangeException("index"); int i = start + index; if (i + 1 < wrappedArray.Length)
                    Array.Copy(wrappedArray, i, wrappedArray, i + 1, wrappedArray.Length - i - 1); if (i < wrappedArray.Length)
                    wrappedArray[i] = item; if (start + count < wrappedArray.Length)
                    ++count;
            }
            public override void RemoveAt(int index)
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException("index"); int i = start + index; if (i < wrappedArray.Length - 1)
                    Array.Copy(wrappedArray, i + 1, wrappedArray, i, wrappedArray.Length - i - 1); wrappedArray[wrappedArray.Length - 1] = default(T); --count;
            }
            public override T this[int index]
            {
                get
                {
                    if (index < 0 || index >= count)
                        throw new ArgumentOutOfRangeException("index"); return wrappedArray[start + index];
                }
                set
                {
                    if (index < 0 || index >= count)
                        throw new ArgumentOutOfRangeException("index"); wrappedArray[start + index] = value;
                }
            }
        }
        public static IList<T> Range<T>(T[] array, int start, int count)
        {
            if (array == null)
                throw new ArgumentOutOfRangeException("array"); if (start < 0 || start > array.Length || (start == array.Length && count != 0))
                throw new ArgumentOutOfRangeException("start"); if (count < 0 || count > array.Length || count + start > array.Length)
                throw new ArgumentOutOfRangeException("count"); return new ArrayRange<T>(array, start, count);
        }



#if !PCL
        [Serializable]
#endif
        private class ReadOnlyCollection<T> : ICollection<T>
        {
            private ICollection<T> wrappedCollection; public ReadOnlyCollection(ICollection<T> wrappedCollection)
            { this.wrappedCollection = wrappedCollection; }
            private void MethodModifiesCollection()
            { throw new NotSupportedException(string.Format(Strings.CannotModifyCollection, "read-only collection")); }
            public IEnumerator<T> GetEnumerator()
            { return wrappedCollection.GetEnumerator(); }
            IEnumerator IEnumerable.GetEnumerator()
            { return ((IEnumerable)wrappedCollection).GetEnumerator(); }
            public bool Contains(T item)
            { return wrappedCollection.Contains(item); }
            public void CopyTo(T[] array, int arrayIndex)
            { wrappedCollection.CopyTo(array, arrayIndex); }
            public int Count
            { get { return wrappedCollection.Count; } }
            public bool IsReadOnly
            { get { return true; } }
            public void Add(T item)
            { MethodModifiesCollection(); }
            public void Clear()
            { MethodModifiesCollection(); }
            public bool Remove(T item)
            { MethodModifiesCollection(); return false; }
        }
        public static ICollection<T> ReadOnly<T>(ICollection<T> collection)
        {
            if (collection == null)
                return null;
            else
                return new ReadOnlyCollection<T>(collection);
        }



#if !PCL
        [Serializable]
#endif
        private class ReadOnlyList<T> : IList<T>
        {
            private IList<T> wrappedList; public ReadOnlyList(IList<T> wrappedList)
            { this.wrappedList = wrappedList; }
            private void MethodModifiesCollection()
            { throw new NotSupportedException(string.Format(Strings.CannotModifyCollection, "read-only list")); }
            public IEnumerator<T> GetEnumerator()
            { return wrappedList.GetEnumerator(); }
            IEnumerator IEnumerable.GetEnumerator()
            { return ((IEnumerable)wrappedList).GetEnumerator(); }
            public int IndexOf(T item)
            { return wrappedList.IndexOf(item); }
            public bool Contains(T item)
            { return wrappedList.Contains(item); }
            public void CopyTo(T[] array, int arrayIndex)
            { wrappedList.CopyTo(array, arrayIndex); }
            public int Count
            { get { return wrappedList.Count; } }
            public bool IsReadOnly
            { get { return true; } }
            public T this[int index]
            {
                get { return wrappedList[index]; }
                set { MethodModifiesCollection(); }
            }
            public void Add(T item)
            { MethodModifiesCollection(); }
            public void Clear()
            { MethodModifiesCollection(); }
            public void Insert(int index, T item)
            { MethodModifiesCollection(); }
            public void RemoveAt(int index)
            { MethodModifiesCollection(); }
            public bool Remove(T item)
            { MethodModifiesCollection(); return false; }
        }

        public static IList<T> ReadOnly<T>(IList<T> list)
        {
            if (list == null)
                return null;
            else if (list.IsReadOnly)
                return list;
            else
                return new ReadOnlyList<T>(list);
        }

#if !PCL
        [Serializable]
#endif
        private class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
        {
            private IDictionary<TKey, TValue> wrappedDictionary; public ReadOnlyDictionary(IDictionary<TKey, TValue> wrappedDictionary)
            { this.wrappedDictionary = wrappedDictionary; }
            private void MethodModifiesCollection()
            { throw new NotSupportedException(string.Format(Strings.CannotModifyCollection, "read-only dictionary")); }
            public void Add(TKey key, TValue value)
            { MethodModifiesCollection(); }
            public bool ContainsKey(TKey key)
            { return wrappedDictionary.ContainsKey(key); }
            public ICollection<TKey> Keys
            { get { return ReadOnly(wrappedDictionary.Keys); } }
            public ICollection<TValue> Values
            { get { return ReadOnly(wrappedDictionary.Values); } }
            public bool Remove(TKey key)
            { MethodModifiesCollection(); return false; }
            public bool TryGetValue(TKey key, out TValue value)
            { return wrappedDictionary.TryGetValue(key, out value); }
            public TValue this[TKey key]
            {
                get { return wrappedDictionary[key]; }
                set { MethodModifiesCollection(); }
            }
            public void Add(KeyValuePair<TKey, TValue> item)
            { MethodModifiesCollection(); }
            public void Clear()
            { MethodModifiesCollection(); }
            public bool Contains(KeyValuePair<TKey, TValue> item)
            { return wrappedDictionary.Contains(item); }
            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            { wrappedDictionary.CopyTo(array, arrayIndex); }
            public int Count
            { get { return wrappedDictionary.Count; } }
            public bool IsReadOnly
            { get { return true; } }
            public bool Remove(KeyValuePair<TKey, TValue> item)
            { MethodModifiesCollection(); return false; }
            public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            { return wrappedDictionary.GetEnumerator(); }
            IEnumerator IEnumerable.GetEnumerator()
            { return ((IEnumerable)wrappedDictionary).GetEnumerator(); }
        }


        public static IDictionary<TKey, TValue> ReadOnly<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
                return null;
            else if (dictionary.IsReadOnly)
                return dictionary;
            else
                return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }

#if !PCL
        [Serializable]
#endif
        private class TypedEnumerator<T> : IEnumerator<T>
        {
            private IEnumerator wrappedEnumerator; public TypedEnumerator(IEnumerator wrappedEnumerator)
            { this.wrappedEnumerator = wrappedEnumerator; }
            T IEnumerator<T>.Current
            { get { return (T)wrappedEnumerator.Current; } }
            void IDisposable.Dispose()
            {
                if (wrappedEnumerator is IDisposable)
                    ((IDisposable)wrappedEnumerator).Dispose();
            }
            object IEnumerator.Current
            { get { return wrappedEnumerator.Current; } }
            bool IEnumerator.MoveNext()
            { return wrappedEnumerator.MoveNext(); }
            void IEnumerator.Reset()
            { wrappedEnumerator.Reset(); }
        }


#if !PCL
        [Serializable]
#endif
        private class TypedEnumerable<T> : IEnumerable<T>
        {
            private IEnumerable wrappedEnumerable; public TypedEnumerable(IEnumerable wrappedEnumerable)
            { this.wrappedEnumerable = wrappedEnumerable; }
            public IEnumerator<T> GetEnumerator()
            { return new TypedEnumerator<T>(wrappedEnumerable.GetEnumerator()); }
            IEnumerator IEnumerable.GetEnumerator()
            { return wrappedEnumerable.GetEnumerator(); }
        }

        public static IEnumerable<T> TypedAs<T>(IEnumerable untypedCollection)
        {
            if (untypedCollection == null)
                return null;
            else if (untypedCollection is IEnumerable<T>)
                return (IEnumerable<T>)untypedCollection;
            else
                return new TypedEnumerable<T>(untypedCollection);
        }


#if !PCL
        [Serializable]
#endif
        private class TypedCollection<T> : ICollection<T>
        {
            private ICollection wrappedCollection; public TypedCollection(ICollection wrappedCollection)
            { this.wrappedCollection = wrappedCollection; }
            private void MethodModifiesCollection()
            { throw new NotSupportedException(string.Format(Strings.CannotModifyCollection, "strongly-typed Collection")); }
            public void Add(T item)
            { MethodModifiesCollection(); }
            public void Clear()
            { MethodModifiesCollection(); }
            public bool Remove(T item)
            { MethodModifiesCollection(); return false; }
            public bool Contains(T item)
            {
                IEqualityComparer<T> equalityComparer = EqualityComparer<T>.Default; foreach (object obj in wrappedCollection)
                {
                    if (obj is T && equalityComparer.Equals(item, (T)obj))
                        return true;
                }
                return false;
            }
            public void CopyTo(T[] array, int arrayIndex)
            { wrappedCollection.CopyTo(array, arrayIndex); }
            public int Count
            { get { return wrappedCollection.Count; } }
            public bool IsReadOnly
            { get { return true; } }
            public IEnumerator<T> GetEnumerator()
            { return new TypedEnumerator<T>(wrappedCollection.GetEnumerator()); }
            IEnumerator IEnumerable.GetEnumerator()
            { return wrappedCollection.GetEnumerator(); }
        }
        public static ICollection<T> TypedAs<T>(ICollection untypedCollection)
        {
            if (untypedCollection == null)
                return null;
            else if (untypedCollection is ICollection<T>)
                return (ICollection<T>)untypedCollection;
            else
                return new TypedCollection<T>(untypedCollection);
        }


#if !PCL
        [Serializable]
#endif
        private class TypedList<T> : IList<T>
        {
            private IList wrappedList; public TypedList(IList wrappedList)
            { this.wrappedList = wrappedList; }
            public IEnumerator<T> GetEnumerator()
            { return new TypedEnumerator<T>(wrappedList.GetEnumerator()); }
            IEnumerator IEnumerable.GetEnumerator()
            { return wrappedList.GetEnumerator(); }
            public int IndexOf(T item)
            { return wrappedList.IndexOf(item); }
            public void Insert(int index, T item)
            { wrappedList.Insert(index, item); }
            public void RemoveAt(int index)
            { wrappedList.RemoveAt(index); }
            public void Add(T item)
            { wrappedList.Add(item); }
            public void Clear()
            { wrappedList.Clear(); }
            public bool Contains(T item)
            { return wrappedList.Contains(item); }
            public void CopyTo(T[] array, int arrayIndex)
            { wrappedList.CopyTo(array, arrayIndex); }
            public T this[int index]
            {
                get { return (T)wrappedList[index]; }
                set { wrappedList[index] = value; }
            }
            public int Count
            { get { return wrappedList.Count; } }
            public bool IsReadOnly
            { get { return wrappedList.IsReadOnly; } }
            public bool Remove(T item)
            {
                if (wrappedList.Contains(item))
                { wrappedList.Remove(item); return true; }
                else
                { return false; }
            }
        }
        public static IList<T> TypedAs<T>(IList untypedList)
        {
            if (untypedList == null)
                return null;
            else if (untypedList is IList<T>)
                return (IList<T>)untypedList;
            else
                return new TypedList<T>(untypedList);
        }


#if !PCL
        [Serializable]
#endif
        private class UntypedCollection<T> : ICollection
        {
            private ICollection<T> wrappedCollection; public UntypedCollection(ICollection<T> wrappedCollection)
            { this.wrappedCollection = wrappedCollection; }
            public void CopyTo(Array array, int index)
            {
                if (array == null)
                    throw new ArgumentNullException("array"); int i = 0; int count = wrappedCollection.Count; if (index < 0)
                    throw new ArgumentOutOfRangeException("index", Strings.ArgMustNotBeNegative); if (index >= array.Length || count > array.Length - index)
                    throw new ArgumentException("index", Strings.ArrayTooSmall); foreach (T item in wrappedCollection)
                {
                    if (i >= count)
                        break; array.SetValue(item, index); ++index; ++i;
                }
            }
            public int Count
            { get { return wrappedCollection.Count; } }
            public bool IsSynchronized
            { get { return false; } }
            public object SyncRoot
            { get { return this; } }
            public IEnumerator GetEnumerator()
            { return ((IEnumerable)wrappedCollection).GetEnumerator(); }
        }
        public static ICollection Untyped<T>(ICollection<T> typedCollection)
        {
            if (typedCollection == null)
                return null;
            else if (typedCollection is ICollection)
                return (ICollection)typedCollection;
            else
                return new UntypedCollection<T>(typedCollection);
        }

#if !PCL
        [Serializable]
#endif
        private class UntypedList<T> : IList
        {
            private IList<T> wrappedList; public UntypedList(IList<T> wrappedList)
            { this.wrappedList = wrappedList; }
            private T ConvertToItemType(string name, object value)
            {
                try
                { return (T)value; }
                catch (InvalidCastException)
                { throw new ArgumentException(string.Format(Strings.WrongType, value, typeof(T)), name); }
            }
            public int Add(object value)
            { wrappedList.Add(ConvertToItemType("value", value)); return wrappedList.Count - 1; }
            public void Clear()
            { wrappedList.Clear(); }
            public bool Contains(object value)
            {
                if (value is T)
                    return wrappedList.Contains((T)value);
                else
                    return false;
            }
            public int IndexOf(object value)
            {
                if (value is T)
                    return wrappedList.IndexOf((T)value);
                else
                    return -1;
            }
            public void Insert(int index, object value)
            { wrappedList.Insert(index, ConvertToItemType("value", value)); }
            public bool IsFixedSize
            { get { return false; } }
            public bool IsReadOnly
            { get { return wrappedList.IsReadOnly; } }
            public void Remove(object value)
            {
                if (value is T)
                    wrappedList.Remove((T)value);
            }
            public void RemoveAt(int index)
            { wrappedList.RemoveAt(index); }

            public object this[int index]
            {
                get { return wrappedList[index]; }
                set { wrappedList[index] = ConvertToItemType("value", value); }
            }
            public void CopyTo(Array array, int index)
            {
                if (array == null)
                    throw new ArgumentNullException("array"); int i = 0; int count = wrappedList.Count; if (index < 0)
                    throw new ArgumentOutOfRangeException("index", Strings.ArgMustNotBeNegative); if (index >= array.Length || count > array.Length - index)
                    throw new ArgumentException("index", Strings.ArrayTooSmall); foreach (T item in wrappedList)
                {
                    if (i >= count)
                        break; array.SetValue(item, index); ++index; ++i;
                }
            }
            public int Count
            { get { return wrappedList.Count; } }
            public bool IsSynchronized
            { get { return false; } }
            public object SyncRoot
            { get { return this; } }
            public IEnumerator GetEnumerator()
            { return ((IEnumerable)wrappedList).GetEnumerator(); }
        }

        public static IList Untyped<T>(IList<T> typedList)
        {
            if (typedList == null)
                return null;
            else if (typedList is IList)
                return (IList)typedList;
            else
                return new UntypedList<T>(typedList);
        }


#if !PCL
        [Serializable]
#endif
        private class ArrayWrapper<T> : ListBase<T>, IList
        {
            private T[] wrappedArray; public ArrayWrapper(T[] wrappedArray)
            { this.wrappedArray = wrappedArray; }
            public override int Count
            {
                get
                { return wrappedArray.Length; }
            }
            public override void Clear()
            {
                int count = wrappedArray.Length; for (int i = 0; i < count; ++i)
                    wrappedArray[i] = default(T);
            }
            public override void Insert(int index, T item)
            {
                if (index < 0 || index > wrappedArray.Length)
                    throw new ArgumentOutOfRangeException("index"); if (index + 1 < wrappedArray.Length)
                    Array.Copy(wrappedArray, index, wrappedArray, index + 1, wrappedArray.Length - index - 1); if (index < wrappedArray.Length)
                    wrappedArray[index] = item;
            }
            public override void RemoveAt(int index)
            {
                if (index < 0 || index >= wrappedArray.Length)
                    throw new ArgumentOutOfRangeException("index"); if (index < wrappedArray.Length - 1)
                    Array.Copy(wrappedArray, index + 1, wrappedArray, index, wrappedArray.Length - index - 1); wrappedArray[wrappedArray.Length - 1] = default(T);
            }
            public override T this[int index]
            {
                get
                {
                    if (index < 0 || index >= wrappedArray.Length)
                        throw new ArgumentOutOfRangeException("index"); return wrappedArray[index];
                }
                set
                {
                    if (index < 0 || index >= wrappedArray.Length)
                        throw new ArgumentOutOfRangeException("index"); wrappedArray[index] = value;
                }
            }
            public override void CopyTo(T[] array, int arrayIndex)
            {
                if (array == null)
                    throw new ArgumentNullException("array"); if (array.Length < wrappedArray.Length)
                    throw new ArgumentException("array is too short", "array"); if (arrayIndex < 0 || arrayIndex >= array.Length)
                    throw new ArgumentOutOfRangeException("arrayIndex"); if (array.Length + arrayIndex < wrappedArray.Length)
                    throw new ArgumentOutOfRangeException("arrayIndex"); Array.Copy(wrappedArray, 0, array, arrayIndex, wrappedArray.Length);
            }
            public override IEnumerator<T> GetEnumerator()
            { return ((IList<T>)wrappedArray).GetEnumerator(); }
            IEnumerator IEnumerable.GetEnumerator()
            { return ((IList)wrappedArray).GetEnumerator(); }
            bool IList.IsFixedSize
            {
                get
                { return true; }
            }
        }
        public static IList<T> ReadWriteList<T>(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array"); return new ArrayWrapper<T>(array);
        }

        #endregion Collection wrappers

        #region Replacing


        public static IEnumerable<T> Replace<T>(IEnumerable<T> collection, T itemFind, T replaceWith)
        { return Replace<T>(collection, itemFind, replaceWith, EqualityComparer<T>.Default); }
        public static IEnumerable<T> Replace<T>(IEnumerable<T> collection, T itemFind, T replaceWith, IEqualityComparer<T> equalityComparer)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); foreach (T item in collection)
            {
                if (equalityComparer.Equals(item, itemFind))
                    yield return replaceWith;
                else
                    yield return item;
            }
        }
        public static IEnumerable<T> Replace<T>(IEnumerable<T> collection, Predicate<T> predicate, T replaceWith)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (predicate == null)
                throw new ArgumentNullException("predicate"); foreach (T item in collection)
            {
                if (predicate(item))
                    yield return replaceWith;
                else
                    yield return item;
            }
        }
        public static void ReplaceInPlace<T>(IList<T> list, T itemFind, T replaceWith)
        { ReplaceInPlace(list, itemFind, replaceWith, EqualityComparer<T>.Default); }
        public static void ReplaceInPlace<T>(IList<T> list, T itemFind, T replaceWith, IEqualityComparer<T> equalityComparer)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); if (list is T[])
                list = new ArrayWrapper<T>((T[])list); if (list.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "list"); int listCount = list.Count; for (int index = 0; index < listCount; ++index)
            {
                if (equalityComparer.Equals(list[index], itemFind))
                    list[index] = replaceWith;
            }
        }
        public static void ReplaceInPlace<T>(IList<T> list, Predicate<T> predicate, T replaceWith)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (predicate == null)
                throw new ArgumentNullException("predicate"); if (list is T[])
                list = new ArrayWrapper<T>((T[])list); if (list.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "list"); int listCount = list.Count; for (int index = 0; index < listCount; ++index)
            {
                if (predicate(list[index]))
                    list[index] = replaceWith;
            }
        }

        #endregion Replacing

        #region Consecutive items


        public static IEnumerable<T> RemoveDuplicates<T>(IEnumerable<T> collection)
        { return RemoveDuplicates<T>(collection, EqualityComparer<T>.Default); }
        public static IEnumerable<T> RemoveDuplicates<T>(IEnumerable<T> collection, IEqualityComparer<T> equalityComparer)
        {
            if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); return RemoveDuplicates<T>(collection, equalityComparer.Equals);
        }
        public static IEnumerable<T> RemoveDuplicates<T>(IEnumerable<T> collection, BinaryPredicate<T> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (predicate == null)
                throw new ArgumentNullException("predicate"); T current = default(T); bool atBeginning = true; foreach (T item in collection)
            {
                if (atBeginning || !predicate(current, item))
                { current = item; yield return item; }
                atBeginning = false;
            }
        }
        public static void RemoveDuplicatesInPlace<T>(IList<T> list)
        { RemoveDuplicatesInPlace<T>(list, EqualityComparer<T>.Default); }
        public static void RemoveDuplicatesInPlace<T>(IList<T> list, IEqualityComparer<T> equalityComparer)
        {
            if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); RemoveDuplicatesInPlace<T>(list, equalityComparer.Equals);
        }
        public static void RemoveDuplicatesInPlace<T>(IList<T> list, BinaryPredicate<T> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (predicate == null)
                throw new ArgumentNullException("predicate"); if (list is T[])
                list = new ArrayWrapper<T>((T[])list); if (list.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "list"); T current = default(T); T item; int i = -1, j = 0; int listCount = list.Count; while (j < listCount)
            {
                item = list[j]; if (i < 0 || !predicate(current, item))
                {
                    current = item; ++i; if (i != j)
                        list[i] = current;
                }
                ++j;
            }
            ++i; if (i < listCount)
            {
                if (list is ArrayWrapper<T> || (list is IList && ((IList)list).IsFixedSize))
                {
                    while (i < listCount)
                        list[i++] = default(T);
                }
                else
                {
                    while (i < listCount)
                    { list.RemoveAt(listCount - 1); --listCount; }
                }
            }
        }
        public static int FirstConsecutiveEqual<T>(IList<T> list, int count)
        { return FirstConsecutiveEqual<T>(list, count, EqualityComparer<T>.Default); }
        public static int FirstConsecutiveEqual<T>(IList<T> list, int count, IEqualityComparer<T> equalityComparer)
        {
            if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); return FirstConsecutiveEqual<T>(list, count, equalityComparer.Equals);
        }
        public static int FirstConsecutiveEqual<T>(IList<T> list, int count, BinaryPredicate<T> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (predicate == null)
                throw new ArgumentNullException("predicate"); if (count < 1)
                throw new ArgumentOutOfRangeException("count"); int listCount = list.Count; if (listCount < count)
                return -1; if (count == 1)
                return 0; int start = 0, index = 0; T current = default(T); int runLength = 0; foreach (T item in list)
            {
                if (index > 0 && predicate(current, item))
                {
                    ++runLength; if (runLength >= count)
                        return start;
                }
                else
                { current = item; start = index; runLength = 1; }
                ++index;
            }
            return -1;
        }

        public static int FirstConsecutiveWhere<T>(IList<T> list, int count, Predicate<T> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (predicate == null)
                throw new ArgumentNullException("predicate"); if (count < 1)
                throw new ArgumentOutOfRangeException("count"); int listCount = list.Count; if (count > listCount)
                return -1; int index = 0, start = -1; int runLength = 0; foreach (T item in list)
            {
                if (predicate(item))
                {
                    if (start < 0)
                        start = index; ++runLength; if (runLength >= count)
                        return start;
                }
                else
                { runLength = 0; start = -1; }
                ++index;
            }
            return -1;
        }

        #endregion Consecutive items

        #region Find and SearchForSubsequence



        public static T FindFirstWhere<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            T retval; if (Algorithms.TryFindFirstWhere<T>(collection, predicate, out retval))
                return retval;
            else
                return default(T);
        }
        public static bool TryFindFirstWhere<T>(IEnumerable<T> collection, Predicate<T> predicate, out T foundItem)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (predicate == null)
                throw new ArgumentNullException("predicate"); foreach (T item in collection)
            {
                if (predicate(item))
                { foundItem = item; return true; }
            }
            foundItem = default(T); return false;
        }
        public static T FindLastWhere<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            T retval; if (Algorithms.TryFindLastWhere<T>(collection, predicate, out retval))
                return retval;
            else
                return default(T);
        }
        public static bool TryFindLastWhere<T>(IEnumerable<T> collection, Predicate<T> predicate, out T foundItem)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (predicate == null)
                throw new ArgumentNullException("predicate"); IList<T> list = collection as IList<T>; if (list != null)
            {
                for (int index = list.Count - 1; index >= 0; --index)
                {
                    T item = list[index]; if (predicate(item))
                    { foundItem = item; return true; }
                }
                foundItem = default(T); return false;
            }
            else
            {
                bool found = false; foundItem = default(T); foreach (T item in collection)
                {
                    if (predicate(item))
                    { foundItem = item; found = true; }
                }
                return found;
            }
        }
        public static IEnumerable<T> FindWhere<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (predicate == null)
                throw new ArgumentNullException("predicate"); foreach (T item in collection)
            {
                if (predicate(item))
                { yield return item; }
            }
        }
        public static int FindFirstIndexWhere<T>(IList<T> list, Predicate<T> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (predicate == null)
                throw new ArgumentNullException("predicate"); int index = 0; foreach (T item in list)
            {
                if (predicate(item))
                { return index; }
                ++index;
            }
            return -1;
        }
        public static int FindLastIndexWhere<T>(IList<T> list, Predicate<T> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (predicate == null)
                throw new ArgumentNullException("predicate"); for (int index = list.Count - 1; index >= 0; --index)
            {
                if (predicate(list[index]))
                { return index; }
            }
            return -1;
        }
        public static IEnumerable<int> FindIndicesWhere<T>(IList<T> list, Predicate<T> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (predicate == null)
                throw new ArgumentNullException("predicate"); int index = 0; foreach (T item in list)
            {
                if (predicate(item))
                { yield return index; }
                ++index;
            }
        }
        public static int FirstIndexOf<T>(IList<T> list, T item)
        { return FirstIndexOf<T>(list, item, EqualityComparer<T>.Default); }
        public static int FirstIndexOf<T>(IList<T> list, T item, IEqualityComparer<T> equalityComparer)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); int index = 0; foreach (T x in list)
            {
                if (equalityComparer.Equals(x, item))
                { return index; }
                ++index;
            }
            return -1;
        }
        public static int LastIndexOf<T>(IList<T> list, T item)
        { return LastIndexOf<T>(list, item, EqualityComparer<T>.Default); }
        public static int LastIndexOf<T>(IList<T> list, T item, IEqualityComparer<T> equalityComparer)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); for (int index = list.Count - 1; index >= 0; --index)
            {
                if (equalityComparer.Equals(list[index], item))
                { return index; }
            }
            return -1;
        }
        public static IEnumerable<int> IndicesOf<T>(IList<T> list, T item)
        { return IndicesOf<T>(list, item, EqualityComparer<T>.Default); }
        public static IEnumerable<int> IndicesOf<T>(IList<T> list, T item, IEqualityComparer<T> equalityComparer)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); int index = 0; foreach (T x in list)
            {
                if (equalityComparer.Equals(x, item))
                { yield return index; }
                ++index;
            }
        }

        public static int FirstIndexOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor)
        { return FirstIndexOfMany<T>(list, itemsToLookFor, EqualityComparer<T>.Default); }
        public static int FirstIndexOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor, IEqualityComparer<T> equalityComparer)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (itemsToLookFor == null)
                throw new ArgumentNullException("itemsToLookFor"); if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); Set<T> setToLookFor = new Set<T>(itemsToLookFor, equalityComparer); int index = 0; foreach (T x in list)
            {
                if (setToLookFor.Contains(x))
                { return index; }
                ++index;
            }
            return -1;
        }
        public static int FirstIndexOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor, BinaryPredicate<T> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (itemsToLookFor == null)
                throw new ArgumentNullException("itemsToLookFor"); if (predicate == null)
                throw new ArgumentNullException("predicate"); int index = 0; foreach (T x in list)
            {
                foreach (T y in itemsToLookFor)
                {
                    if (predicate(x, y))
                    { return index; }
                }
                ++index;
            }
            return -1;
        }
        public static int LastIndexOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor)
        { return LastIndexOfMany(list, itemsToLookFor, EqualityComparer<T>.Default); }
        public static int LastIndexOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor, IEqualityComparer<T> equalityComparer)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (itemsToLookFor == null)
                throw new ArgumentNullException("itemsToLookFor"); if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); Set<T> setToLookFor = new Set<T>(itemsToLookFor, equalityComparer); for (int index = list.Count - 1; index >= 0; --index)
            {
                if (setToLookFor.Contains(list[index]))
                { return index; }
            }
            return -1;
        }
        public static int LastIndexOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor, BinaryPredicate<T> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (itemsToLookFor == null)
                throw new ArgumentNullException("itemsToLookFor"); if (predicate == null)
                throw new ArgumentNullException("predicate"); for (int index = list.Count - 1; index >= 0; --index)
            {
                foreach (T y in itemsToLookFor)
                {
                    if (predicate(list[index], y))
                    { return index; }
                }
            }
            return -1;
        }
        public static IEnumerable<int> IndicesOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor)
        { return IndicesOfMany<T>(list, itemsToLookFor, EqualityComparer<T>.Default); }
        public static IEnumerable<int> IndicesOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor, IEqualityComparer<T> equalityComparer)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (itemsToLookFor == null)
                throw new ArgumentNullException("itemsToLookFor"); if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); Set<T> setToLookFor = new Set<T>(itemsToLookFor, equalityComparer); int index = 0; foreach (T x in list)
            {
                if (setToLookFor.Contains(x))
                { yield return index; }
                ++index;
            }
        }
        public static IEnumerable<int> IndicesOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor, BinaryPredicate<T> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (itemsToLookFor == null)
                throw new ArgumentNullException("itemsToLookFor"); if (predicate == null)
                throw new ArgumentNullException("predicate"); int index = 0; foreach (T x in list)
            {
                foreach (T y in itemsToLookFor)
                {
                    if (predicate(x, y))
                    { yield return index; }
                }
                ++index;
            }
        }
        public static int SearchForSubsequence<T>(IList<T> list, IEnumerable<T> pattern)
        { return SearchForSubsequence<T>(list, pattern, EqualityComparer<T>.Default); }

        public static int SearchForSubsequence<T>(IList<T> list, IEnumerable<T> pattern, BinaryPredicate<T> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (pattern == null)
                throw new ArgumentNullException("pattern"); if (predicate == null)
                throw new ArgumentNullException("predicate"); T[] patternArray = Algorithms.ToArray<T>(pattern); int listCount = list.Count, patternCount = patternArray.Length; if (patternCount == 0)
                return 0; if (listCount == 0)
                return -1;


            for (int start = 0; start <= listCount - patternCount; ++start)
            {
                for (int count = 0; count < patternCount; ++count)
                {
                    if (!predicate(list[start + count], patternArray[count]))
                        goto NOMATCH;
                }


                return start;

            NOMATCH:
                /* no match found at start. */
                ;
            }



            return -1;
        }

        public static int SearchForSubsequence<T>(IList<T> list, IEnumerable<T> pattern, IEqualityComparer<T> equalityComparer)
        {
            if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer");

            return SearchForSubsequence<T>(list, pattern, equalityComparer.Equals);
        }

        #endregion Find and SearchForSubsequence

        #region Set operations (coded except EqualSets)

        public static bool IsSubsetOf<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        { return IsSubsetOf(collection1, collection2, EqualityComparer<T>.Default); }
        public static bool IsSubsetOf<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
        {
            if (collection1 == null)
                throw new ArgumentNullException("collection1"); if (collection2 == null)
                throw new ArgumentNullException("collection2"); if (equalityComparer == null)
                throw new ArgumentException("equalityComparer"); Bag<T> bag1 = new Bag<T>(collection1, equalityComparer); Bag<T> bag2 = new Bag<T>(collection2, equalityComparer); return bag2.IsSupersetOf(bag1);
        }
        public static bool IsProperSubsetOf<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        { return IsProperSubsetOf(collection1, collection2, EqualityComparer<T>.Default); }
        public static bool IsProperSubsetOf<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
        {
            if (collection1 == null)
                throw new ArgumentNullException("collection1"); if (collection2 == null)
                throw new ArgumentNullException("collection2"); if (equalityComparer == null)
                throw new ArgumentException("equalityComparer"); Bag<T> bag1 = new Bag<T>(collection1, equalityComparer); Bag<T> bag2 = new Bag<T>(collection2, equalityComparer); return bag2.IsProperSupersetOf(bag1);
        }
        public static bool DisjointSets<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        { return DisjointSets(collection1, collection2, EqualityComparer<T>.Default); }
        public static bool DisjointSets<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
        {
            if (collection1 == null)
                throw new ArgumentNullException("collection1"); if (collection2 == null)
                throw new ArgumentNullException("collection2"); if (equalityComparer == null)
                throw new ArgumentException("equalityComparer"); Set<T> set1 = new Set<T>(collection1, equalityComparer); foreach (T item2 in collection2)
            {
                if (set1.Contains(item2))
                    return false;
            }
            return true;
        }
        public static bool EqualSets<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        { return EqualSets(collection1, collection2, EqualityComparer<T>.Default); }
        public static bool EqualSets<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
        {
            if (collection1 == null)
                throw new ArgumentNullException("collection1"); if (collection2 == null)
                throw new ArgumentNullException("collection2"); if (equalityComparer == null)
                throw new ArgumentException("equalityComparer"); Bag<T> bag1 = new Bag<T>(collection1, equalityComparer); Bag<T> bag2 = new Bag<T>(collection2, equalityComparer); return bag2.IsEqualTo(bag1);
        }
        public static IEnumerable<T> SetIntersection<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        { return SetIntersection(collection1, collection2, EqualityComparer<T>.Default); }
        public static IEnumerable<T> SetIntersection<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
        {
            if (collection1 == null)
                throw new ArgumentNullException("collection1"); if (collection2 == null)
                throw new ArgumentNullException("collection2"); if (equalityComparer == null)
                throw new ArgumentException("equalityComparer"); Bag<T> bag1 = new Bag<T>(collection1, equalityComparer); Bag<T> bag2 = new Bag<T>(collection2, equalityComparer); return Util.CreateEnumerableWrapper(bag1.Intersection(bag2));
        }
        public static IEnumerable<T> SetUnion<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        { return SetUnion(collection1, collection2, EqualityComparer<T>.Default); }
        public static IEnumerable<T> SetUnion<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
        {
            if (collection1 == null)
                throw new ArgumentNullException("collection1"); if (collection2 == null)
                throw new ArgumentNullException("collection2"); if (equalityComparer == null)
                throw new ArgumentException("equalityComparer"); Bag<T> bag1 = new Bag<T>(collection1, equalityComparer); Bag<T> bag2 = new Bag<T>(collection2, equalityComparer); if (bag1.Count > bag2.Count)
            { bag1.UnionWith(bag2); return Util.CreateEnumerableWrapper(bag1); }
            else
            { bag2.UnionWith(bag1); return Util.CreateEnumerableWrapper(bag2); }
        }
        public static IEnumerable<T> SetDifference<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        { return SetDifference(collection1, collection2, EqualityComparer<T>.Default); }
        public static IEnumerable<T> SetDifference<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
        {
            if (collection1 == null)
                throw new ArgumentNullException("collection1"); if (collection2 == null)
                throw new ArgumentNullException("collection2"); if (equalityComparer == null)
                throw new ArgumentException("equalityComparer"); Bag<T> bag1 = new Bag<T>(collection1, equalityComparer); Bag<T> bag2 = new Bag<T>(collection2, equalityComparer); bag1.DifferenceWith(bag2); return Util.CreateEnumerableWrapper(bag1);
        }
        public static IEnumerable<T> SetSymmetricDifference<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        { return SetSymmetricDifference(collection1, collection2, EqualityComparer<T>.Default); }
        public static IEnumerable<T> SetSymmetricDifference<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
        {
            if (collection1 == null)
                throw new ArgumentNullException("collection1"); if (collection2 == null)
                throw new ArgumentNullException("collection2"); if (equalityComparer == null)
                throw new ArgumentException("equalityComparer"); Bag<T> bag1 = new Bag<T>(collection1, equalityComparer); Bag<T> bag2 = new Bag<T>(collection2, equalityComparer); if (bag1.Count > bag2.Count)
            { bag1.SymmetricDifferenceWith(bag2); return Util.CreateEnumerableWrapper(bag1); }
            else
            { bag2.SymmetricDifferenceWith(bag1); return Util.CreateEnumerableWrapper(bag2); }
        }
        public static IEnumerable<Pair<TFirst, TSecond>> CartesianProduct<TFirst, TSecond>(IEnumerable<TFirst> first, IEnumerable<TSecond> second)
        {
            if (first == null)
                throw new ArgumentNullException("first"); if (second == null)
                throw new ArgumentNullException("second"); foreach (TFirst itemFirst in first)
                foreach (TSecond itemSecond in second)
                    yield return new Pair<TFirst, TSecond>(itemFirst, itemSecond);
        }

        #endregion Set operations (coded except EqualSets)

        #region String representations (not yet coded)


        public static string ToString<T>(IEnumerable<T> collection)
        {
            return ToString(collection, true, "{", ",", "}");
        }

        public static string ToString<T>(IEnumerable<T> collection, bool recursive, string start, string separator, string end)
        {
            if (start == null)
                throw new ArgumentNullException("start"); if (separator == null)
                throw new ArgumentNullException("separator"); if (end == null)
                throw new ArgumentNullException("end"); if (collection == null)
                return "null"; bool firstItem = true; System.Text.StringBuilder builder = new System.Text.StringBuilder(); builder.Append(start); foreach (T item in collection)
            {
                if (!firstItem)
                    builder.Append(separator); if (item == null)
                    builder.Append("null");
                else if (recursive && item is IEnumerable && !(item is string))
                    builder.Append(Algorithms.ToString(Algorithms.TypedAs<object>((IEnumerable)item), recursive, start, separator, end));
                else
                    builder.Append(item.ToString()); firstItem = false;
            }
            builder.Append(end); return builder.ToString();
        }

        public static string ToString<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            bool firstItem = true;

            if (dictionary == null)
                return "null";

            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            builder.Append("{");



            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
            {
                if (!firstItem)
                    builder.Append(", "); if (pair.Key == null)
                    builder.Append("null");
                else if (pair.Key is IEnumerable && !(pair.Key is string))
                    builder.Append(Algorithms.ToString(Algorithms.TypedAs<object>((IEnumerable)pair.Key), true, "{", ",", "}"));
                else
                    builder.Append(pair.Key.ToString()); builder.Append("->"); if (pair.Value == null)
                    builder.Append("null");
                else if (pair.Value is IEnumerable && !(pair.Value is string))
                    builder.Append(Algorithms.ToString(Algorithms.TypedAs<object>((IEnumerable)pair.Value), true, "{", ",", "}"));
                else
                    builder.Append(pair.Value.ToString()); firstItem = false;
            }

            builder.Append("}");
            return builder.ToString();
        }

        #endregion String representations (not yet coded)

        #region Shuffles and Permutations

        private static volatile Random myRandomGenerator; private static Random GetRandomGenerator()
        {
            if (myRandomGenerator == null)
            {
                lock (typeof(Algorithms))
                {
                    if (myRandomGenerator == null)
                        myRandomGenerator = new Random();
                }
            }
            return myRandomGenerator;
        }
        public static T[] RandomShuffle<T>(IEnumerable<T> collection)
        { return RandomShuffle<T>(collection, GetRandomGenerator()); }
        public static T[] RandomShuffle<T>(IEnumerable<T> collection, Random randomGenerator)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (randomGenerator == null)
                throw new ArgumentNullException("randomGenerator"); T[] array = Algorithms.ToArray(collection); int count = array.Length; for (int i = count - 1; i >= 1; --i)
            { int j = randomGenerator.Next(i + 1); T temp = array[i]; array[i] = array[j]; array[j] = temp; }
            return array;
        }
        public static void RandomShuffleInPlace<T>(IList<T> list)
        { RandomShuffleInPlace<T>(list, GetRandomGenerator()); }
        public static void RandomShuffleInPlace<T>(IList<T> list, Random randomGenerator)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (randomGenerator == null)
                throw new ArgumentNullException("randomGenerator"); if (list is T[])
                list = new ArrayWrapper<T>((T[])list); if (list.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "list"); int count = list.Count; for (int i = count - 1; i >= 1; --i)
            { int j = randomGenerator.Next(i + 1); T temp = list[i]; list[i] = list[j]; list[j] = temp; }
        }
        public static T[] RandomSubset<T>(IEnumerable<T> collection, int count)
        { return RandomSubset<T>(collection, count, GetRandomGenerator()); }
        public static T[] RandomSubset<T>(IEnumerable<T> collection, int count, Random randomGenerator)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (randomGenerator == null)
                throw new ArgumentNullException("randomGenerator"); IList<T> list = collection as IList<T>; if (list == null)
            { list = new List<T>(collection); }
            int listCount = list.Count; if (count < 0 || count > listCount)
                throw new ArgumentOutOfRangeException("count"); T[] result = new T[count]; Dictionary<int, T> swappedValues = new Dictionary<int, T>(count); for (int i = 0; i < count; ++i)
            {
                T value; int j = randomGenerator.Next(listCount - i) + i; if (!swappedValues.TryGetValue(j, out value))
                    value = list[j]; result[i] = value; if (i != j)
                {
                    if (swappedValues.TryGetValue(i, out value))
                        swappedValues[j] = value;
                    else
                        swappedValues[j] = list[i];
                }
            }
            return result;
        }

        public static IEnumerable<T[]> GeneratePermutations<T>(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); T[] array = Algorithms.ToArray(collection); if (array.Length == 0)
                yield break; int[] state = new int[array.Length - 1]; int maxLength = state.Length; yield return array; if (array.Length == 1)
                yield break; int i = 0; T temp; for (;;)
            {
                if (state[i] < i + 1)
                {
                    if (state[i] > 0)
                    { temp = array[i + 1]; array[i + 1] = array[state[i] - 1]; array[state[i] - 1] = temp; }
                    temp = array[i + 1]; array[i + 1] = array[state[i]]; array[state[i]] = temp; yield return array; ++state[i]; i = 0;
                }
                else
                {
                    temp = array[i + 1]; array[i + 1] = array[i]; array[i] = temp; state[i] = 0; ++i; if (i >= maxLength)
                        yield break;
                }
            }
        }

        public static IEnumerable<T[]> GenerateSortedPermutations<T>(IEnumerable<T> collection)
            where T : IComparable<T>
        {
            return GenerateSortedPermutations<T>(collection, Comparer<T>.Default);
        }

        public static IEnumerable<T[]> GenerateSortedPermutations<T>(IEnumerable<T> collection, IComparer<T> comparer)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (comparer == null)
                throw new ArgumentNullException("comparer"); T[] array = Algorithms.ToArray(collection); int length = array.Length; if (length == 0)
                yield break; Array.Sort(array, comparer); yield return array; if (length == 1)
                yield break; int key, swap, i, j; T temp; for (;;)
            {
                key = length - 2; while (comparer.Compare(array[key], array[key + 1]) >= 0)
                {
                    --key; if (key < 0)
                        yield break;
                }
                swap = length - 1; while (comparer.Compare(array[swap], array[key]) <= 0)
                    --swap; temp = array[key]; array[key] = array[swap]; array[swap] = temp; i = key + 1; j = length - 1; while (i < j)
                { temp = array[i]; array[i] = array[j]; array[j] = temp; ++i; --j; }
                yield return array;
            }
        }

        public static IEnumerable<T[]> GenerateSortedPermutations<T>(IEnumerable<T> collection, Comparison<T> comparison)
        {
            return GenerateSortedPermutations(collection, Comparers.ComparerFromComparison<T>(comparison));
        }

        #endregion Shuffles and Permutations

        #region Minimum and Maximum

        public static T Maximum<T>(IEnumerable<T> collection)
            where T : IComparable<T>
        {
            return Maximum<T>(collection, Comparer<T>.Default);
        }

        public static T Maximum<T>(IEnumerable<T> collection, IComparer<T> comparer)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            if (comparer == null)
                throw new ArgumentNullException("comparer");

            T maxSoFar = default(T);
            bool foundOne = false;

            foreach (T item in collection)
            {
                if (!foundOne || comparer.Compare(maxSoFar, item) < 0)
                {
                    maxSoFar = item;
                }

                foundOne = true;
            }

            if (!foundOne)
                throw new InvalidOperationException(Strings.CollectionIsEmpty);
            else
                return maxSoFar;
        }

        public static T Maximum<T>(IEnumerable<T> collection, Comparison<T> comparison)
        {
            return Maximum<T>(collection, Comparers.ComparerFromComparison<T>(comparison));
        }

        public static T Minimum<T>(IEnumerable<T> collection)
            where T : IComparable<T>
        {
            return Minimum<T>(collection, Comparer<T>.Default);
        }

        public static T Minimum<T>(IEnumerable<T> collection, IComparer<T> comparer)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (comparer == null)
                throw new ArgumentNullException("comparer"); T minSoFar = default(T); bool foundOne = false; foreach (T item in collection)
            {
                if (!foundOne || comparer.Compare(minSoFar, item) > 0)
                { minSoFar = item; }
                foundOne = true;
            }
            if (!foundOne)
                throw new InvalidOperationException(Strings.CollectionIsEmpty);
            else
                return minSoFar;
        }
        public static T Minimum<T>(IEnumerable<T> collection, Comparison<T> comparison)
        { return Minimum<T>(collection, Comparers.ComparerFromComparison<T>(comparison)); }
        public static int IndexOfMaximum<T>(IList<T> list)
        where T : IComparable<T>
        { return IndexOfMaximum<T>(list, Comparer<T>.Default); }
        public static int IndexOfMaximum<T>(IList<T> list, IComparer<T> comparer)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (comparer == null)
                throw new ArgumentNullException("comparer"); T maxSoFar = default(T); int indexSoFar = -1; int i = 0; foreach (T item in list)
            {
                if (indexSoFar < 0 || comparer.Compare(maxSoFar, item) < 0)
                { maxSoFar = item; indexSoFar = i; }
                ++i;
            }
            return indexSoFar;
        }
        public static int IndexOfMaximum<T>(IList<T> list, Comparison<T> comparison)
        { return IndexOfMaximum<T>(list, Comparers.ComparerFromComparison<T>(comparison)); }
        public static int IndexOfMinimum<T>(IList<T> list)
        where T : IComparable<T>
        { return IndexOfMinimum<T>(list, Comparer<T>.Default); }
        public static int IndexOfMinimum<T>(IList<T> list, IComparer<T> comparer)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (comparer == null)
                throw new ArgumentNullException("comparer"); T minSoFar = default(T); int indexSoFar = -1; int i = 0; foreach (T item in list)
            {
                if (indexSoFar < 0 || comparer.Compare(minSoFar, item) > 0)
                { minSoFar = item; indexSoFar = i; }
                ++i;
            }
            return indexSoFar;
        }

        public static int IndexOfMinimum<T>(IList<T> list, Comparison<T> comparison)
        {
            return IndexOfMinimum<T>(list, Comparers.ComparerFromComparison<T>(comparison));
        }

        #endregion Minimum and Maximum

        #region Sorting and operations on sorted collections

        public static T[] Sort<T>(IEnumerable<T> collection)
where T : IComparable<T>
        {
            return Sort<T>(collection, Comparer<T>.Default);
        }

        public static T[] Sort<T>(IEnumerable<T> collection, IComparer<T> comparer)
        {
            T[] array;

            if (collection == null)
                throw new ArgumentNullException("collection");
            if (comparer == null)
                throw new ArgumentNullException("comparer");

            array = Algorithms.ToArray(collection);

            Array.Sort(array, comparer);
            return array;
        }

        public static T[] Sort<T>(IEnumerable<T> collection, Comparison<T> comparison)
        {
            return Sort<T>(collection, Comparers.ComparerFromComparison<T>(comparison));
        }

        public static void SortInPlace<T>(IList<T> list)
            where T : IComparable<T>
        {
            SortInPlace<T>(list, Comparer<T>.Default);
        }

        public static void SortInPlace<T>(IList<T> list, IComparer<T> comparer)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (comparer == null)
                throw new ArgumentNullException("comparer"); if (list is T[])
            { Array.Sort((T[])list, comparer); return; }
            if (list.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "list"); int[] leftStack = new int[32], rightStack = new int[32]; int stackPtr = 0; int l = 0; int r = list.Count - 1; T partition; for (;;)
            {
                if (l == r - 1)
                {
                    T e1, e2; e1 = list[l]; e2 = list[r]; if (comparer.Compare(e1, e2) > 0)
                    { list[r] = e1; list[l] = e2; }
                    l = r;
                }
                else if (l < r)
                {
                    int m = l + (r - l) / 2; T e1 = list[l], e2 = list[m], e3 = list[r], temp; if (comparer.Compare(e1, e2) > 0)
                    { temp = e1; e1 = e2; e2 = temp; }
                    if (comparer.Compare(e1, e3) > 0)
                    { temp = e3; e3 = e2; e2 = e1; e1 = temp; }
                    else if (comparer.Compare(e2, e3) > 0)
                    { temp = e2; e2 = e3; e3 = temp; }
                    if (l == r - 2)
                    { list[l] = e1; list[m] = e2; list[r] = e3; l = r; }
                    else
                    {
                        list[l] = e1; list[m] = e3; list[r] = partition = e2; int i = l, j = r; T item_i, item_j; for (;;)
                        {
                            do
                            { ++i; item_i = list[i]; } while (comparer.Compare(item_i, partition) < 0); do
                            { --j; item_j = list[j]; } while (comparer.Compare(item_j, partition) > 0); if (j < i)
                                break; list[i] = item_j; list[j] = item_i;
                        }
                        list[r] = item_i; list[i] = partition; ++i; if ((j - l) > (r - i))
                        { leftStack[stackPtr] = l; rightStack[stackPtr] = j; l = i; }
                        else
                        { leftStack[stackPtr] = i; rightStack[stackPtr] = r; r = j; }
                        ++stackPtr;
                    }
                }
                else if (stackPtr > 0)
                { --stackPtr; l = leftStack[stackPtr]; r = rightStack[stackPtr]; }
                else
                { break; }
            }
        }

        public static void SortInPlace<T>(IList<T> list, Comparison<T> comparison)
        {
            SortInPlace<T>(list, Comparers.ComparerFromComparison<T>(comparison));
        }

        public static T[] StableSort<T>(IEnumerable<T> collection)
where T : IComparable<T>
        { return StableSort(collection, Comparer<T>.Default); }
        public static T[] StableSort<T>(IEnumerable<T> collection, IComparer<T> comparer)
        {
            T[] array; if (collection == null)
                throw new ArgumentNullException("collection"); if (comparer == null)
                throw new ArgumentNullException("comparer"); array = Algorithms.ToArray(collection); StableSortInPlace<T>(Algorithms.ReadWriteList<T>(array), comparer); return array;
        }
        public static T[] StableSort<T>(IEnumerable<T> collection, Comparison<T> comparison)
        { return StableSort<T>(collection, Comparers.ComparerFromComparison<T>(comparison)); }
        public static void StableSortInPlace<T>(IList<T> list)
        where T : IComparable<T>
        { StableSortInPlace<T>(list, Comparer<T>.Default); }
        public static void StableSortInPlace<T>(IList<T> list, IComparer<T> comparer)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (comparer == null)
                throw new ArgumentNullException("comparer"); if (list is T[])
                list = new ArrayWrapper<T>((T[])list); if (list.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "list"); int[] order = new int[list.Count]; for (int x = 0; x < order.Length; ++x)
                order[x] = x; int[] leftStack = new int[32], rightStack = new int[32]; int stackPtr = 0; int l = 0; int r = list.Count - 1; T partition; int order_partition; int c; for (;;)
            {
                if (l == r - 1)
                {
                    T e1, e2; int o1, o2; e1 = list[l]; o1 = order[l]; e2 = list[r]; o2 = order[r]; if ((c = comparer.Compare(e1, e2)) > 0 || (c == 0 && o1 > o2))
                    { list[r] = e1; order[r] = o1; list[l] = e2; order[l] = o2; }
                    l = r;
                }
                else if (l < r)
                {
                    int m = l + (r - l) / 2; T e1 = list[l], e2 = list[m], e3 = list[r], temp; int o1 = order[l], o2 = order[m], o3 = order[r], otemp; if ((c = comparer.Compare(e1, e2)) > 0 || (c == 0 && o1 > o2))
                    { temp = e1; e1 = e2; e2 = temp; otemp = o1; o1 = o2; o2 = otemp; }
                    if ((c = comparer.Compare(e1, e3)) > 0 || (c == 0 && o1 > o3))
                    { temp = e3; e3 = e2; e2 = e1; e1 = temp; otemp = o3; o3 = o2; o2 = o1; o1 = otemp; }
                    else if ((c = comparer.Compare(e2, e3)) > 0 || (c == 0 && o2 > o3))
                    { temp = e2; e2 = e3; e3 = temp; otemp = o2; o2 = o3; o3 = otemp; }
                    if (l == r - 2)
                    { list[l] = e1; list[m] = e2; list[r] = e3; order[l] = o1; order[m] = o2; order[r] = o3; l = r; }
                    else
                    {
                        list[l] = e1; order[l] = o1; list[m] = e3; order[m] = o3; list[r] = partition = e2; order[r] = order_partition = o2; int i = l, j = r; T item_i, item_j; int order_i, order_j; for (;;)
                        {
                            do
                            { ++i; item_i = list[i]; order_i = order[i]; } while ((c = comparer.Compare(item_i, partition)) < 0 || (c == 0 && order_i < order_partition)); do
                            { --j; item_j = list[j]; order_j = order[j]; } while ((c = comparer.Compare(item_j, partition)) > 0 || (c == 0 && order_j > order_partition)); if (j < i)
                                break; list[i] = item_j; list[j] = item_i; order[i] = order_j; order[j] = order_i;
                        }
                        list[r] = item_i; order[r] = order_i; list[i] = partition; order[i] = order_partition; ++i; if ((j - l) > (r - i))
                        { leftStack[stackPtr] = l; rightStack[stackPtr] = j; l = i; }
                        else
                        { leftStack[stackPtr] = i; rightStack[stackPtr] = r; r = j; }
                        ++stackPtr;
                    }
                }
                else if (stackPtr > 0)
                { --stackPtr; l = leftStack[stackPtr]; r = rightStack[stackPtr]; }
                else
                { break; }
            }
        }

        public static void StableSortInPlace<T>(IList<T> list, Comparison<T> comparison)
        {
            StableSortInPlace<T>(list, Comparers.ComparerFromComparison<T>(comparison));
        }

        public static int BinarySearch<T>(IList<T> list, T item, out int index)
            where T : IComparable<T>
        {
            return BinarySearch<T>(list, item, Comparer<T>.Default, out index);
        }

        public static int BinarySearch<T>(IList<T> list, T item, IComparer<T> comparer, out int index)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (comparer == null)
                throw new ArgumentNullException("comparer"); int l = 0; int r = list.Count; while (r > l)
            {
                int m = l + (r - l) / 2; T middleItem = list[m]; int comp = comparer.Compare(middleItem, item); if (comp < 0)
                { l = m + 1; }
                else if (comp > 0)
                { r = m; }
                else
                {
                    int lFound = l, rFound = r, found = m; l = lFound; r = found; while (r > l)
                    {
                        m = l + (r - l) / 2; middleItem = list[m]; comp = comparer.Compare(middleItem, item); if (comp < 0)
                        { l = m + 1; }
                        else
                        { r = m; }
                    }
                    System.Diagnostics.Debug.Assert(l == r); index = l; l = found; r = rFound; while (r > l)
                    {
                        m = l + (r - l) / 2; middleItem = list[m]; comp = comparer.Compare(middleItem, item); if (comp <= 0)
                        { l = m + 1; }
                        else
                        { r = m; }
                    }
                    System.Diagnostics.Debug.Assert(l == r); return l - index;
                }
            }
            System.Diagnostics.Debug.Assert(l == r); index = l; return 0;
        }
        public static int BinarySearch<T>(IList<T> list, T item, Comparison<T> comparison, out int index)
        { return BinarySearch<T>(list, item, Comparers.ComparerFromComparison<T>(comparison), out index); }
        public static IEnumerable<T> MergeSorted<T>(params IEnumerable<T>[] collections)
        where T : IComparable<T>
        { return MergeSorted<T>(Comparer<T>.Default, collections); }
        public static IEnumerable<T> MergeSorted<T>(IComparer<T> comparer, params IEnumerable<T>[] collections)
        {
            if (collections == null)
                throw new ArgumentNullException("collections"); if (comparer == null)
                throw new ArgumentNullException("comparer"); IEnumerator<T>[] enumerators = new IEnumerator<T>[collections.Length]; bool[] more = new bool[collections.Length]; T smallestItem = default(T); int smallestItemIndex; try
            {
                for (int i = 0; i < collections.Length; ++i)
                {
                    if (collections[i] != null)
                    { enumerators[i] = collections[i].GetEnumerator(); more[i] = enumerators[i].MoveNext(); }
                }
                for (;;)
                {
                    smallestItemIndex = -1; for (int i = 0; i < enumerators.Length; ++i)
                    {
                        if (more[i])
                        {
                            T item = enumerators[i].Current; if (smallestItemIndex < 0 || comparer.Compare(smallestItem, item) > 0)
                            { smallestItemIndex = i; smallestItem = item; }
                        }
                    }
                    if (smallestItemIndex == -1)
                        yield break; yield return smallestItem; more[smallestItemIndex] = enumerators[smallestItemIndex].MoveNext();
                }
            }
            finally
            {
                foreach (IEnumerator<T> e in enumerators)
                {
                    if (e != null)
                        e.Dispose();
                }
            }
        }
        public static IEnumerable<T> MergeSorted<T>(Comparison<T> comparison, params IEnumerable<T>[] collections)
        { return MergeSorted<T>(Comparers.ComparerFromComparison<T>(comparison), collections); }
        public static int LexicographicalCompare<T>(IEnumerable<T> sequence1, IEnumerable<T> sequence2)
        where T : IComparable<T>
        { return LexicographicalCompare<T>(sequence1, sequence2, Comparer<T>.Default); }
        public static int LexicographicalCompare<T>(IEnumerable<T> sequence1, IEnumerable<T> sequence2, Comparison<T> comparison)
        { return LexicographicalCompare<T>(sequence1, sequence2, Comparers.ComparerFromComparison(comparison)); }
        public static int LexicographicalCompare<T>(IEnumerable<T> sequence1, IEnumerable<T> sequence2, IComparer<T> comparer)
        {
            if (sequence1 == null)
                throw new ArgumentNullException("sequence1"); if (sequence2 == null)
                throw new ArgumentNullException("sequence2"); if (comparer == null)
                throw new ArgumentNullException("comparer"); using (IEnumerator<T> enum1 = sequence1.GetEnumerator(), enum2 = sequence2.GetEnumerator())
            {
                bool continue1, continue2; for (;;)
                {
                    continue1 = enum1.MoveNext(); continue2 = enum2.MoveNext(); if (!continue1 || !continue2)
                        break; int compare = comparer.Compare(enum1.Current, enum2.Current); if (compare != 0)
                        return compare;
                }
                if (continue1 == continue2)
                    return 0;
                else if (continue1)
                    return 1;
                else
                    return -1;
            }
        }
        #endregion Sorting and operations on sorted collections

        #region Comparers/Comparison utilities



#if !PCL
        [Serializable]
#endif
        private class LexicographicalComparerClass<T> : IComparer<IEnumerable<T>>
        {
            IComparer<T> itemComparer; public LexicographicalComparerClass(IComparer<T> itemComparer)
            { this.itemComparer = itemComparer; }
            public int Compare(IEnumerable<T> x, IEnumerable<T> y)
            { return LexicographicalCompare<T>(x, y, itemComparer); }
            public override bool Equals(object obj)
            {
                if (obj is LexicographicalComparerClass<T>)
                    return this.itemComparer.Equals(((LexicographicalComparerClass<T>)obj).itemComparer);
                else
                    return false;
            }
            public override int GetHashCode()
            { return itemComparer.GetHashCode(); }
        }
        public static IComparer<IEnumerable<T>> GetLexicographicalComparer<T>()
        where T : IComparable<T>
        { return GetLexicographicalComparer<T>(Comparer<T>.Default); }
        public static IComparer<IEnumerable<T>> GetLexicographicalComparer<T>(IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException("comparer"); return new LexicographicalComparerClass<T>(comparer);
        }
        public static IComparer<IEnumerable<T>> GetLexicographicalComparer<T>(Comparison<T> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException("comparison"); return new LexicographicalComparerClass<T>(Comparers.ComparerFromComparison(comparison));
        }


#if !PCL
        [Serializable]
#endif
        private class ReverseComparerClass<T> : IComparer<T>
        {
            IComparer<T> comparer; public ReverseComparerClass(IComparer<T> comparer)
            { this.comparer = comparer; }
            public int Compare(T x, T y)
            { return -comparer.Compare(x, y); }
            public override bool Equals(object obj)
            {
                if (obj is ReverseComparerClass<T>)
                    return this.comparer.Equals(((ReverseComparerClass<T>)obj).comparer);
                else
                    return false;
            }
            public override int GetHashCode()
            { return comparer.GetHashCode(); }
        }

        public static IComparer<T> GetReverseComparer<T>(IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException("comparer"); return new ReverseComparerClass<T>(comparer);
        }


#if !PCL
        [Serializable]
#endif
        private class IdentityComparer<T> : IEqualityComparer<T> where T : class
        {
            public bool Equals(T x, T y)
            { return ((object)x == (object)y); }
            public int GetHashCode(T obj)
            { return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj); }
            public override bool Equals(object obj)
            { return (obj != null && obj is IdentityComparer<T>); }
            public override int GetHashCode()
            { return 0x7143DDEF; }
        }
        public static IEqualityComparer<T> GetIdentityComparer<T>()
        where T : class
        { return new IdentityComparer<T>(); }
        public static Comparison<T> GetReverseComparison<T>(Comparison<T> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException("comparison"); return delegate (T x, T y) { return -comparison(x, y); };
        }
        public static IComparer<T> GetComparerFromComparison<T>(Comparison<T> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException("comparison"); return Comparers.ComparerFromComparison<T>(comparison);
        }
        public static Comparison<T> GetComparisonFromComparer<T>(IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException("comparer"); return comparer.Compare;
        }


#if !PCL
        [Serializable]
#endif
        private class CollectionEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
        {
            private IEqualityComparer<T> equalityComparer; public CollectionEqualityComparer(IEqualityComparer<T> equalityComparer)
            { this.equalityComparer = equalityComparer; }
            public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
            { return Algorithms.EqualCollections<T>(x, y, equalityComparer); }
            public int GetHashCode(IEnumerable<T> obj)
            {
                int hash = 0x374F293E; foreach (T t in obj)
                { int itemHash = Util.GetHashCode(t, equalityComparer); hash += itemHash; hash = (hash << 9) | (hash >> 23); }
                return hash & 0x7FFFFFFF;
            }
        }
        public static IEqualityComparer<IEnumerable<T>> GetCollectionEqualityComparer<T>()
        { return GetCollectionEqualityComparer(EqualityComparer<T>.Default); }
        public static IEqualityComparer<IEnumerable<T>> GetCollectionEqualityComparer<T>(IEqualityComparer<T> equalityComparer)
        {
            if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); return new CollectionEqualityComparer<T>(equalityComparer);
        }


#if !PCL
        [Serializable]
#endif
        private class SetEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
        {
            private IEqualityComparer<T> equalityComparer; public SetEqualityComparer(IEqualityComparer<T> equalityComparer)
            { this.equalityComparer = equalityComparer; }
            public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
            { return Algorithms.EqualSets<T>(x, y, equalityComparer); }
            public int GetHashCode(IEnumerable<T> obj)
            {
                int hash = 0x624F273C; foreach (T t in obj)
                { int itemHash = Util.GetHashCode(t, equalityComparer); hash += itemHash; }
                return hash & 0x7FFFFFFF;
            }
        }
        public static IEqualityComparer<IEnumerable<T>> GetSetEqualityComparer<T>()
        { return GetSetEqualityComparer(EqualityComparer<T>.Default); }
        public static IEqualityComparer<IEnumerable<T>> GetSetEqualityComparer<T>(IEqualityComparer<T> equalityComparer)
        {
            if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); return new SetEqualityComparer<T>(equalityComparer);
        }
        #endregion Comparers/Comparison utilities

        #region Predicate operations

        public static bool Exists<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (predicate == null)
                throw new ArgumentNullException("predicate"); foreach (T item in collection)
            {
                if (predicate(item))
                    return true;
            }
            return false;
        }
        public static bool TrueForAll<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (predicate == null)
                throw new ArgumentNullException("predicate"); foreach (T item in collection)
            {
                if (!predicate(item))
                    return false;
            }
            return true;
        }
        public static int CountWhere<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (predicate == null)
                throw new ArgumentNullException("predicate"); int count = 0; foreach (T item in collection)
            {
                if (predicate(item))
                    ++count;
            }
            return count;
        }
        public static ICollection<T> RemoveWhere<T>(ICollection<T> collection, Predicate<T> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (predicate == null)
                throw new ArgumentNullException("predicate"); if (collection is T[])
                collection = new ArrayWrapper<T>((T[])collection); if (collection.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "collection"); IList<T> list = collection as IList<T>; if (list != null)
            {
                T item; int i = -1, j = 0; int listCount = list.Count; List<T> removed = new List<T>(); while (j < listCount)
                {
                    item = list[j]; if (predicate(item))
                    { removed.Add(item); }
                    else
                    {
                        ++i; if (i != j)
                            list[i] = item;
                    }
                    ++j;
                }
                ++i; if (i < listCount)
                {
                    if (list is IList && ((IList)list).IsFixedSize)
                    {
                        while (i < listCount)
                            list[i++] = default(T);
                    }
                    else
                    {
                        while (i < listCount)
                        { list.RemoveAt(listCount - 1); --listCount; }
                    }
                }
                return removed;
            }
            else
            {
                List<T> removed = new List<T>(); foreach (T item in collection)
                    if (predicate(item))
                        removed.Add(item); foreach (T item in removed)
                    collection.Remove(item); return removed;
            }
        }
        public static IEnumerable<TDest> Convert<TSource, TDest>(IEnumerable<TSource> sourceCollection, Converter<TSource, TDest> converter)
        {
            if (sourceCollection == null)
                throw new ArgumentNullException("sourceCollection"); if (converter == null)
                throw new ArgumentNullException("converter"); foreach (TSource sourceItem in sourceCollection)
                yield return converter(sourceItem);
        }
        public static Converter<TKey, TValue> GetDictionaryConverter<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        { return GetDictionaryConverter(dictionary, default(TValue)); }
        public static Converter<TKey, TValue> GetDictionaryConverter<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TValue defaultValue)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary"); return delegate (TKey key)
                {
                    TValue value; if (dictionary.TryGetValue(key, out value))
                        return value;
                    else
                        return defaultValue;
                };
        }
        public static void ForEach<T>(IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (action == null)
                throw new ArgumentNullException("action"); foreach (T item in collection)
                action(item);
        }
        public static int Partition<T>(IList<T> list, Predicate<T> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (predicate == null)
                throw new ArgumentNullException("predicate"); if (list is T[])
                list = new ArrayWrapper<T>((T[])list); if (list.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "list"); int i = 0, j = list.Count - 1; for (;;)
            {
                while (i <= j && predicate(list[i]))
                    ++i; while (i <= j && !predicate(list[j]))
                    --j; if (i > j)
                    break;
                else
                { T temp = list[i]; list[i] = list[j]; list[j] = temp; ++i; --j; }
            }
            return i;
        }


        public static int StablePartition<T>(IList<T> list, Predicate<T> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (predicate == null)
                throw new ArgumentNullException("predicate"); if (list is T[])
                list = new ArrayWrapper<T>((T[])list); if (list.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "list"); int listCount = list.Count; if (listCount == 0)
                return 0; T[] temp = new T[listCount]; int i = 0, j = listCount - 1; foreach (T item in list)
            {
                if (predicate(item))
                    temp[i++] = item;
                else
                    temp[j--] = item;
            }
            int index = 0; while (index < i)
            { list[index] = temp[index]; index++; }
            j = listCount - 1; while (index < listCount)
                list[index++] = temp[j--]; return i;
        }

        #endregion Predicate operations

        #region Miscellaneous operations on IEnumerable

        public static IEnumerable<T> Concatenate<T>(params IEnumerable<T>[] collections)
        {
            if (collections == null)
                throw new ArgumentNullException("collections"); foreach (IEnumerable<T> coll in collections)
            {
                foreach (T item in coll)
                    yield return item;
            }
        }
        public static bool EqualCollections<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        { return EqualCollections(collection1, collection2, EqualityComparer<T>.Default); }
        public static bool EqualCollections<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
        {
            if (collection1 == null)
                throw new ArgumentNullException("collection1"); if (collection2 == null)
                throw new ArgumentNullException("collection2"); if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); using (IEnumerator<T> enum1 = collection1.GetEnumerator(), enum2 = collection2.GetEnumerator())
            {
                bool continue1, continue2; for (;;)
                {
                    continue1 = enum1.MoveNext(); continue2 = enum2.MoveNext(); if (!continue1 || !continue2)
                        break; if (!equalityComparer.Equals(enum1.Current, enum2.Current))
                        return false;
                }
                return (continue1 == continue2);
            }
        }
        public static bool EqualCollections<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, BinaryPredicate<T> predicate)
        {
            if (collection1 == null)
                throw new ArgumentNullException("collection1"); if (collection2 == null)
                throw new ArgumentNullException("collection2"); if (predicate == null)
                throw new ArgumentNullException("predicate"); using (IEnumerator<T> enum1 = collection1.GetEnumerator(), enum2 = collection2.GetEnumerator())
            {
                bool continue1, continue2; for (;;)
                {
                    continue1 = enum1.MoveNext(); continue2 = enum2.MoveNext(); if (!continue1 || !continue2)
                        break; if (!predicate(enum1.Current, enum2.Current))
                        return false;
                }
                return (continue1 == continue2);
            }
        }
        public static T[] ToArray<T>(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); ICollection<T> coll = collection as ICollection<T>; if (coll != null)
            { T[] array = new T[coll.Count]; coll.CopyTo(array, 0); return array; }
            else
            { List<T> list = new List<T>(collection); return list.ToArray(); }
        }
        public static int Count<T>(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (collection is ICollection<T>)
                return ((ICollection<T>)collection).Count; int count = 0; foreach (T item in collection)
                ++count; return count;
        }
        public static int CountEqual<T>(IEnumerable<T> collection, T find)
        { return CountEqual(collection, find, EqualityComparer<T>.Default); }
        public static int CountEqual<T>(IEnumerable<T> collection, T find, IEqualityComparer<T> equalityComparer)
        {
            if (collection == null)
                throw new ArgumentException("collection"); if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); int count = 0; foreach (T item in collection)
            {
                if (equalityComparer.Equals(item, find))
                    ++count;
            }
            return count;
        }
        public static IEnumerable<T> NCopiesOf<T>(int n, T item)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n", Strings.ArgMustNotBeNegative); while (n-- > 0)
            { yield return item; }
        }

        #endregion Miscellaneous operations on IEnumerable

        #region Miscellaneous operations on IList

        public static void Fill<T>(IList<T> list, T value)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (list.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "list"); int count = list.Count; for (int i = 0; i < count; ++i)
            { list[i] = value; }
        }
        public static void Fill<T>(T[] array, T value)
        {
            if (array == null)
                throw new ArgumentNullException("array"); for (int i = 0; i < array.Length; ++i)
            { array[i] = value; }
        }
        public static void FillRange<T>(IList<T> list, int start, int count, T value)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (list.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "list"); if (count == 0)
                return; if (start < 0 || start >= list.Count)
                throw new ArgumentOutOfRangeException("start"); if (count < 0 || count > list.Count || start > list.Count - count)
                throw new ArgumentOutOfRangeException("count"); for (int i = start; i < count + start; ++i)
            { list[i] = value; }
        }
        public static void FillRange<T>(T[] array, int start, int count, T value)
        {
            if (array == null)
                throw new ArgumentNullException("array"); if (count == 0)
                return; if (start < 0 || start >= array.Length)
                throw new ArgumentOutOfRangeException("start"); if (count < 0 || count > array.Length || start > array.Length - count)
                throw new ArgumentOutOfRangeException("count"); for (int i = start; i < count + start; ++i)
            { array[i] = value; }
        }
        public static void Copy<T>(IEnumerable<T> source, IList<T> dest, int destIndex)
        { Copy<T>(source, dest, destIndex, int.MaxValue); }
        public static void Copy<T>(IEnumerable<T> source, T[] dest, int destIndex)
        {
            if (source == null)
                throw new ArgumentNullException("source"); if (dest == null)
                throw new ArgumentNullException("dest"); if (destIndex < 0 || destIndex > dest.Length)
                throw new ArgumentOutOfRangeException("destIndex"); using (IEnumerator<T> sourceEnum = source.GetEnumerator())
            {
                while (sourceEnum.MoveNext())
                {
                    if (destIndex >= dest.Length)
                        throw new ArgumentException(Strings.ArrayTooSmall, "array"); dest[destIndex++] = sourceEnum.Current;
                }
            }
        }
        public static void Copy<T>(IEnumerable<T> source, IList<T> dest, int destIndex, int count)
        {
            if (source == null)
                throw new ArgumentNullException("source"); if (dest == null)
                throw new ArgumentNullException("dest"); if (dest.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "dest"); int destCount = dest.Count; if (destIndex < 0 || destIndex > destCount)
                throw new ArgumentOutOfRangeException("destIndex"); if (count < 0)
                throw new ArgumentOutOfRangeException("count"); using (IEnumerator<T> sourceEnum = source.GetEnumerator())
            {
                while (destIndex < destCount && count > 0 && sourceEnum.MoveNext())
                { dest[destIndex++] = sourceEnum.Current; --count; }
                while (count > 0 && sourceEnum.MoveNext())
                { dest.Insert(destCount++, sourceEnum.Current); --count; }
            }
        }
        public static void Copy<T>(IEnumerable<T> source, T[] dest, int destIndex, int count)
        {
            if (source == null)
                throw new ArgumentNullException("source"); if (dest == null)
                throw new ArgumentNullException("dest"); int destCount = dest.Length; if (destIndex < 0 || destIndex > destCount)
                throw new ArgumentOutOfRangeException("destIndex"); if (count < 0 || destIndex + count > destCount)
                throw new ArgumentOutOfRangeException("count"); using (IEnumerator<T> sourceEnum = source.GetEnumerator())
            {
                while (destIndex < destCount && count > 0 && sourceEnum.MoveNext())
                { dest[destIndex++] = sourceEnum.Current; --count; }
            }
        }
        public static void Copy<T>(IList<T> source, int sourceIndex, IList<T> dest, int destIndex, int count)
        {
            if (source == null)
                throw new ArgumentNullException("source"); if (dest == null)
                throw new ArgumentNullException("dest"); if (dest.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "dest"); int sourceCount = source.Count; int destCount = dest.Count; if (sourceIndex < 0 || sourceIndex >= sourceCount)
                throw new ArgumentOutOfRangeException("sourceIndex"); if (destIndex < 0 || destIndex > destCount)
                throw new ArgumentOutOfRangeException("destIndex"); if (count < 0)
                throw new ArgumentOutOfRangeException("count"); if (count > sourceCount - sourceIndex)
                count = sourceCount - sourceIndex; if (source == dest && sourceIndex > destIndex)
            {
                while (count > 0)
                { dest[destIndex++] = source[sourceIndex++]; --count; }
            }
            else
            {
                int si, di; if (destIndex + count > destCount)
                {
                    int numberToInsert = destIndex + count - destCount; si = sourceIndex + (count - numberToInsert); di = destCount; count -= numberToInsert; while (numberToInsert > 0)
                    { dest.Insert(di++, source[si++]); --numberToInsert; }
                }
                si = sourceIndex + count - 1; di = destIndex + count - 1; while (count > 0)
                { dest[di--] = source[si--]; --count; }
            }
        }
        public static void Copy<T>(IList<T> source, int sourceIndex, T[] dest, int destIndex, int count)
        {
            if (source == null)
                throw new ArgumentNullException("source"); if (dest == null)
                throw new ArgumentNullException("dest"); int sourceCount = source.Count; int destCount = dest.Length; if (sourceIndex < 0 || sourceIndex >= sourceCount)
                throw new ArgumentOutOfRangeException("sourceIndex"); if (destIndex < 0 || destIndex > destCount)
                throw new ArgumentOutOfRangeException("destIndex"); if (count < 0 || destIndex + count > destCount)
                throw new ArgumentOutOfRangeException("count"); if (count > sourceCount - sourceIndex)
                count = sourceCount - sourceIndex; if (source is T[])
            { Array.Copy((T[])source, sourceIndex, dest, destIndex, count); }
            else
            {
                int si = sourceIndex; int di = destIndex; while (count > 0)
                { dest[di++] = source[si++]; --count; }
            }
        }

        public static IEnumerable<T> Reverse<T>(IList<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            for (int i = source.Count - 1; i >= 0; --i)
                yield return source[i];
        }

        public static void ReverseInPlace<T>(IList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (list is T[])
                list = new ArrayWrapper<T>((T[])list); if (list.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "list"); int i, j; i = 0; j = list.Count - 1; while (i < j)
            { T temp = list[i]; list[i] = list[j]; list[j] = temp; i++; j--; }
        }
        public static IEnumerable<T> Rotate<T>(IList<T> source, int amountToRotate)
        {
            if (source == null)
                throw new ArgumentNullException("source"); int count = source.Count; if (count != 0)
            {
                amountToRotate = amountToRotate % count; if (amountToRotate < 0)
                    amountToRotate += count; for (int i = amountToRotate; i < count; ++i)
                    yield return source[i]; for (int i = 0; i < amountToRotate; ++i)
                    yield return source[i];
            }
        }
        public static void RotateInPlace<T>(IList<T> list, int amountToRotate)
        {
            if (list == null)
                throw new ArgumentNullException("list"); if (list is T[])
                list = new ArrayWrapper<T>((T[])list); if (list.IsReadOnly)
                throw new ArgumentException(Strings.ListIsReadOnly, "list"); int count = list.Count; if (count != 0)
            {
                amountToRotate = amountToRotate % count; if (amountToRotate < 0)
                    amountToRotate += count; int itemsLeft = count; int indexStart = 0; while (itemsLeft > 0)
                {
                    int index = indexStart; T itemStart = list[indexStart]; for (;;)
                    {
                        --itemsLeft; int nextIndex = index + amountToRotate; if (nextIndex >= count)
                            nextIndex -= count; if (nextIndex == indexStart)
                        { list[index] = itemStart; break; }
                        else
                        { list[index] = list[nextIndex]; index = nextIndex; }
                    }
                    ++indexStart;
                }
            }
        }

        #endregion Miscellaneous operations on IList
    }




    internal static class Util
    {

        public static bool IsCloneableType(Type type, out bool isValue)
        {
            isValue = false;
#if PCL

            return false;
#else
            if (typeof(ICloneable).IsAssignableFrom(type))
            { return true; }
            else if (type.IsValueType)
            { isValue = true; return true; }
            else
                return false;
#endif

        }

        public static string SimpleClassName(Type type)
        {
            string name = type.Name;



            int index = name.IndexOfAny(new char[] { '<', '{', '`' });
            if (index >= 0)
                name = name.Substring(0, index);

            return name;
        }


#if !PCL
        [Serializable]
#endif
        class WrapEnumerable<T> : IEnumerable<T>
        {
            IEnumerable<T> wrapped; public WrapEnumerable(IEnumerable<T> wrapped)
            { this.wrapped = wrapped; }
            public IEnumerator<T> GetEnumerator()
            { return wrapped.GetEnumerator(); }
            IEnumerator IEnumerable.GetEnumerator()
            { return ((IEnumerable)wrapped).GetEnumerator(); }
        }
        public static IEnumerable<T> CreateEnumerableWrapper<T>(IEnumerable<T> wrapped)
        { return new WrapEnumerable<T>(wrapped); }
        public static int GetHashCode<T>(T item, IEqualityComparer<T> equalityComparer)
        {
            if (item == null)
                return 0x1786E23C;
            else
                return equalityComparer.GetHashCode(item);
        }
        private static readonly int[] MultiplyDeBruijnBitPosition = { 0, 9, 1, 10, 13, 21, 2, 29, 11, 14, 16, 18, 22, 25, 3, 30, 8, 12, 20, 28, 15, 17, 24, 7, 19, 27, 23, 6, 26, 5, 4, 31 }; public static int LogBase2(uint v)
        { v |= v >> 1; v |= v >> 2; v |= v >> 4; v |= v >> 8; v |= v >> 16; return MultiplyDeBruijnBitPosition[unchecked((uint)(v * 0x07C4ACDDUL)) >> 27]; }
    }




    internal static class Comparers
    {

#if !PCL
        [Serializable]
#endif

        class KeyValueEqualityComparer<TKey, TValue> : IEqualityComparer<KeyValuePair<TKey, TValue>>
        {
            private IEqualityComparer<TKey> keyEqualityComparer; public KeyValueEqualityComparer(IEqualityComparer<TKey> keyEqualityComparer)
            { this.keyEqualityComparer = keyEqualityComparer; }
            public bool Equals(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
            { return keyEqualityComparer.Equals(x.Key, y.Key); }
            public int GetHashCode(KeyValuePair<TKey, TValue> obj)
            { return Util.GetHashCode(obj.Key, keyEqualityComparer); }
            public override bool Equals(object obj)
            {
                if (obj is KeyValueEqualityComparer<TKey, TValue>)
                    return object.Equals(keyEqualityComparer, ((KeyValueEqualityComparer<TKey, TValue>)obj).keyEqualityComparer);
                else
                    return false;
            }
            public override int GetHashCode()
            { return keyEqualityComparer.GetHashCode(); }
        }


#if !PCL
        [Serializable]
#endif
        class KeyValueComparer<TKey, TValue> : IComparer<KeyValuePair<TKey, TValue>>
        {
            private IComparer<TKey> keyComparer; public KeyValueComparer(IComparer<TKey> keyComparer)
            { this.keyComparer = keyComparer; }
            public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
            { return keyComparer.Compare(x.Key, y.Key); }
            public override bool Equals(object obj)
            {
                if (obj is KeyValueComparer<TKey, TValue>)
                    return object.Equals(keyComparer, ((KeyValueComparer<TKey, TValue>)obj).keyComparer);
                else
                    return false;
            }
            public override int GetHashCode()
            { return keyComparer.GetHashCode(); }
        }


#if !PCL
        [Serializable]
#endif
        class PairComparer<TKey, TValue> : IComparer<KeyValuePair<TKey, TValue>>
        {
            private IComparer<TKey> keyComparer; private IComparer<TValue> valueComparer; public PairComparer(IComparer<TKey> keyComparer, IComparer<TValue> valueComparer)
            { this.keyComparer = keyComparer; this.valueComparer = valueComparer; }
            public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
            {
                int keyCompare = keyComparer.Compare(x.Key, y.Key); if (keyCompare == 0)
                    return valueComparer.Compare(x.Value, y.Value);
                else
                    return keyCompare;
            }
            public override bool Equals(object obj)
            {
                if (obj is PairComparer<TKey, TValue>)
                    return object.Equals(keyComparer, ((PairComparer<TKey, TValue>)obj).keyComparer) && object.Equals(valueComparer, ((PairComparer<TKey, TValue>)obj).valueComparer);
                else
                    return false;
            }
            public override int GetHashCode()
            { return keyComparer.GetHashCode() ^ valueComparer.GetHashCode(); }
        }

#if !PCL
        [Serializable]
#endif
        class ComparisonComparer<T> : IComparer<T>
        {
            private Comparison<T> comparison; public ComparisonComparer(Comparison<T> comparison)
            { this.comparison = comparison; }
            public int Compare(T x, T y)
            { return comparison(x, y); }
            public override bool Equals(object obj)
            {
                if (obj is ComparisonComparer<T>)
                    return comparison.Equals(((ComparisonComparer<T>)obj).comparison);
                else
                    return false;
            }
            public override int GetHashCode()
            { return comparison.GetHashCode(); }
        }


#if !PCL
        [Serializable]
#endif
        class ComparisonKeyValueComparer<TKey, TValue> : IComparer<KeyValuePair<TKey, TValue>>
        {
            private Comparison<TKey> comparison; public ComparisonKeyValueComparer(Comparison<TKey> comparison)
            { this.comparison = comparison; }
            public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
            { return comparison(x.Key, y.Key); }
            public override bool Equals(object obj)
            {
                if (obj is ComparisonKeyValueComparer<TKey, TValue>)
                    return comparison.Equals(((ComparisonKeyValueComparer<TKey, TValue>)obj).comparison);
                else
                    return false;
            }
            public override int GetHashCode()
            { return comparison.GetHashCode(); }
        }
        public static IComparer<T> ComparerFromComparison<T>(Comparison<T> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException("comparison"); return new ComparisonComparer<T>(comparison);
        }
        public static IComparer<KeyValuePair<TKey, TValue>> ComparerKeyValueFromComparerKey<TKey, TValue>(IComparer<TKey> keyComparer)
        {
            if (keyComparer == null)
                throw new ArgumentNullException("keyComparer"); return new KeyValueComparer<TKey, TValue>(keyComparer);
        }
        public static IEqualityComparer<KeyValuePair<TKey, TValue>> EqualityComparerKeyValueFromComparerKey<TKey, TValue>(IEqualityComparer<TKey> keyEqualityComparer)
        {
            if (keyEqualityComparer == null)
                throw new ArgumentNullException("keyEqualityComparer"); return new KeyValueEqualityComparer<TKey, TValue>(keyEqualityComparer);
        }
        public static IComparer<KeyValuePair<TKey, TValue>> ComparerPairFromKeyValueComparers<TKey, TValue>(IComparer<TKey> keyComparer, IComparer<TValue> valueComparer)
        {
            if (keyComparer == null)
                throw new ArgumentNullException("keyComparer"); if (valueComparer == null)
                throw new ArgumentNullException("valueComparer"); return new PairComparer<TKey, TValue>(keyComparer, valueComparer);
        }
        public static IComparer<KeyValuePair<TKey, TValue>> ComparerKeyValueFromComparisonKey<TKey, TValue>(Comparison<TKey> keyComparison)
        {
            if (keyComparison == null)
                throw new ArgumentNullException("keyComparison"); return new ComparisonKeyValueComparer<TKey, TValue>(keyComparison);
        }
        public static IComparer<T> DefaultComparer<T>()
        {
            if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)) || typeof(System.IComparable).IsAssignableFrom(typeof(T)))
            { return Comparer<T>.Default; }
            else
            { throw new InvalidOperationException(string.Format(Strings.UncomparableType, typeof(T).FullName)); }
        }
        public static IComparer<KeyValuePair<TKey, TValue>> DefaultKeyValueComparer<TKey, TValue>()
        { IComparer<TKey> keyComparer = DefaultComparer<TKey>(); return ComparerKeyValueFromComparerKey<TKey, TValue>(keyComparer); }
    }







#if !PCL
    [Serializable]
#endif
    public class Set<T> : CollectionBase<T>, ICollection<T>
#if !PCL
        , ICloneable
#endif
    {
        private IEqualityComparer<T> equalityComparer;


        private Hash<T> hash;

        #region Constructors

        public Set() : this(EqualityComparer<T>.Default)
        { }
        public Set(IEqualityComparer<T> equalityComparer)
        {
            if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); this.equalityComparer = equalityComparer; hash = new Hash<T>(equalityComparer);
        }
        public Set(IEnumerable<T> collection) : this(collection, EqualityComparer<T>.Default)
        { }
        public Set(IEnumerable<T> collection, IEqualityComparer<T> equalityComparer) : this(equalityComparer)
        { AddMany(collection); }
        private Set(IEqualityComparer<T> equalityComparer, Hash<T> hash)
        { this.equalityComparer = equalityComparer; this.hash = hash; }
        #endregion Constructors

        #region Cloning
        public Set<T> Clone()
        { Set<T> newSet = new Set<T>(equalityComparer, hash.Clone(null)); return newSet; }

#if !PCL
        object ICloneable.Clone()
        { return this.Clone(); }
        public Set<T> CloneContents()
        {
            bool itemIsValueType; if (!Util.IsCloneableType(typeof(T), out itemIsValueType))
                throw new InvalidOperationException(string.Format(Strings.TypeNotCloneable, typeof(T).FullName)); Set<T> clone = new Set<T>(equalityComparer); foreach (T item in this)
            {
                T itemClone; if (itemIsValueType)
                    itemClone = item;
                else
                {
                    if (item == null)
                        itemClone = default(T);
                    else
                        itemClone = (T)(((ICloneable)item).Clone());
                }
                clone.Add(itemClone);
            }
            return clone;
        }

#endif

        #endregion Cloning

        #region Basic collection containment
        public IEqualityComparer<T> Comparer
        {
            get
            { return this.equalityComparer; }
        }
        public sealed override int Count
        {
            get
            { return hash.ElementCount; }
        }
        public sealed override IEnumerator<T> GetEnumerator()
        { return hash.GetEnumerator(); }
        public sealed override bool Contains(T item)
        { T dummy; return hash.Find(item, false, out dummy); }
        public bool TryGetItem(T item, out T foundItem)
        { return hash.Find(item, false, out foundItem); }

        #endregion

        #region Adding elements
        public new bool Add(T item)
        { T dummy; return !hash.Insert(item, true, out dummy); }
        void ICollection<T>.Add(T item)
        { Add(item); }
        public void AddMany(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (object.ReferenceEquals(collection, this))
                return; foreach (T item in collection)
                Add(item);
        }

        #endregion Adding elements

        #region Removing elements

        public sealed override bool Remove(T item)
        { T dummy; return hash.Delete(item, out dummy); }
        public int RemoveMany(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); int count = 0; if (collection == this)
            { count = Count; Clear(); }
            else
            {
                foreach (T item in collection)
                {
                    if (Remove(item))
                        ++count;
                }
            }
            return count;
        }
        public sealed override void Clear()
        { hash.StopEnumerations(); hash = new Hash<T>(equalityComparer); }
        #endregion Removing elements

        #region Set operations
        private void CheckConsistentComparison(Set<T> otherSet)
        {
            if (otherSet == null)
                throw new ArgumentNullException("otherSet"); if (!object.Equals(equalityComparer, otherSet.equalityComparer))
                throw new InvalidOperationException(Strings.InconsistentComparisons);
        }
        public bool IsSupersetOf(Set<T> otherSet)
        {
            CheckConsistentComparison(otherSet); if (otherSet.Count > this.Count)
                return false; foreach (T item in otherSet)
            {
                if (!this.Contains(item))
                    return false;
            }
            return true;
        }
        public bool IsProperSupersetOf(Set<T> otherSet)
        {
            CheckConsistentComparison(otherSet); if (otherSet.Count >= this.Count)
                return false; return IsSupersetOf(otherSet);
        }
        public bool IsSubsetOf(Set<T> otherSet)
        { return otherSet.IsSupersetOf(this); }
        public bool IsProperSubsetOf(Set<T> otherSet)
        { return otherSet.IsProperSupersetOf(this); }
        public bool IsEqualTo(Set<T> otherSet)
        {
            CheckConsistentComparison(otherSet); if (otherSet.Count != this.Count)
                return false; foreach (T item in otherSet)
            {
                if (!this.Contains(item))
                    return false;
            }
            return true;
        }
        public bool IsDisjointFrom(Set<T> otherSet)
        {
            CheckConsistentComparison(otherSet); Set<T> smaller, larger; if (otherSet.Count > this.Count)
            { smaller = this; larger = otherSet; }
            else
            { smaller = otherSet; larger = this; }
            foreach (T item in smaller)
            {
                if (larger.Contains(item))
                    return false;
            }
            return true;
        }
        public void UnionWith(Set<T> otherSet)
        { CheckConsistentComparison(otherSet); AddMany(otherSet); }
        public Set<T> Union(Set<T> otherSet)
        {
            CheckConsistentComparison(otherSet); Set<T> smaller, larger, result; if (otherSet.Count > this.Count)
            { smaller = this; larger = otherSet; }
            else
            { smaller = otherSet; larger = this; }
            result = larger.Clone(); result.AddMany(smaller); return result;
        }
        public void IntersectionWith(Set<T> otherSet)
        {
            CheckConsistentComparison(otherSet); hash.StopEnumerations(); Set<T> smaller, larger; if (otherSet.Count > this.Count)
            { smaller = this; larger = otherSet; }
            else
            { smaller = otherSet; larger = this; }
            T dummy; Hash<T> newHash = new Hash<T>(equalityComparer); foreach (T item in smaller)
            {
                if (larger.Contains(item))
                    newHash.Insert(item, true, out dummy);
            }
            hash = newHash;
        }
        public Set<T> Intersection(Set<T> otherSet)
        {
            CheckConsistentComparison(otherSet); Set<T> smaller, larger, result; if (otherSet.Count > this.Count)
            { smaller = this; larger = otherSet; }
            else
            { smaller = otherSet; larger = this; }
            result = new Set<T>(equalityComparer); foreach (T item in smaller)
            {
                if (larger.Contains(item))
                    result.Add(item);
            }
            return result;
        }
        public void DifferenceWith(Set<T> otherSet)
        {
            if (this == otherSet)
                Clear(); CheckConsistentComparison(otherSet); if (otherSet.Count < this.Count)
            {
                foreach (T item in otherSet)
                { this.Remove(item); }
            }
            else
            { RemoveAll(delegate (T item) { return otherSet.Contains(item); }); }
        }
        public Set<T> Difference(Set<T> otherSet)
        { CheckConsistentComparison(otherSet); Set<T> result = this.Clone(); result.DifferenceWith(otherSet); return result; }
        public void SymmetricDifferenceWith(Set<T> otherSet)
        {
            if (this == otherSet)
                Clear(); CheckConsistentComparison(otherSet); if (otherSet.Count > this.Count)
            {
                hash.StopEnumerations(); Hash<T> newHash = otherSet.hash.Clone(null); T dummy; foreach (T item in this)
                {
                    if (newHash.Find(item, false, out dummy))
                        newHash.Delete(item, out dummy);
                    else
                        newHash.Insert(item, true, out dummy);
                }
                this.hash = newHash;
            }
            else
            {
                foreach (T item in otherSet)
                {
                    if (this.Contains(item))
                        this.Remove(item);
                    else
                        this.Add(item);
                }
            }
        }
        public Set<T> SymmetricDifference(Set<T> otherSet)
        {
            CheckConsistentComparison(otherSet); Set<T> smaller, larger, result; if (otherSet.Count > this.Count)
            { smaller = this; larger = otherSet; }
            else
            { smaller = otherSet; larger = this; }
            result = larger.Clone(); foreach (T item in smaller)
            {
                if (result.Contains(item))
                    result.Remove(item);
                else
                    result.Add(item);
            }
            return result;
        }

        #endregion Set operations

    }




#if !PCL
    [Serializable]
#endif
    public struct Pair<TFirst, TSecond> : IComparable, IComparable<Pair<TFirst, TSecond>>
    {
        private static IComparer<TFirst> firstComparer = Comparer<TFirst>.Default; private static IComparer<TSecond> secondComparer = Comparer<TSecond>.Default; private static IEqualityComparer<TFirst> firstEqualityComparer = EqualityComparer<TFirst>.Default; private static IEqualityComparer<TSecond> secondEqualityComparer = EqualityComparer<TSecond>.Default; public TFirst First; public TSecond Second; public Pair(TFirst first, TSecond second)
        { this.First = first; this.Second = second; }
        public Pair(KeyValuePair<TFirst, TSecond> keyAndValue)
        { this.First = keyAndValue.Key; this.Second = keyAndValue.Value; }
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Pair<TFirst, TSecond>)
            { Pair<TFirst, TSecond> other = (Pair<TFirst, TSecond>)obj; return Equals(other); }
            else
            { return false; }
        }
        public bool Equals(Pair<TFirst, TSecond> other)
        { return firstEqualityComparer.Equals(First, other.First) && secondEqualityComparer.Equals(Second, other.Second); }
        public override int GetHashCode()
        { int hashFirst = (First == null) ? 0x61E04917 : First.GetHashCode(); int hashSecond = (Second == null) ? 0x198ED6A3 : Second.GetHashCode(); return hashFirst ^ hashSecond; }
        public int CompareTo(Pair<TFirst, TSecond> other)
        {
            try
            {
                int firstCompare = firstComparer.Compare(First, other.First); if (firstCompare != 0)
                    return firstCompare;
                else
                    return secondComparer.Compare(Second, other.Second);
            }
            catch (ArgumentException)
            {
                if (!typeof(IComparable<TFirst>).IsAssignableFrom(typeof(TFirst)) && !typeof(System.IComparable).IsAssignableFrom(typeof(TFirst)))
                { throw new NotSupportedException(string.Format(Strings.UncomparableType, typeof(TFirst).FullName)); }
                else if (!typeof(IComparable<TSecond>).IsAssignableFrom(typeof(TSecond)) && !typeof(System.IComparable).IsAssignableFrom(typeof(TSecond)))
                { throw new NotSupportedException(string.Format(Strings.UncomparableType, typeof(TSecond).FullName)); }
                else
                    throw;
            }
        }
        int IComparable.CompareTo(object obj)
        {
            if (obj is Pair<TFirst, TSecond>)
                return CompareTo((Pair<TFirst, TSecond>)obj);
            else
                throw new ArgumentException(Strings.BadComparandType, "obj");
        }
        public override string ToString()
        { return string.Format("First: {0}, Second: {1}", (First == null) ? "null" : First.ToString(), (Second == null) ? "null" : Second.ToString()); }
        public static bool operator ==(Pair<TFirst, TSecond> pair1, Pair<TFirst, TSecond> pair2)
        { return firstEqualityComparer.Equals(pair1.First, pair2.First) && secondEqualityComparer.Equals(pair1.Second, pair2.Second); }
        public static bool operator !=(Pair<TFirst, TSecond> pair1, Pair<TFirst, TSecond> pair2)
        { return !(pair1 == pair2); }
        public static explicit operator KeyValuePair<TFirst, TSecond>(Pair<TFirst, TSecond> pair)
        { return new KeyValuePair<TFirst, TSecond>(pair.First, pair.Second); }
        public KeyValuePair<TFirst, TSecond> ToKeyValuePair()
        { return new KeyValuePair<TFirst, TSecond>(this.First, this.Second); }
        public static explicit operator Pair<TFirst, TSecond>(KeyValuePair<TFirst, TSecond> keyAndValue)
        { return new Pair<TFirst, TSecond>(keyAndValue); }
    }


#if !PCL
    [Serializable]
#endif
    public class Bag<T> : CollectionBase<T>
#if !PCL
        , ICloneable
#endif
    {
        private IEqualityComparer<KeyValuePair<T, int>> equalityComparer; private IEqualityComparer<T> keyEqualityComparer; private Hash<KeyValuePair<T, int>> hash; private int count; private static KeyValuePair<T, int> NewPair(T item, int count)
        { KeyValuePair<T, int> pair = new KeyValuePair<T, int>(item, count); return pair; }
        private static KeyValuePair<T, int> NewPair(T item)
        { KeyValuePair<T, int> pair = new KeyValuePair<T, int>(item, 0); return pair; }
        #region Constructors
        public Bag() : this(EqualityComparer<T>.Default)
        { }
        public Bag(IEqualityComparer<T> equalityComparer)
        {
            if (equalityComparer == null)
                throw new ArgumentNullException("equalityComparer"); this.keyEqualityComparer = equalityComparer; this.equalityComparer = Comparers.EqualityComparerKeyValueFromComparerKey<T, int>(equalityComparer); this.hash = new Hash<KeyValuePair<T, int>>(this.equalityComparer);
        }
        public Bag(IEnumerable<T> collection) : this(collection, EqualityComparer<T>.Default)
        { }
        public Bag(IEnumerable<T> collection, IEqualityComparer<T> equalityComparer) : this(equalityComparer)
        { AddMany(collection); }
        private Bag(IEqualityComparer<KeyValuePair<T, int>> equalityComparer, IEqualityComparer<T> keyEqualityComparer, Hash<KeyValuePair<T, int>> hash, int count)
        { this.equalityComparer = equalityComparer; this.keyEqualityComparer = keyEqualityComparer; this.hash = hash; this.count = count; }

        #endregion Constructors

        #region Cloning

        public Bag<T> Clone()
        {
            Bag<T> newBag = new Bag<T>(equalityComparer, keyEqualityComparer, hash.Clone(null), count);
            return newBag;
        }

#if !PCL
        object ICloneable.Clone()
        { return this.Clone(); }
        public Bag<T> CloneContents()
        {
            bool itemIsValueType; if (!Util.IsCloneableType(typeof(T), out itemIsValueType))
                throw new InvalidOperationException(string.Format(Strings.TypeNotCloneable, typeof(T).FullName)); Hash<KeyValuePair<T, int>> newHash = new Hash<KeyValuePair<T, int>>(equalityComparer); foreach (KeyValuePair<T, int> pair in hash)
            {
                KeyValuePair<T, int> newPair, dummy; T newKey; if (!itemIsValueType && pair.Key != null)
                    newKey = (T)(((ICloneable)pair.Key).Clone());
                else
                    newKey = pair.Key; newPair = NewPair(newKey, pair.Value); newHash.Insert(newPair, true, out dummy);
            }
            return new Bag<T>(equalityComparer, keyEqualityComparer, newHash, count);
        }

#endif

        #endregion Cloning

        #region Basic collection containment

        public IEqualityComparer<T> Comparer
        {
            get
            { return keyEqualityComparer; }
        }
        public sealed override int Count
        {
            get
            { return count; }
        }
        public int NumberOfCopies(T item)
        {
            KeyValuePair<T, int> foundPair; if (hash.Find(NewPair(item), false, out foundPair))
                return foundPair.Value;
            else
                return 0;
        }
        public int GetRepresentativeItem(T item, out T representative)
        {
            KeyValuePair<T, int> foundPair; if (hash.Find(NewPair(item), false, out foundPair))
            { representative = foundPair.Key; return foundPair.Value; }
            else
            { representative = item; return 0; }
        }
        public sealed override IEnumerator<T> GetEnumerator()
        {
            foreach (KeyValuePair<T, int> pair in hash)
            {
                for (int i = 0; i < pair.Value; ++i)
                    yield return pair.Key;
            }
        }
        public sealed override bool Contains(T item)
        { KeyValuePair<T, int> dummy; return hash.Find(NewPair(item), false, out dummy); }
        public IEnumerable<T> DistinctItems()
        {
            foreach (KeyValuePair<T, int> pair in hash)
            { yield return pair.Key; }
        }

        #endregion


        #region Adding elements
        public sealed override void Add(T item)
        {
            KeyValuePair<T, int> pair = NewPair(item, 1); KeyValuePair<T, int> existing, newPair; if (!hash.Insert(pair, false, out existing))
            { newPair = NewPair(existing.Key, existing.Value + 1); hash.Insert(newPair, true, out pair); }
            ++count;
        }
        public void AddRepresentative(T item)
        {
            KeyValuePair<T, int> pair = NewPair(item, 1); KeyValuePair<T, int> existing, newPair; if (!hash.Insert(pair, false, out existing))
            { newPair = NewPair(pair.Key, existing.Value + 1); hash.Insert(newPair, true, out pair); }
            ++count;
        }
        public void ChangeNumberOfCopies(T item, int numCopies)
        {
            if (numCopies == 0)
                RemoveAllCopies(item);
            else
            {
                KeyValuePair<T, int> dummy, existing, newPair; if (hash.Find(NewPair(item), false, out existing))
                { count += numCopies - existing.Value; newPair = NewPair(existing.Key, numCopies); }
                else
                { count += numCopies; newPair = NewPair(item, numCopies); }
                hash.Insert(newPair, true, out dummy);
            }
        }
        public void AddMany(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); if (this == collection)
                collection = this.ToArray(); foreach (T item in collection)
                Add(item);
        }

        #endregion Adding elements

        #region Removing elements
        public sealed override bool Remove(T item)
        {
            KeyValuePair<T, int> removed, newPair; if (hash.Delete(NewPair(item), out removed))
            {
                if (removed.Value > 1)
                { KeyValuePair<T, int> dummy; newPair = NewPair(removed.Key, removed.Value - 1); hash.Insert(newPair, true, out dummy); }
                --count; return true;
            }
            else
                return false;
        }
        public int RemoveAllCopies(T item)
        {
            KeyValuePair<T, int> removed; if (hash.Delete(NewPair(item), out removed))
            { count -= removed.Value; return removed.Value; }
            else
                return 0;
        }
        public int RemoveMany(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection"); int count = 0; if (collection == this)
            { count = Count; Clear(); }
            else
            {
                foreach (T item in collection)
                {
                    if (Remove(item))
                        ++count;
                }
            }
            return count;
        }
        public sealed override void Clear()
        { hash.StopEnumerations(); hash = new Hash<KeyValuePair<T, int>>(equalityComparer); count = 0; }

        #endregion Removing elements

        #region Set operations
        private void CheckConsistentComparison(Bag<T> otherBag)
        {
            if (otherBag == null)
                throw new ArgumentNullException("otherBag"); if (!object.Equals(equalityComparer, otherBag.equalityComparer))
                throw new InvalidOperationException(Strings.InconsistentComparisons);
        }
        public bool IsEqualTo(Bag<T> otherBag)
        {
            CheckConsistentComparison(otherBag); if (otherBag.Count != this.Count)
                return false; foreach (T item in otherBag.DistinctItems())
            {
                if (this.NumberOfCopies(item) != otherBag.NumberOfCopies(item))
                    return false;
            }
            return true;
        }
        public bool IsSupersetOf(Bag<T> otherBag)
        {
            CheckConsistentComparison(otherBag); if (otherBag.Count > this.Count)
                return false; foreach (T item in otherBag.DistinctItems())
            {
                if (this.NumberOfCopies(item) < otherBag.NumberOfCopies(item))
                    return false;
            }
            return true;
        }
        public bool IsProperSupersetOf(Bag<T> otherBag)
        {
            CheckConsistentComparison(otherBag); if (otherBag.Count >= this.Count)
                return false; return IsSupersetOf(otherBag);
        }
        public bool IsSubsetOf(Bag<T> otherBag)
        { return otherBag.IsSupersetOf(this); }
        public bool IsProperSubsetOf(Bag<T> otherBag)
        { return otherBag.IsProperSupersetOf(this); }
        public bool IsDisjointFrom(Bag<T> otherBag)
        {
            CheckConsistentComparison(otherBag); Bag<T> smaller, larger; if (otherBag.Count > this.Count)
            { smaller = this; larger = otherBag; }
            else
            { smaller = otherBag; larger = this; }
            foreach (T item in smaller.DistinctItems())
            {
                if (larger.Contains(item))
                    return false;
            }
            return true;
        }
        public void UnionWith(Bag<T> otherBag)
        {
            CheckConsistentComparison(otherBag); if (otherBag == this)
                return; int copiesInThis, copiesInOther; foreach (T item in otherBag.DistinctItems())
            {
                copiesInThis = this.NumberOfCopies(item); copiesInOther = otherBag.NumberOfCopies(item); if (copiesInOther > copiesInThis)
                    ChangeNumberOfCopies(item, copiesInOther);
            }
        }
        public Bag<T> Union(Bag<T> otherBag)
        {
            CheckConsistentComparison(otherBag); Bag<T> smaller, larger, result; if (otherBag.Count > this.Count)
            { smaller = this; larger = otherBag; }
            else
            { smaller = otherBag; larger = this; }
            result = larger.Clone(); result.UnionWith(smaller); return result;
        }
        public void SumWith(Bag<T> otherBag)
        {
            CheckConsistentComparison(otherBag); if (this == otherBag)
            { AddMany(otherBag); return; }
            int copiesInThis, copiesInOther; foreach (T item in otherBag.DistinctItems())
            { copiesInThis = this.NumberOfCopies(item); copiesInOther = otherBag.NumberOfCopies(item); ChangeNumberOfCopies(item, copiesInThis + copiesInOther); }
        }
        public Bag<T> Sum(Bag<T> otherBag)
        {
            CheckConsistentComparison(otherBag); Bag<T> smaller, larger, result; if (otherBag.Count > this.Count)
            { smaller = this; larger = otherBag; }
            else
            { smaller = otherBag; larger = this; }
            result = larger.Clone(); result.SumWith(smaller); return result;
        }
        public void IntersectionWith(Bag<T> otherBag)
        {
            CheckConsistentComparison(otherBag); hash.StopEnumerations(); Bag<T> smaller, larger; if (otherBag.Count > this.Count)
            { smaller = this; larger = otherBag; }
            else
            { smaller = otherBag; larger = this; }
            KeyValuePair<T, int> dummy; Hash<KeyValuePair<T, int>> newHash = new Hash<KeyValuePair<T, int>>(equalityComparer); int newCount = 0; int copiesInSmaller, copiesInLarger, copies; foreach (T item in smaller.DistinctItems())
            {
                copiesInLarger = larger.NumberOfCopies(item); copiesInSmaller = smaller.NumberOfCopies(item); copies = Math.Min(copiesInLarger, copiesInSmaller); if (copies > 0)
                { newHash.Insert(NewPair(item, copies), true, out dummy); newCount += copies; }
            }
            hash = newHash; count = newCount;
        }
        public Bag<T> Intersection(Bag<T> otherBag)
        {
            CheckConsistentComparison(otherBag); Bag<T> smaller, larger, result; if (otherBag.Count > this.Count)
            { smaller = this; larger = otherBag; }
            else
            { smaller = otherBag; larger = this; }
            int copiesInSmaller, copiesInLarger, copies; result = new Bag<T>(keyEqualityComparer); foreach (T item in smaller.DistinctItems())
            {
                copiesInLarger = larger.NumberOfCopies(item); copiesInSmaller = smaller.NumberOfCopies(item); copies = Math.Min(copiesInLarger, copiesInSmaller); if (copies > 0)
                    result.ChangeNumberOfCopies(item, copies);
            }
            return result;
        }
        public void DifferenceWith(Bag<T> otherBag)
        {
            CheckConsistentComparison(otherBag); if (this == otherBag)
            { Clear(); return; }
            int copiesInThis, copiesInOther, copies; foreach (T item in otherBag.DistinctItems())
            {
                copiesInThis = this.NumberOfCopies(item); copiesInOther = otherBag.NumberOfCopies(item); copies = copiesInThis - copiesInOther; if (copies < 0)
                    copies = 0; ChangeNumberOfCopies(item, copies);
            }
        }
        public Bag<T> Difference(Bag<T> otherBag)
        { Bag<T> result; CheckConsistentComparison(otherBag); result = this.Clone(); result.DifferenceWith(otherBag); return result; }
        public void SymmetricDifferenceWith(Bag<T> otherBag)
        {
            CheckConsistentComparison(otherBag); if (this == otherBag)
            { Clear(); return; }
            int copiesInThis, copiesInOther, copies; foreach (T item in otherBag.DistinctItems())
            {
                copiesInThis = this.NumberOfCopies(item); copiesInOther = otherBag.NumberOfCopies(item); copies = Math.Abs(copiesInThis - copiesInOther); if (copies != copiesInThis)
                    ChangeNumberOfCopies(item, copies);
            }
        }
        public Bag<T> SymmetricDifference(Bag<T> otherBag)
        {
            CheckConsistentComparison(otherBag); Bag<T> smaller, larger, result; if (otherBag.Count > this.Count)
            { smaller = this; larger = otherBag; }
            else
            { smaller = otherBag; larger = this; }
            result = larger.Clone(); result.SymmetricDifferenceWith(smaller); return result;
        }
        #endregion Set operations
    }






#if !PCL
    [Serializable]
#endif

    internal class Hash<T> : IEnumerable<T>
#if !PCL
    , ISerializable, IDeserializationCallback
#endif
    {

        private IEqualityComparer<T> equalityComparer; private int count; private int usedSlots; private int totalSlots; private float loadFactor; private int thresholdGrow; private int thresholdShrink; private int hashMask; private int secondaryShift; private Slot[] table; private int changeStamp; private const int MINSIZE = 16;


#if !PCL
        private SerializationInfo serializationInfo;

#endif
        struct Slot
        {
            private uint hash_collision; public T item; public int HashValue
            {
                get
                { return (int)(hash_collision & 0x7FFFFFFF); }
                set
                { Debug.Assert((value & 0x80000000) == 0); hash_collision = (uint)value | (hash_collision & 0x80000000); }
            }
            public bool Empty
            {
                get
                { return HashValue == 0; }
            }
            public void Clear()
            { HashValue = 0; item = default(T); }
            public bool Collision
            {
                get
                { return (hash_collision & 0x80000000) != 0; }
                set
                {
                    if (value)
                        hash_collision |= 0x80000000;
                    else
                        hash_collision &= 0x7FFFFFFF;
                }
            }
        }
        public Hash(IEqualityComparer<T> equalityComparer)
        { this.equalityComparer = equalityComparer; this.loadFactor = 0.70F; }
        internal int GetEnumerationStamp()
        { return changeStamp; }
        internal void StopEnumerations()
        { ++changeStamp; }
        internal void CheckEnumerationStamp(int startStamp)
        {
            if (startStamp != changeStamp)
            { throw new InvalidOperationException(Strings.ChangeDuringEnumeration); }
        }
        private int GetFullHash(T item)
        {
            uint hash; hash = (uint)Util.GetHashCode(item, equalityComparer); hash += ~(hash << 15); hash ^= (hash >> 10); hash += (hash << 3); hash ^= (hash >> 6); hash += ~(hash << 11); hash ^= (hash >> 16); hash &= 0x7FFFFFFF; if (hash == 0)
                hash = 0x7FFFFFFF; return (int)hash;
        }
        private void GetHashValuesFromFullHash(int hash, out int initialBucket, out int skip)
        { initialBucket = hash & hashMask; skip = ((hash >> secondaryShift) & hashMask) | 1; }
        private int GetHashValues(T item, out int initialBucket, out int skip)
        { int hash = GetFullHash(item); GetHashValuesFromFullHash(hash, out initialBucket, out skip); return hash; }
        private void EnsureEnoughSlots(int additionalItems)
        {
            StopEnumerations(); if (usedSlots + additionalItems > thresholdGrow)
            {
                int newSize; newSize = Math.Max(totalSlots, MINSIZE); while ((int)(newSize * loadFactor) < usedSlots + additionalItems)
                {
                    newSize *= 2; if (newSize <= 0)
                    { throw new InvalidOperationException(Strings.CollectionTooLarge); }
                }
                ResizeTable(newSize);
            }
        }
        private void ShrinkIfNeeded()
        {
            if (count < thresholdShrink)
            {
                int newSize; if (count > 0)
                {
                    newSize = MINSIZE; while ((int)(newSize * loadFactor) < count)
                        newSize *= 2;
                }
                else
                { newSize = 0; }
                ResizeTable(newSize);
            }
        }
        private int GetSecondaryShift(int newSize)
        {
            int x = newSize - 2; int secondaryShift = 0; while ((x & 0x40000000) == 0)
            { x <<= 1; ++secondaryShift; }
            return secondaryShift;
        }
        private void ResizeTable(int newSize)
        {
            Slot[] oldTable = table; Debug.Assert((newSize & (newSize - 1)) == 0); totalSlots = newSize; thresholdGrow = (int)(totalSlots * loadFactor); thresholdShrink = thresholdGrow / 3; if (thresholdShrink <= MINSIZE)
                thresholdShrink = 1; hashMask = newSize - 1; secondaryShift = GetSecondaryShift(newSize); if (totalSlots > 0)
                table = new Slot[totalSlots];
            else
                table = null; if (oldTable != null && table != null)
            {
                foreach (Slot oldSlot in oldTable)
                {
                    int hash, bucket, skip; hash = oldSlot.HashValue; GetHashValuesFromFullHash(hash, out bucket, out skip); while (!table[bucket].Empty)
                    { table[bucket].Collision = true; bucket = (bucket + skip) & hashMask; }
                    table[bucket].HashValue = hash; table[bucket].item = oldSlot.item;
                }
            }
            usedSlots = count;
        }
        public int ElementCount
        {
            get
            { return count; }
        }
        internal int SlotCount
        {
            get
            { return totalSlots; }
        }
        public float LoadFactor
        {
            get
            { return loadFactor; }
            set
            {
                if (value < 0.25 || value > 0.95)
                    throw new ArgumentOutOfRangeException("value", Strings.InvalidLoadFactor); StopEnumerations(); bool maybeExpand = value < loadFactor; loadFactor = value; thresholdGrow = (int)(totalSlots * loadFactor); thresholdShrink = thresholdGrow / 3; if (thresholdShrink <= MINSIZE)
                    thresholdShrink = 1; if (maybeExpand)
                    EnsureEnoughSlots(0);
                else
                    ShrinkIfNeeded();
            }
        }
        public bool Insert(T item, bool replaceOnDuplicate, out T previous)
        {
            int hash, bucket, skip; int emptyBucket = -1; bool duplicateMightExist = true; EnsureEnoughSlots(1); hash = GetHashValues(item, out bucket, out skip); for (;;)
            {
                if (table[bucket].Empty)
                {
                    if (emptyBucket == -1)
                        emptyBucket = bucket; if (!duplicateMightExist || !table[bucket].Collision)
                    { break; }
                }
                else if (table[bucket].HashValue == hash && equalityComparer.Equals(table[bucket].item, item))
                {
                    previous = table[bucket].item; if (replaceOnDuplicate)
                        table[bucket].item = item; return false;
                }
                else
                {
                    if (!table[bucket].Collision)
                    {
                        if (emptyBucket >= 0)
                        { break; }
                        else
                        { table[bucket].Collision = true; duplicateMightExist = false; }
                    }
                }
                bucket = (bucket + skip) & hashMask;
            }
            table[emptyBucket].HashValue = hash; table[emptyBucket].item = item; ++count; if (!table[emptyBucket].Collision)
                ++usedSlots; previous = default(T); return true;
        }
        public bool Delete(T item, out T itemDeleted)
        {
            int hash, bucket, skip; StopEnumerations(); if (count == 0)
            { itemDeleted = default(T); return false; }
            hash = GetHashValues(item, out bucket, out skip); for (;;)
            {
                if (table[bucket].HashValue == hash && equalityComparer.Equals(table[bucket].item, item))
                {
                    itemDeleted = table[bucket].item; table[bucket].Clear(); --count; if (!table[bucket].Collision)
                        --usedSlots; ShrinkIfNeeded(); return true;
                }
                else if (!table[bucket].Collision)
                { itemDeleted = default(T); return false; }
                bucket = (bucket + skip) & hashMask;
            }
        }
        public bool Find(T find, bool replace, out T item)
        {
            int hash, bucket, skip; if (count == 0)
            { item = default(T); return false; }
            hash = GetHashValues(find, out bucket, out skip); for (;;)
            {
                if (table[bucket].HashValue == hash && equalityComparer.Equals(table[bucket].item, find))
                {
                    item = table[bucket].item; if (replace)
                        table[bucket].item = find; return true;
                }
                else if (!table[bucket].Collision)
                { item = default(T); return false; }
                bucket = (bucket + skip) & hashMask;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (count > 0)
            {
                int startStamp = changeStamp; foreach (Slot slot in table)
                {
                    if (!slot.Empty)
                    { yield return slot.item; CheckEnumerationStamp(startStamp); }
                }
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        { return GetEnumerator(); }

        public Hash<T> Clone(Converter<T, T> cloneItem)
        {
            Hash<T> clone = new Hash<T>(equalityComparer); clone.count = this.count; clone.usedSlots = this.usedSlots; clone.totalSlots = this.totalSlots; clone.loadFactor = this.loadFactor; clone.thresholdGrow = this.thresholdGrow; clone.thresholdShrink = this.thresholdShrink; clone.hashMask = this.hashMask; clone.secondaryShift = this.secondaryShift; if (table != null)
            {
                clone.table = (Slot[])table.Clone(); if (cloneItem != null)
                {
                    for (int i = 0; i < table.Length; ++i)
                    {
                        if (!table[i].Empty)
                            table[i].item = cloneItem(table[i].item);
                    }
                }
            }
            return clone;
        }

        #region Serialization

#if !PCL
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info"); info.AddValue("equalityComparer", equalityComparer, typeof(IEqualityComparer<T>)); info.AddValue("loadFactor", loadFactor, typeof(float)); T[] items = new T[count]; int i = 0; foreach (Slot slot in table)
                if (!slot.Empty)
                    items[i++] = slot.item; info.AddValue("items", items, typeof(T[]));
        }
        protected Hash(SerializationInfo serInfo, StreamingContext context)
        { serializationInfo = serInfo; }
        void IDeserializationCallback.OnDeserialization(object sender)
        {
            if (serializationInfo == null)
                return; loadFactor = serializationInfo.GetSingle("loadFactor"); equalityComparer = (IEqualityComparer<T>)serializationInfo.GetValue("equalityComparer", typeof(IEqualityComparer<T>)); T[] items = (T[])serializationInfo.GetValue("items", typeof(T[])); T dummy; EnsureEnoughSlots(items.Length); foreach (T item in items)
                Insert(item, true, out dummy); serializationInfo = null;
        }

#endif

        #endregion Serialization

#if DEBUG

        internal void PrintStats()
        { Console.WriteLine("count={0}  usedSlots={1}  totalSlots={2}", count, usedSlots, totalSlots); Console.WriteLine("loadFactor={0}  thresholdGrow={1}  thresholdShrink={2}", loadFactor, thresholdGrow, thresholdShrink); Console.WriteLine("hashMask={0:X}  secondaryShift={1}", hashMask, secondaryShift); Console.WriteLine(""); }
        internal void Print()
        {
            PrintStats(); for (int i = 0; i < totalSlots; ++i)
                Console.WriteLine("Slot {0,4:X}: {1} {2,8:X} {3}", i, table[i].Collision ? "C" : " ", table[i].HashValue, table[i].Empty ? "<empty>" : table[i].item.ToString()); Console.WriteLine("");
        }
        internal void Validate()
        {
            Debug.Assert(count <= usedSlots); Debug.Assert(count <= totalSlots); Debug.Assert(usedSlots <= totalSlots); Debug.Assert(usedSlots <= thresholdGrow); Debug.Assert((int)(totalSlots * loadFactor) == thresholdGrow); if (thresholdShrink > 1)
                Debug.Assert(thresholdGrow / 3 == thresholdShrink);
            else
                Debug.Assert(thresholdGrow / 3 <= MINSIZE); if (totalSlots > 0)
            { Debug.Assert((totalSlots & (totalSlots - 1)) == 0); Debug.Assert(totalSlots - 1 == hashMask); Debug.Assert(GetSecondaryShift(totalSlots) == secondaryShift); Debug.Assert(totalSlots == table.Length); }
            int expectedCount = 0, expectedUsed = 0, initialBucket, skip; if (table != null)
            {
                for (int i = 0; i < totalSlots; ++i)
                {
                    Slot slot = table[i]; if (slot.Empty)
                    {
                        if (slot.Collision)
                            ++expectedUsed; Debug.Assert(object.Equals(default(T), slot.item));
                    }
                    else
                    {
                        ++expectedCount; ++expectedUsed; Debug.Assert(slot.HashValue != 0); Debug.Assert(GetHashValues(slot.item, out initialBucket, out skip) == slot.HashValue); if (initialBucket != i)
                            Debug.Assert(table[initialBucket].Collision);
                    }
                }
            }
            Debug.Assert(expectedCount == count); Debug.Assert(expectedUsed == usedSlots);
        }
#endif 
    }
}
