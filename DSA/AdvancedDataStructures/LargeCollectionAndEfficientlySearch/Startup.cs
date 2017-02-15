using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace LargeCollectionAndEfficientlySearch
{
    // 02. Write a program to read a large collection of products(name + price) 
    // and efficiently find the first 20 products in the price range[a…b].
    // Test for 500 000 products and 10 000 price searches.

    public class Startup
    {
        private const int NumberOfProducts = 500000;

        private static Product productFrom = new Product("FROM", 30);
        private static Product productTo = new Product("TO", 60);

        static void Main()
        {
            OrderedBag<Product> bag = new OrderedBag<Product>();

            CreateProducts(bag);

            Console.WriteLine("Count of bag: " +  bag.Count);

            // Predicate<Product> predicate = p => p.Price >= 30 && p.Price < 60;

            IEnumerable<Product> selectedItems = bag.Range(productFrom, true, productTo, true).Take(20);

            Console.WriteLine("First 20 selected products whit price between 30 and 60: " + selectedItems.Count());

            foreach (var item in selectedItems)
            {
                Console.WriteLine(item);
            }
        }

        private static void CreateProducts(OrderedBag<Product> bag)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTVUWXYZabcdefghijklmnopqrstvuwxyz";
            var random = new Random();

            for (int i = 0; i < NumberOfProducts; i++)
            {
                int currentNameLength = random.Next(5, 11);
                StringBuilder currentName = new StringBuilder();

                for (int j = 0; j < currentNameLength; j++)
                {
                    currentName.Append(alphabet[random.Next(0, alphabet.Length - 1)]);
                }

                bag.Add(new Product(currentName.ToString(), random.Next(1, 500000)));
            }
        }
    }
}
