abstract class Goal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public bool IsComplete { get;  set; }

        public Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
            IsComplete = false;
        }
        public abstract int RecordProgress(); // Abstract to be overridden by derived classes

        public override string ToString()
        {
            return $"{Name} - {Description} - Points: {Points} - Complete: {IsComplete}";
        }
    }