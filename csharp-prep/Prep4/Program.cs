using System;

class Program
{
    static void Main(string[] args)
    {
        int sum = 0; 
        int largest = 0;
        int smallestPositive = 0;
        double average;

        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int num = 1;
        do
        {
            Console.Write("Enter number: ");
            int inputNum = int.Parse(Console.ReadLine());
          
            if(inputNum != 0)
            {
                numbers.Add(inputNum);
            }
            else
            {
                num = 0;
            }
        }while(num != 0);
        
        foreach(int number in numbers)
        {
            sum = sum + number;
            if(largest < number)
            {
                largest = number;
                smallestPositive = number;
            }
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        Console.WriteLine("The sum is: "+sum);
        average = Convert.ToDouble(sum)/Convert.ToDouble(numbers.Count);
        Console.WriteLine("The average is: "+average);
        Console.WriteLine("The largest number is: "+largest);
        Console.WriteLine("The smallest positive number is: "+smallestPositive);
        Console.WriteLine("The sorted list is: ");
        numbers.Sort();
        foreach(int printNumber in numbers)
        {
            Console.WriteLine(printNumber);
        }
    }
}