using System;
using System.Collections.Generic;
using System.Text;

namespace OrderNotificationSystem
{
    public class SMSService
    {
        public void Subscribe(OrderService service)
        {
            service.OrderPlaced += OnOrderPlaced;
        }

        private void OnOrderPlaced(Order order)
        {
            string message = order.FormatMessage();
            Console.WriteLine($"[SMS]   Notification sent => {message}");
        }
    }
}
