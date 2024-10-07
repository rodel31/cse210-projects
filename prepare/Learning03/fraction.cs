public class Fraction
{
    // Private attributes for numerator and denominator
    private int numerator;
    private int denominator;

    // Constructor with no parameters (1/1)
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }
    // Constructor with one parameter (numerator, denominator = 1)
    public Fraction(int numerator)
    {
        this.numerator = numerator;
        denominator = 1;
    }
    // Constructor with two parameters (numerator, denominator)
    public Fraction(int numerator, int denominator)
    {
        // Validate denominator
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        this.numerator = numerator;
        this.denominator = denominator;
    }
    // Getter and Setter for numerator
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }
    // Getter and Setter for denominator
    public int Denominator
    {
        get { return denominator; }
        set
        {
            if (value == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            denominator = value;
        }
    }
    // Method to return the fraction as a string
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }
    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}