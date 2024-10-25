using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    // Implemented Creative Features:
    // 1. Added a GratitudeActivity class as a new mindfulness activity.
    // 2. Created a session log to track how many times each activity is completed during a session.
    // 3. Implemented a save and load feature for the log, allowing the program to remember activity counts across sessions.
    // 4. Enhanced breathing animation with progressive dots to guide breathing pace.
    // 5. Implemented unique prompt selection to ensure no repeats within a session until all prompts are used at least once.
    static Dictionary<string, int> sessionLog = new Dictionary<string, int>
    {
        { "Breathing", 0 },
        { "Reflection", 0 },
        { "Listing", 0 },
        { "Gratitude", 0 }
    };

    public static void Main(string[] args)
    {
        LoadLogFromFile();
        
        // Display menu and start activities
        while(true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing\n2. Reflection\n3. Listing\n4. Gratitude\n5. Exit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var breathing = new BreathingActivity();
                    breathing.Start();
                    UpdateLog("Breathing");
                    break;
                case "2":
                    var reflection = new ReflectionActivity();
                    reflection.Start();
                    UpdateLog("Reflection");
                    break;
                case "3":
                    var listing = new ListingActivity();
                    listing.Start();
                    UpdateLog("Listing");
                    break;
                case "4":
                    var gratitude = new GratitudeActivity();
                    gratitude.Start();
                    UpdateLog("Gratitude");
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    continue; 
            }
            SaveLogToFile();
            DisplayLog();
        }
    }

    public static void UpdateLog(string activityName)
    {
        if (sessionLog.ContainsKey(activityName))
        {
            sessionLog[activityName]++;
        }
    }

    public static void DisplayLog()
    {
        Console.WriteLine("Session Log:");
        foreach (var entry in sessionLog)
        {
            Console.WriteLine($"{entry.Key} Activity completed {entry.Value} times.");
        }
    }

    public static void SaveLogToFile()
    {
        using (StreamWriter writer = new StreamWriter("log.txt"))
        {
            foreach (var entry in sessionLog)
            {
                writer.WriteLine($"{entry.Key}:{entry.Value}");
            }
        }
    }

    public static void LoadLogFromFile()
    {
        if (File.Exists("log.txt"))
        {
            foreach (string line in File.ReadAllLines("log.txt"))
            {
                var parts = line.Split(':');
                if (parts.Length == 2 && sessionLog.ContainsKey(parts[0]))
                {
                    sessionLog[parts[0]] = int.Parse(parts[1]);
                }
            }
        }
    }
}