class ChecklistGoal : Goal
    {
        public int TargetCount { get; }
        public int CurrentCount { get; set; }
        public int BonusPoints { get; }

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            TargetCount = targetCount;
            BonusPoints = bonusPoints;
            CurrentCount = 0;
        }
        public override int RecordProgress()
        {
            if (IsComplete) return 0;

            CurrentCount++;
            if (CurrentCount >= TargetCount)
            {
                IsComplete = true;
                return Points + BonusPoints; // Points plus bonus when complete
            }
            return Points; // Regular points for each progress
        }
        public override string ToString()
        {
            return base.ToString() + $" - Progress: {CurrentCount}/{TargetCount}";
        }
    }