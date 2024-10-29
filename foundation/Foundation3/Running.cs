public class Running : Activity
{
    private double _distance; // Distance in miles
    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }
    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / (base.GetMinutes() / 60.0));
    public override double GetPace() => (base.GetMinutes() / _distance);
}