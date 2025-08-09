public class EternalGoal : Goal
{
    private int _timesCompleted;
    private const int MILESTONE = 10; // NEW: Milestone for achievements

    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        _timesCompleted++;
        
        // NEW: Bonus every 10 completions
        if (_timesCompleted % MILESTONE == 0)
        {
            _isBonusEarned = true;
            return _points * 2; // Double points on milestones
        }
        return _points;
    }

    // NEW: Override bonus points
    public override int GetBonusPoints() => _isBonusEarned ? _points : 0;

    public override bool IsComplete() => false;

    // NEW: Enhanced display with count
    public override string GetDetailsString()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        return $"[∞] {_shortName}: {_description} (completed {_timesCompleted} times)";
    }

    public override string GetStringRepresentation()
        => $"EternalGoal|{_shortName}|{_description}|{_points}|{_timesCompleted}";

    // NEW: For loading
    public void SetTimesCompleted(int times) => _timesCompleted = times;
}