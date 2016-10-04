namespace Problem2_IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;

    class Test
    {
/*  
Problem 2. IEnumerable extensions

Implement a set of extension methods for IEnumerable<T> 
that implement the following group functions: sum, product, min, max, average.
*/

        static void Main()
        {
            IEnumerable<int> enumeration = new List<int>() {3, 5, 7 };

            Console.WriteLine($"Sum is: {enumeration.MyGetSum()} ");
            Console.WriteLine($"Product is: {enumeration.MyGetProduct()}");
            Console.WriteLine($"Min is: {enumeration.MyGetMin()}");
            Console.WriteLine($"Max is: {enumeration.MyGetMax()}");
            Console.WriteLine($"Average is: {enumeration.MyGetAverage()}");
        }
    }
}
