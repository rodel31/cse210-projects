using System;

class Program
{
    static void Main(string[] args)
    {
        string letter = "";

        Console.Write("Enter your grade percentage: ");
        string percentage = Console.ReadLine();
        int grade = int.Parse(percentage);

        int remainder = grade % 10;

        if(grade >= 90)
        {
            if(remainder >= 7)
            {
                letter = "A+";
            }
            else if(remainder >= 3)
            {
                letter = "A-";
            }
            else
            {
                letter = "A";
            }
            
        }
        else if(grade >= 80)
        {
             if(remainder >= 7)
            {
                letter = "B+";
            }
            else if(remainder >= 3)
            {
                letter = "B-";
            }
            else
            {
                letter = "B";
            }
        }
        else if(grade >= 70)
        {
             if(remainder >= 7)
            {
                letter = "C+";
            }
            else if(remainder >= 3)
            {
                letter = "C-";
            }
            else
            {
                letter = "C";
            }
        }
        else if(grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine("Your letter grade is: "+letter);

        if(grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't worry! Keep trying for next time.");
        }
    }
}