using System.Collections.Generic;

public class Order
{
    private List<Product> Products { get; set; }
    private Customer OrderCustomer { get; set; }
    private const decimal USAShippingCost = 5.00m;
    private const decimal InternationalShippingCost = 35.00m;

    public Order(Customer customer)
    {
        Products = new List<Product>();
        OrderCustomer = customer;
    }
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }
    public decimal CalculateTotalCost()
    {
        decimal totalProductCost = 0;
        foreach (var product in Products)
        {
            totalProductCost += product.GetTotalCost();
        }

        decimal shippingCost = OrderCustomer.LivesInUSA() ? USAShippingCost : InternationalShippingCost;
        return totalProductCost + shippingCost;
    }
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += product.GetProductInfo() + "\n";
        }
        return label;
    }
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{OrderCustomer.GetName()}\n{OrderCustomer.GetAddress().GetFullAddress()}";
    }
}