using System;

class Program
{
    static void Main(string[] args)
    { 
        string play = "";
        do
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 100);

            int ctr = 0;
            int guess = 0;

            while(guess != number)
            {
                Console.Write("What is your guest? ");
                guess = int.Parse(Console.ReadLine());

                if(guess == number)
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine("You made guess "+ctr+ " times.");
                }
                else if(number > guess)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Lower");
                }
                ctr++;
            }
            Console.Write("Would you like to play again? Yes or No : ");
            play = Console.ReadLine();
        }while(play == "Yes" || play == "yes");
           
    }
}