using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace InternetShop
{
    class Program
    {
        static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            var result = new StringBuilder();
            var shop = new Shop();

            for (long i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var command = input.Split(' ')[0];
                var parameters = input.Remove(0, input.IndexOf(' ') + 1).Split(';');

                string name = string.Empty;
                string producer = string.Empty;

                switch (command)
                {
                    case "AddProduct":
                        var prod = new Product(parameters[0], double.Parse(parameters[1]), parameters[2]);
                        shop.Add(prod);
                        result.AppendLine("Product added");
                        break;

                    case "DeleteProducts":
                        if (parameters.Length > 1)
                        {
                            //•	DeleteProducts name; producer – изтрива продукт или няколко продукта по дадено име или 
                            //производител. Като резултат командата отпечатва “X products deleted”, където X е броя на 
                            //изтритите продукти или “No products found”, ако такива продукти не съществуват.
                            name = parameters[0];
                            producer = parameters[1];

                            var allForRemove = shop.ProductsByProducer[producer].Where(x => x.Name == name).ToList();
                            if (allForRemove.Count() == 0)
                            {
                                result.AppendLine("No products found");
                            }
                            else
                            {

                                foreach (var currentProd in allForRemove)
                                {
                                    shop.ProductsByProducer[currentProd.Producer].Remove(currentProd);
                                    shop.ProductsByName[currentProd.Name].Remove(currentProd);
                                    shop.ProductsByPrice[currentProd.Price].Remove(currentProd);
                                }

                                result.AppendLine(allForRemove.Count() + " products deleted");
                            }
                        }
                        else
                        {
                            //•	DeleteProducts producer – изтрива всички продукти, произведени от даден производител. 
                            //Като резултат командата отпечатва “X products deleted”, където X е броя на изтритите продукти 
                            //или “No products found”, ако такива продукти не съществуват.
                            producer = parameters[0];

                            if (shop.ProductsByProducer[producer].Count == 0)
                            {
                                result.AppendLine("No products found");
                            }
                            else
                            {
                                var allForRemove = shop.ProductsByProducer[producer].ToList();

                                foreach (var currentProd in allForRemove)
                                {
                                    shop.ProductsByProducer[producer].Remove(currentProd);
                                    shop.ProductsByName[currentProd.Name].Remove(currentProd);
                                    shop.ProductsByPrice[currentProd.Price].Remove(currentProd);
                                }

                                result.AppendLine(allForRemove.Count() + " products deleted");
                            }

                        }
                        break;

                    case "FindProductsByName":
                        //•	FindProductsByName name – намира всички продукти по зададено име на продукт. 
                        //Като резултат командата отпечатва лист с продукти във формата { name; producer; price}. 
                        //Продуктите в листа трябва да са подредени по азбучен ред и всеки от тях да е на отделен ред.
                        //Ако продукти със зададеното име не съществуват, командата отпечатва  “No products found”.
                        name = parameters[0];

                        if (!shop.ProductsByName.ContainsKey(name))
                        {
                            result.AppendLine("No products found");
                        }
                        else
                        {
                            var allByName = shop.ProductsByName[name].ToList();
                            allByName.Sort();
                            foreach (var currentProd in allByName)
                            {
                                result.AppendLine(currentProd.ToString());
                            }
                        }

                        break;

                    case "FindProductsByProducer":
                        //•	FindProductsByProducer producer – намира всички продукти по зададен производител. 
                        // Като резултат командата отпечатва лист с продукти във формата { name; producer; price}. 
                        // Продуктите в листа трябва да са подредени по азбучен ред и всеки от тях да е на отделен ред.
                        // Ако продукти за зададения производител не съществуват, командата отпечатва  “No products found”.
                        producer = parameters[0];

                        if (!shop.ProductsByProducer.ContainsKey(producer))
                        {
                            result.AppendLine("No products found");
                        }
                        else
                        {
                            var allByProducer = shop.ProductsByProducer[producer].ToList();
                            allByProducer.Sort();

                            foreach (var currentProd in allByProducer)
                            {
                                result.AppendLine(currentProd.ToString());
                            }
                        }
                        break;

                    case "FindProductsByPriceRange":
                        //•	FindProductsByPriceRange fromPrice; toPrice – 
                        // Намира всички продукти, чиято цена е по-малка или равна на fromPrice и по-малка или равна на 
                        //toPrice. Като резултат командата отпечатва лист с продукти във формата { name; producer; price}. 
                        //Продуктите в листа трябва да са подредени по азбучен ред и всеки от тях да е на отделен ред.
                        //Ако няма продукти в зададения ценови интервал командата отпечатва “No products found”.
                        var from = double.Parse(parameters[0]);
                        var to = double.Parse(parameters[1]);

                        var allInRange = shop.ProductsByPrice.Range(from, true, to, true).Values.ToList();
                        allInRange.Sort();

                        if (allInRange.Count == 0)
                        {
                            result.AppendLine("No products found");
                        }
                        else
                        {
                            foreach (var currentProd in allInRange)
                            {
                                result.AppendLine(currentProd.ToString());
                            }
                        }
                        break;
                }

            }

            Console.WriteLine(result.ToString());
        }
    }

    class NameCompare : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }


    class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Producer { get; set; }

        public Product(string name, double price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public override string ToString()
        {
            return "{" + string.Format("{0};{1};{2:F2}", this.Name, this.Producer, this.Price) + "}";
        }

        public int CompareTo(Product other)
        {
            var res = this.Name.CompareTo(other.Name);
            if (res == 0)
            {
                res = this.Producer.CompareTo(other.Producer);
                if (res == 0)
                {
                    res = this.Price.CompareTo(other.Price);
                }
            }

            return res;
        }
    }

    class Shop
    {
        public MultiDictionary<string, Product> ProductsByProducer { get; set; }
        public MultiDictionary<string, Product> ProductsByName { get; set; }
        public OrderedMultiDictionary<double, Product> ProductsByPrice { get; set; }

        public Shop()
        {
            this.ProductsByProducer = new MultiDictionary<string, Product>(true);
            this.ProductsByName = new MultiDictionary<string, Product>(true);
            this.ProductsByPrice = new OrderedMultiDictionary<double, Product>(true);
        }

        public void Add(Product product)
        {
            ProductsByProducer[product.Producer].Add(product);

            ProductsByName[product.Name].Add(product);

            ProductsByPrice[product.Price].Add(product);
        }
    }
}
