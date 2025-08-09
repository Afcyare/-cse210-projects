public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private readonly int _target;
    private readonly int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            if (_amountCompleted == _target)
            {
                _isBonusEarned = true;
                return _points + _bonus;
            }
            return _points;
        }
        return 0;
    }

    // NEW: Override bonus points
    public override int GetBonusPoints() => _isBonusEarned ? _bonus : 0;

    public override bool IsComplete() => _amountCompleted >= _target;

    // NEW: Color-coded progress bar
    public override string GetDetailsString()
    {
        Console.ForegroundColor = GetDisplayColor();
        string progressBar = "";
        for (int i = 0; i < _target; i++)
            progressBar += i < _amountCompleted ? "■" : "□";
        
        return $"[{(_amountCompleted >= _target ? "X" : " ")}] {_shortName}: {_description} " +
               $"\n    Progress: [{progressBar}] {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
        => $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";

    // NEW: For loading
    public void SetAmountCompleted(int amount) => _amountCompleted = amount;
}