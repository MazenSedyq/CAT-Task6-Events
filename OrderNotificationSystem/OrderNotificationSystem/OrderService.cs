using System;
using System.Collections.Generic;
using System.Text;

namespace OrderNotificationSystem
{
    public class OrderService
    {
        public delegate void OrderPlacedHandler(Order order);

        public event OrderPlacedHandler OrderPlaced;

        private Func<Order, bool> Filter ;

        public OrderService(Func<Order, bool> filter)
        {
            this.Filter = filter;
        }

        public void PlaceOrder(Order order)
        {
            if (Filter == null || Filter(order))
            {
                OrderPlaced?.Invoke(order);
            }
        }
    }
}
