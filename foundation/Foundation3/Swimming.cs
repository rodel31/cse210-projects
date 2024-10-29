public class Swimming : Activity
{
    private int _laps; // Number of laps

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0; // Distance in kilometers

    public override double GetSpeed() => (GetDistance() / (base.GetMinutes() / 60.0));

    public override double GetPace() => (base.GetMinutes() / GetDistance());
}