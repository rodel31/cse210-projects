public class Address
{
    private string Street { get; set; }
    private string City { get; set; }
    private string StateOrProvince { get; set; }
    private string Country { get; set; }

    public Address(string street, string city, string stateOrProvince, string country)
    {
        Street = street;
        City = city;
        StateOrProvince = stateOrProvince;
        Country = country;
    }
    public bool IsInUSA()
    {
        return Country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }
    public string GetFullAddress()
    {
        return $"{Street}\n{City}, {StateOrProvince}\n{Country}";
    }
}