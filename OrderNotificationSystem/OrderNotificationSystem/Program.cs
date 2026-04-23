using OrderNotificationSystem;

OrderService orderService = new OrderService(order => order.Price >= 50);

EmailService emailService = new EmailService();
SMSService smsService = new SMSService();

emailService.Subscribe(orderService);
smsService.Subscribe(orderService);

while (true)
{
    Console.Clear();
    Console.WriteLine("ORDER NOTIFICATION SYSTEM\n\n");

    Console.WriteLine("[1] Built-in Orders");
    Console.WriteLine("[2] Enter Your Orders");
    Console.WriteLine("[3] Exit");

    int choice = -1;
    while (true)
    {
        Console.Write("Option:");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out choice) && choice >= 0 && choice <= 3)
            break;
        Console.WriteLine("Invalid Option.");
    }

    Console.Clear();
    switch (choice)
    {
        case 1:
            BuiltInOrders();
            break;

        case 2:
            EnterYourOrders();
            break;

        case 3:
            Environment.Exit(0);
            break;

        default:
            break;
    }
}

void BuiltInOrders()
{
    Console.WriteLine("Built-in Order\n\n".ToUpper());

    Order order1 = new Order("Mazen", "Laptop", 1000m);
    orderService.PlaceOrder(order1);
    Console.WriteLine(new string('─', 20));

    Order order2 = new Order("Omar", "Cable", 20m);
    orderService.PlaceOrder(order2);
    Console.WriteLine(new string('─', 20));

    Order order3 = new Order("Ahmed", "Book", 50m);
    orderService.PlaceOrder(order3);
    Console.WriteLine(new string('─', 20));

    Order order4 = new Order("Amr", "Mobile", 200m);
    orderService.PlaceOrder(order4);
    Console.WriteLine(new string('─', 20));

    Order order5 = new Order("Ali", "Poster", 60);
    orderService.PlaceOrder(order5);
    Console.WriteLine(new string('─', 20));

    Console.WriteLine("\n\n PRESS ENTER TO ESCAPE");
    Console.ReadKey();
}

void EnterYourOrders()
{
    Console.WriteLine("Enter Your Orders\n\n".ToUpper());

    while (true)
    {

        Order order = OrderExtensions.InputOrder();
        Console.WriteLine(new string('─', 20));
        orderService.PlaceOrder(order);
        Console.WriteLine(new string('─', 20));

        Console.WriteLine("\nPress Enter to resume or Esc to escape\n");
        
        var key = Console.ReadKey();

        if (key.Key == ConsoleKey.Escape )
            return;

    }
}




