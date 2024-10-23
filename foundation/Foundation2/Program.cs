using System;

class Program
{
    /*
        1.	Address Class: Encapsulates address details and provides methods to check if the address is in the USA and to get the full address as a string.
        2.	Customer Class: Holds customer information and checks if the customer is located in the USA.
        3.	Product Class: Contains product details and a method to calculate the total cost for the quantity purchased.
        4.	Order Class: Manages a list of products and a customer. It can calculate the total order cost and generate packing and shipping labels.
        5.	Main Method: Creates customer and product instances, adds them to orders, and displays the packing and shipping labels along with the total costs.
    */
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);
        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "001", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "002", 49.99m, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", "003", 599.99m, 1));
        order2.AddProduct(new Product("Headphones", "004", 199.99m, 3));
        // Display order details for Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order1.CalculateTotalCost():C}");
        Console.WriteLine();
        // Display order details for Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order2.CalculateTotalCost():C}");
    }
}