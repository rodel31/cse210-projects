public class Cycling : Activity
{
    private double _speed; // Speed in mph

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => _speed * (base.GetMinutes() / 60.0);

    public override double GetSpeed() => _speed;

    public override double GetPace() => (60.0 / _speed);
}