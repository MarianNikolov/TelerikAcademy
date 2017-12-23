using System;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace OrdersSystem
{
    public class Program
    {
        static StringBuilder result = new StringBuilder();
        static OrderSystem orderSystem = new OrderSystem();

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (long i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var command = input.Split(' ')[0];
                var parameters = input.Remove(0, input.IndexOf(' ') + 1).Split(';');

                switch (command)
                {
                    case "AddOrder":
                        var order = new Order(parameters[0], double.Parse(parameters[1]), parameters[2]);
                        orderSystem.AddOrder(order, result);
                        break;

                    case "DeleteOrders":
                        orderSystem.DeleteOrders(parameters[0], result);
                        break;

                    case "FindOrdersByPriceRange":
                        orderSystem.FindOrdersByPriceRange(double.Parse(parameters[0]), double.Parse(parameters[1]), result);
                        break;

                    case "FindOrdersByConsumer":
                        orderSystem.FindOrdersByConsumer(parameters[0], result);
                        break;
                }
            }

            Console.WriteLine(result.ToString());

        }
    }

    class Order : IComparable<Order>
    {
        public string Name;
        public double Price;
        public string Consumer;

        public Order(string name, double price, string consumer)
        {
            this.Name = name;
            this.Price = price;
            this.Consumer = consumer;
        }

        public override string ToString()
        {
            return "{" + string.Format("{0};{1};{2:F2}", this.Name, this.Consumer, this.Price) + "}";
        }

        public int CompareTo(Order other)
        {
            var res = this.Name.CompareTo(other.Name);

            if (res == 0)
            {
                res = this.Consumer.CompareTo(other.Consumer);
            }
            if (res == 0)
            {
                res = this.Price.CompareTo(other.Price);
            }

            return res;
        }
    }

    class OrderSystem
    {
        MultiDictionary<string, Order> ByConsumer;
        OrderedMultiDictionary<double, Order> ByPrice;

        public OrderSystem()
        {
            this.ByConsumer = new MultiDictionary<string, Order>(true);
            this.ByPrice = new OrderedMultiDictionary<double, Order>(true);
        }

        public void AddOrder(Order order, StringBuilder result)
        {
            ByConsumer[order.Consumer].Add(order);
            ByPrice[order.Price].Add(order);

            result.AppendLine("Order added");
        }

        public void DeleteOrders(string consumer, StringBuilder result)
        {
            // "No orders found" if no such orders exist.
            if (!ByConsumer.ContainsKey(consumer))
            {
                result.AppendLine("No orders found");
                return;
            }

            var ordersForRemove = ByConsumer[consumer].ToList();
            ByConsumer[consumer].Clear();
            var count = ordersForRemove.Count;
            foreach (var order in ordersForRemove)
            {
                ByPrice[order.Price].Remove(order);
            }

            result.AppendLine(string.Format("{0} orders deleted", count));
        }

        public void FindOrdersByPriceRange(double fromPrice, double toPrice, StringBuilder result)
        {
            var range = ByPrice.Range(fromPrice, true, toPrice, true).Values.ToList();

            if (range.Count == 0)
            {
                result.AppendLine("No orders found");
                return;
            }

            range.Sort();

            for (int i = 0; i < range.Count; i++)
            {
                result.AppendLine(range[i].ToString());
            }
        }

        public void FindOrdersByConsumer(string consumer, StringBuilder result)
        {
            var range = ByConsumer[consumer].ToList();

            if (range.Count == 0)
            {
                result.AppendLine("No orders found");
                return;
            }

            range.Sort();

            for (int i = 0; i < range.Count; i++)
            {
                result.AppendLine(range[i].ToString());
            }
        }
    }
}
