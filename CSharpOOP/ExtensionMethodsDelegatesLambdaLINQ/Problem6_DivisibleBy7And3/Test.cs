namespace Problem6_DivisibleBy7And3
{
    using System;
    using System.Linq;
    class Test
    {
        static void Main()
        {
            /*
            Problem 6. Divisible by 7 and 3
            Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
            Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
            */
            int[] myArray = new int[] { 84, 42, 1, 3, 5, 21, 33, 35, 7, 77, 12, 11, 46, 18, 143, 55, 63, 234 };

            Console.WriteLine("List of ints: {0}", string.Join(" ", myArray));
            Console.WriteLine();

            var divisibleByThereeAndSeven = myArray
                .Where(x => x % 3 == 0 && x % 7 == 0);
            Console.WriteLine("All numbers divisible by 3 and 7: {0}", string.Join(" ", divisibleByThereeAndSeven));
            Console.WriteLine();

            var linqDivisibleNumbers =
                from num in myArray
                where num % 3 == 0 && num % 7 == 0
                select num;
            Console.WriteLine("Same with LINQ: {0}", string.Join(" ", linqDivisibleNumbers));
        }
    }
}
