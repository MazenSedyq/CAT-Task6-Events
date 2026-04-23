using System;
using System.Collections.Generic;
using System.Text;

namespace OrderNotificationSystem
{
    public class Order
    {
        private static int id = 0;
        public int ID { get; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public Order(string customerName, string productName, decimal price)
        {
            this.ID = id + 1;
            this.CustomerName = customerName;
            this.ProductName = productName;
            this.Price = price;
        }

    }

    public static class OrderExtensions
    {
        public static string FormatMessage(this Order order)
        {

            return $"Order #{order.ID} | Customer: {order.CustomerName} | Price: {order.Price:C}";
        }

        public static Order InputOrder()
        {
            string customer;
            while (true)
            {
                Console.Write("Customer name: ");
                customer = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(customer))
                    break;
                Console.WriteLine("Must enter a name.");
            }

            string product;
            while (true)
            {
                Console.Write("Product name: ");
                product = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(product))
                    break;
                Console.WriteLine("Must enter a name.");
            }

            decimal price;
            while (true)
            {
                Console.Write("Price: ");
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, out price) && price >= 0)
                    break;
                Console.WriteLine("Invalid price. Please enter a non-negative decimal number.");
            }

            return new Order(customer, product, price);
        }


    }
}
