using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a list of activities
        List<Activity> activities = new List<Activity>();

        // Add a Running activity
        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0)); // 3 miles

        // Add a Cycling activity
        activities.Add(new Cycling(new DateTime(2022, 11, 4), 45, 15.0)); // 15 mph

        // Add a Swimming activity
        activities.Add(new Swimming(new DateTime(2022, 11, 5), 30, 20)); // 20 laps

        // Iterate through the list and display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}