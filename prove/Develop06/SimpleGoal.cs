class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points) { }
        public override int RecordProgress()
        {
            if (!IsComplete)
            {
                IsComplete = true;
                return Points;
            }
            return 0; // No points awarded if already completed
        }
    }