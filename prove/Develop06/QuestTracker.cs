class QuestTracker
{
    public List<Goal> goals{ get;  set; } = new List<Goal>();
    public int TotalScore { get;  set; }
    public int Level { get; private set; }
    public int StreakCount { get; private set; }
    public QuestTracker()
    {
        TotalScore = 0;
        Level = 1;
        StreakCount = 0;
    }
    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }
    public void RecordGoalProgress(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            int pointsEarned = goals[goalIndex].RecordProgress();
            TotalScore += pointsEarned;
            Console.WriteLine($"Progress recorded! Points earned: {pointsEarned}. Total score: {TotalScore}");
            if (pointsEarned > 0)
            {
                StreakCount++;
                TotalScore += StreakCount >= 5 ? 50 : 0; // Bonus points for a 5-goal streak
                CheckLevelUp();
            }
            else
            {
                StreakCount = 0; // Reset streak on negative goal
            }

            Console.WriteLine($"Progress recorded! Points earned: {pointsEarned}. Total score: {TotalScore}");
            Console.WriteLine($"Current level: {Level}, Streak count: {StreakCount}");      
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }
    private void CheckLevelUp()
    {
        int nextLevelThreshold = Level * 100;
        if (TotalScore >= nextLevelThreshold)
        {
            Level++;
            Console.WriteLine($"Congratulations! You've leveled up to Level {Level}!");
        }
    }
    public void DisplayGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"[{i}] {goals[i]}");
        }
    }
    public void SaveData(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(TotalScore);
            foreach (Goal goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Description}|{goal.Points}|{goal.IsComplete}");
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal.CurrentCount}|{checklistGoal.TargetCount}|{checklistGoal.BonusPoints}");
                }
            }
        }
        Console.WriteLine("Data saved successfully.");
    }
    public void LoadData(string filePath)
    {
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                TotalScore = int.Parse(reader.ReadLine());
                goals.Clear();
                while (!reader.EndOfStream)
                {
                    string[] goalData = reader.ReadLine().Split('|');
                    string goalType = goalData[0];
                    string name = goalData[1];
                    string description = goalData[2];
                    int points = int.Parse(goalData[3]);
                    bool isComplete = bool.Parse(goalData[4]);

                    Goal goal;
                    if (goalType == "SimpleGoal")
                    {
                        goal = new SimpleGoal(name, description, points);
                    }
                    else if (goalType == "EternalGoal")
                    {
                        goal = new EternalGoal(name, description, points);
                    }
                    else if (goalType == "ChecklistGoal")
                    {
                        int currentCount = int.Parse(reader.ReadLine());
                        int targetCount = int.Parse(reader.ReadLine());
                        int bonusPoints = int.Parse(reader.ReadLine());
                        goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints)
                        {
                            CurrentCount = currentCount
                        };
                    }
                    else if (goalType == "ProgressGoal")
                    {
                        int currentProgress = int.Parse(reader.ReadLine());
                        int targetProgress = int.Parse(reader.ReadLine());
                        goal = new ProgressGoal(name, description, points, targetProgress)
                        {
                            CurrentProgress = currentProgress
                        };
                    }
                    else // NegativeGoal
                    {
                        goal = new NegativeGoal(name, description, points);
                    }
                    goal.IsComplete = isComplete;
                    goals.Add(goal);
                    Console.WriteLine(goal);
                }
                Console.WriteLine("Data loaded successfully.");
            }
        }
        else
        {
            Console.WriteLine("No save file found.");
        }
    }
}   