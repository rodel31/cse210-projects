public class GratitudeActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "List things you're grateful for today.",
        "Who are people in your life you're grateful for?",
        "What abilities or skills do you value?"
    };

    public GratitudeActivity() : base("Gratitude Activity", "Thank you for expressing your gratitude!")
    {
    }

    public override void Start()
    {
        Console.WriteLine("This activity will help you express gratitude for positive aspects of your life.");
        int seconds = SelectDuration();
        SetDuration(seconds);

        Console.WriteLine("Get ready to begin...");
        Countdown(3);

        Console.WriteLine(GetUniquePrompt(prompts));
        Countdown(3);

        List<string> gratitudeList = new List<string>();
        var endTime = DateTime.Now.AddSeconds(Duration);

        Console.WriteLine("Start listing things you're grateful for (press Enter after each):");
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                gratitudeList.Add(item);
            }
        }

        Console.WriteLine($"You listed {gratitudeList.Count} things you're grateful for!");
        Console.WriteLine(FinishingMessage);
        Countdown(3);
    }
}
