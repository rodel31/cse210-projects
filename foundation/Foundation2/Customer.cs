public class Customer
{
    private string Name { get; set; }
    private Address CustomerAddress { get; set; }

    public Customer(string name, Address address)
    {
        Name = name;
        CustomerAddress = address;
    }
    public bool LivesInUSA()
    {
        return CustomerAddress.IsInUSA();
    }
    public string GetName()
    {
        return Name;
    }
    public Address GetAddress()
    {
        return CustomerAddress;
    }
}