class NegativeGoal : Goal
    {
        public NegativeGoal(string name, string description, int pointsPenalty)
            : base(name, description, -Math.Abs(pointsPenalty)) { }
        public override int RecordProgress()
        {
            return Points; // Deducts points
        }
        public override string ToString()
        {
            return $"{Name} - {Description} - Points Deducted: {-Points}";
        }
    }