namespace GenericClass
{
    using System;
    using System.Linq;
    using GenericClass.Models;

    public class Test
    {
        static void Main()
        {
            // Problem 5. Generic class
            var list = new GenericList<int>(8);
            list.Add(5);
            list.Add(22);
            list.Add(31);
            // list.Remove(1);
            // list.Insert(1, 333);
            Console.WriteLine(list);
            Console.WriteLine();

            // Problem 6. Auto-grow
            list.Add(5);
            list.Add(22);
            list.Add(31);
            list.Add(-100);
            Console.WriteLine(list);
            Console.WriteLine();

            // Problem 7. Min and Max
            Console.WriteLine(list.Max());
            Console.WriteLine(list.Min());

        }
    }
}
