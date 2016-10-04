namespace Problem2_IEnumerableExtensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class MyIEnumerable
    {
        public static T MyGetSum<T>(this IEnumerable<T> en) where T : struct
        {
            T result = default(T);
            foreach (T item in en)
            {
                result += (dynamic)item;
            }
            
            return result;
        }

        public static T MyGetProduct<T>(this IEnumerable<T> en) where T : struct
        {
            T result = (dynamic)default(T) + 1;
            foreach (T item in en)
            {
                result *= (dynamic)item;
            }

            return result;
        }

        public static T MyGetMin<T>(this IEnumerable<T> en)
        {
            return en.Min();
        }

        public static T MyGetMax<T>(this IEnumerable<T> en)
        {
            return en.Max();
        }

        public static T MyGetAverage<T>(this IEnumerable<T> en) where T : struct
        {
            int counter = 0;

            T sum = MyGetSum(en);
            foreach (T item in en)
            {
                counter ++;
            }

            return (dynamic)sum / counter;
        }
    }
}
