class ProgressGoal : Goal
    {
        public int TargetProgress { get; }
        public int CurrentProgress { get; set; }

        public ProgressGoal(string name, string description, int points, int targetProgress)
            : base(name, description, points)
        {
            TargetProgress = targetProgress;
            CurrentProgress = 0;
        }
        public void AddProgress(int progress)
        {
            if (!IsComplete)
            {
                CurrentProgress += progress;
                if (CurrentProgress >= TargetProgress)
                {
                    IsComplete = true;
                }
            }
        }
        public override int RecordProgress()
        {
            return IsComplete ? Points : 0; // Awards points when completed
        }
        public override string ToString()
        {
            return base.ToString() + $" - Progress: {CurrentProgress}/{TargetProgress}";
        }
    }