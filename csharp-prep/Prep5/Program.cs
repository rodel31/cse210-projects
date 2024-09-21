using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);
    }
    public static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    public static String PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    public static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    public static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }
    public static void DisplayResult(string name, int square)
    {
        Console.WriteLine("Hi "+name+", the square of your number is " +square);
    }
}