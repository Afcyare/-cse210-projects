public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _isComplete;

    // NEW: Color-coded display
    public override string GetDetailsString()
    {
        Console.ForegroundColor = GetDisplayColor();
        return $"[{(_isComplete ? "X" : " ")}] {_shortName}: {_description}";
    }

    public override string GetStringRepresentation()
        => $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";

    // NEW: Achievement tracking
    public void SetCompletion(bool complete) => _isComplete = complete;
}