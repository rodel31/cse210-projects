public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "Good job on completing your breathing session!")
    {
    }

    public override void Start()
    {
        Console.WriteLine("This activity will help you relax by guiding you through breathing exercises.");
        int seconds = SelectDuration();
        SetDuration(seconds);

        Console.WriteLine("Get ready to begin...");
        Countdown(3);

        int cycles = Duration / 6; // 3 seconds for each "breathe in/out" cycle
        for (int i = 0; i < cycles; i++)
        {
            Console.Clear();
            Console.WriteLine("Breathe in...");
            BreathingAnimation(3);
            Console.WriteLine("Breathe out...");
            BreathingAnimation(3);
        }

        Console.WriteLine(FinishingMessage);
        Countdown(3);
    }

    private void BreathingAnimation(int seconds)
    {
        for (int i = 0; i <= seconds; i++)
        {
            Console.Clear();
            Console.WriteLine("Breathing" + new string('.', i));
            Thread.Sleep(1000);
        }
    }
}