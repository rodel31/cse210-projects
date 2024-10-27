using System;
using System.Collections.Generic;
using System.IO;
class Program
    {
    // Showing Creativity and Exceeding Requirements:
    // 1. Leveling System: Users level up every 1000 points, receiving a congratulatory message.
    // 2. Streak Bonus: A streak of 5 consecutive positive goals grants a 50-point bonus.
    // 3. Negative Goals: Records bad habits, deducting points each time they're logged.
    // 4. Progress Goals: Supports long-term goals with incremental progress, rewarding completion.
    static void Main(string[] args)
    {
        QuestTracker questTracker = new QuestTracker();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Add Goal");
            Console.WriteLine("3. Record Goal Progress");
            Console.WriteLine("4. View Total Score and Level");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            
            switch (Console.ReadLine())
            {
                case "1":
                    questTracker.DisplayGoals();
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                    break;
                
                case "2":
                    AddGoal(questTracker);
                    break;
                
                case "3":
                    RecordProgress(questTracker);
                    break;
                
                case "4":
                    Console.WriteLine($"Total Score: {questTracker.TotalScore}");
                    Console.WriteLine($"Current Level: {questTracker.Level}");
                    Console.WriteLine($"Streak Count: {questTracker.StreakCount}");
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                    break;
                
                case "5":
                    questTracker.SaveData("saveData.txt");
                    break;
                
                case "6":
                    questTracker.LoadData("saveData.txt");
                    break;
                
                case "7":
                    exit = true;
                    break;
                
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
    static void AddGoal(QuestTracker questTracker)
    {
        Console.Clear();
        Console.WriteLine("Add a New Goal");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");
        Console.WriteLine("5. Progress Goal");
        Console.Write("Choose the type of goal to add: ");
        
        string choice = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.Write("Enter points for completing this goal: ");
                int simplePoints = int.Parse(Console.ReadLine());
                questTracker.AddGoal(new SimpleGoal(name, description, simplePoints));
                break;
            
            case "2":
                Console.Write("Enter points awarded each time this goal is recorded: ");
                int eternalPoints = int.Parse(Console.ReadLine());
                questTracker.AddGoal(new EternalGoal(name, description, eternalPoints));
                break;

            case "3":
                Console.Write("Enter points for each completion: ");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter target completion count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points upon completing the target count: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                questTracker.AddGoal(new ChecklistGoal(name, description, checklistPoints, targetCount, bonusPoints));
                break;

            case "4":
                Console.Write("Enter points deducted each time this goal is recorded: ");
                int penaltyPoints = int.Parse(Console.ReadLine());
                questTracker.AddGoal(new NegativeGoal(name, description, penaltyPoints));
                break;

            case "5":
                Console.Write("Enter points awarded upon completing this goal: ");
                int progressPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter the target progress amount: ");
                int targetProgress = int.Parse(Console.ReadLine());
                questTracker.AddGoal(new ProgressGoal(name, description, progressPoints, targetProgress));
                break;

            default:
                Console.WriteLine("Invalid goal type. Returning to main menu.");
                break;
        }
        Console.WriteLine("Goal added successfully. Press any key to return to the menu...");
        Console.ReadKey();
    }
    static void RecordProgress(QuestTracker questTracker)
    {
        Console.Clear();
        Console.WriteLine("Record Progress for a Goal");
        questTracker.DisplayGoals();
        Console.Write("Enter the number of the goal to record progress: ");
        
        if (int.TryParse(Console.ReadLine(), out int goalIndex))
        {
            if (goalIndex >= 0 && goalIndex < questTracker.goals.Count)
            {
                Goal selectedGoal = questTracker.goals[goalIndex];

                // Handle progress differently for ProgressGoal
                if (selectedGoal is ProgressGoal progressGoal)
                {
                    Console.Write("Enter the progress amount to add: ");
                    int progressAmount = int.Parse(Console.ReadLine());
                    progressGoal.AddProgress(progressAmount);
                    Console.WriteLine($"Progress updated for {selectedGoal.Name}.");
                }
                
                // Otherwise, record standard progress
                int pointsEarned = selectedGoal.RecordProgress();
                questTracker.TotalScore += pointsEarned;
                
                // Check and handle leveling up and streak bonuses
                questTracker.RecordGoalProgress(goalIndex);

                Console.WriteLine($"Points earned: {pointsEarned}");
                Console.WriteLine($"Total Score: {questTracker.TotalScore}");
                Console.WriteLine($"Level: {questTracker.Level}");
                Console.WriteLine($"Streak Count: {questTracker.StreakCount}");
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }
}