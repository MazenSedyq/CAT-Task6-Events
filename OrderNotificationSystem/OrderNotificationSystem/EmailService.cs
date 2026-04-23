using System;
using System.Collections.Generic;
using System.Text;

namespace OrderNotificationSystem
{
    public class EmailService
    {
        public void Subscribe(OrderService service)
        {
            service.OrderPlaced += OnOrderPlaced;
        }

        private void OnOrderPlaced(Order order)
        {
            string message = order.FormatMessage();
            Console.WriteLine($"[EMAIL] Notification sent => {message}");
        }
    }
}
