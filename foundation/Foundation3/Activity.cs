public abstract class Activity
{  
/*
Encapsulate date and minutes with Read-Only Properties: This will allow derived classes or any external code to access these values directly while still keeping them safe from modification.
XML Documentation: This will add clarity to each method’s purpose.
*/
    private DateTime _date;
    private int _minutes;
    /// <summary>
    /// Initializes a new instance of the Activity class.
    /// </summary>
    /// <param name="date">The date of the activity.</param>
    /// <param name="minutes">The duration of the activity in minutes.</param>
    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }
    /// <summary>
    /// Gets the date of the activity.
    /// </summary>
    public DateTime Date => _date;
    /// <summary>
    /// Gets the duration of the activity in minutes.
    /// </summary>
    public int GetMinutes() => _minutes;
    /// <summary>
    /// Gets the distance covered in the activity.
    /// </summary>
    public abstract double GetDistance();
    /// <summary>
    /// Gets the speed during the activity.
    /// </summary>
    public abstract double GetSpeed();
    /// <summary>
    /// Gets the pace of the activity.
    /// </summary>
    public abstract double GetPace();
    /// <summary>
    /// Returns a summary of the activity.
    /// </summary>
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min): Distance {GetDistance():0.##}, Speed: {GetSpeed():0.##}, Pace: {GetPace():0.##}";
    }
}