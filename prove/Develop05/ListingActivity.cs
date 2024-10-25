/*public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    public ListingActivity() : base("Listing Activity", "Well done on listing your thoughts!")
    {
    }
    public override void Start()
    {
        Console.WriteLine(StartingMessage);
        Console.Write("Enter duration in seconds for listing activity: ");
        int seconds = int.Parse(Console.ReadLine());
        SetDuration(seconds);
        Console.WriteLine("Get ready to begin...");
        Countdown(3); // Initial pause before starting
        // Display a random prompt from the list
        Console.WriteLine(GetRandomPrompt(prompts));
        Countdown(3); // Pause to let user think
        List<string> userItems = new List<string>();
        var endTime = DateTime.Now.AddSeconds(Duration);
        // Collect items until time is up
        Console.WriteLine("Start listing items (press Enter after each item):");
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                userItems.Add(item);
            }
        }
        // Display count of items listed
        Console.WriteLine($"You listed {userItems.Count} items!");
        Console.WriteLine(FinishingMessage);
        Countdown(3); // Final pause after finishing
    }
}*/
public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "You did a great job listing!")
    {
    }

    public override void Start()
    {
        Console.WriteLine("This activity will help you reflect on the good things in your life.");
        int seconds = SelectDuration();
        SetDuration(seconds);

        Console.WriteLine("Get ready to begin...");
        Countdown(3);

        Console.WriteLine(GetUniquePrompt(prompts));
        Countdown(3);

        List<string> items = new List<string>();
        var endTime = DateTime.Now.AddSeconds(Duration);

        Console.WriteLine("Start listing items (press Enter after each):");
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine($"You listed {items.Count} items!");
        Console.WriteLine(FinishingMessage);
        Countdown(3);
    }
}
