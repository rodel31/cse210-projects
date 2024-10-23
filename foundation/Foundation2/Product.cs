public class Product
{
    private string Name { get; set; }
    private string ProductId { get; set; }
    private decimal Price { get; set; }
    private int Quantity { get; set; }

    public Product(string name, string productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }
    public decimal GetTotalCost()
    {
        return Price * Quantity;
    }
    public string GetProductInfo()
    {
        return $"{Name} (ID: {ProductId}) - {Quantity} @ {Price:C} each";
    }
}