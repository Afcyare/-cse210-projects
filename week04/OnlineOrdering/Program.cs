using System;

class Program
{
    static void Main()
    {
        // Create products
        Product laptop = new Product("Laptop", "P1001", 899.99, 1);
        Product mouse = new Product("Wireless Mouse", "P1002", 24.99, 2);
        Product keyboard = new Product("Mechanical Keyboard", "P1003", 79.99, 1);
        
        Product book = new Product("C# Programming", "P2001", 49.99, 3);
        Product mug = new Product("Coffee Mug", "P2002", 12.99, 2);

        // Create addresses
        Address usaAddress = new Address("123 Main St", "Seattle", "WA", "USA");
        Address canadaAddress = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create customers
        Customer john = new Customer("John Smith", usaAddress);
        Customer emma = new Customer("Emma Johnson", canadaAddress);

        // Create orders
        Order order1 = new Order(john);
        order1.AddProduct(laptop);
        order1.AddProduct(mouse);
        
        Order order2 = new Order(emma);
        order2.AddProduct(book);
        order2.AddProduct(mug);
        order2.AddProduct(keyboard);

        // Display order details
        DisplayOrder(order1);
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("=================================");
        Console.WriteLine(order.ShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order.PackingLabel());
        Console.WriteLine($"Total Cost: ${order.CalculateTototalCost():0.00}");
        Console.WriteLine("=================================\n");
    }
}