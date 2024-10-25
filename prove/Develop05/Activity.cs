using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    public string Name { get; private set; }
    public string FinishingMessage { get; private set; }
    protected int Duration { get; set; }
    private List<string> usedPrompts = new List<string>();

    public Activity(string name, string finishingMessage)
    {
        Name = name;
        FinishingMessage = finishingMessage;
    }

    public void SetDuration(int duration) => Duration = duration;

    protected string GetUniquePrompt(List<string> prompts)
    {
        if (usedPrompts.Count == prompts.Count) usedPrompts.Clear();
        string prompt;
        do { prompt = prompts[new Random().Next(prompts.Count)]; }
        while (usedPrompts.Contains(prompt));
        usedPrompts.Add(prompt);
        return prompt;
    }

    protected void Countdown(int seconds)
    {
        while (seconds > 0)
        {
            Console.Write(seconds + " ");
            Thread.Sleep(1000);
            seconds--;
        }
        Console.WriteLine();
    }

    protected int SelectDuration()
    {
        Console.WriteLine("Enter duration in seconds:");
        return int.Parse(Console.ReadLine());
    }

    public abstract void Start();
}