using System;
using System.Collections.Generic;

namespace LargeCollectionAndEfficientlySearch
{
    internal class Product : IComparable<Product>
    {
        private string name;
        private int price;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public Product(string name, int price)
        {
            this.Price = price;
            this.Name = name;
        }

        public int CompareTo(Product second)
        {
            if (this.Price > second.Price)
            {
                return 1;
            }
            else if (this.Price < second.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return $"Product name: {this.Name} --- Price: {this.Price}";
        }
    }
}