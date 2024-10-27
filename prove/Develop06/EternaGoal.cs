class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points) { }
        public override int RecordProgress()
        {
            return Points; // Always awards points, never complete
        }
    }