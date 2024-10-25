/*public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What did you learn from this experience?",
        "What did you learn about yourself through this experience?"
    };
    public ReflectionActivity() : base("Reflection Activity", "Great job on reflecting!")
    {
    }
    public override void Start()
    {
        Console.WriteLine(StartingMessage);
        Console.Write("Enter duration in seconds for reflection activity: ");
        int seconds = int.Parse(Console.ReadLine());
        SetDuration(seconds);
        Console.WriteLine("Get ready to begin...");
        Countdown(3); // Initial pause
        Console.WriteLine(GetRandomPrompt(prompts)); // Show random prompt
        Countdown(3); // Pause to let user think
        // Show random reflection questions until duration is reached
        for (int i = 0; i < Duration / 10; i++)
        {
            Console.WriteLine(GetRandomPrompt(questions));
            Countdown(5); // Pause for each question
        }
        Console.WriteLine(FinishingMessage);
        Countdown(3); // Final pause
    }
}*/
public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
       "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What did you learn from this experience?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectionActivity() : base("Reflection Activity", "Great job reflecting!")
    {
    }

    public override void Start()
    {
        Console.WriteLine("This activity will help you reflect on times of strength and resilience.");
        int seconds = SelectDuration();
        SetDuration(seconds);

        Console.WriteLine("Get ready to begin...");
        Countdown(3);

        Console.WriteLine(GetUniquePrompt(prompts));
        var endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(GetUniquePrompt(questions));
            Countdown(3);
        }

        Console.WriteLine(FinishingMessage);
        Countdown(3);
    }
}
