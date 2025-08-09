public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;
    protected bool _isBonusEarned; // NEW: Tracks bonus achievement

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _isBonusEarned = false;
    }

    // NEW: Virtual method for bonus points (default 0)
    public virtual int GetBonusPoints() => 0;

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();

    // NEW: Added color-coding for goals
    protected virtual ConsoleColor GetDisplayColor()
    {
        return IsComplete() ? ConsoleColor.Green : ConsoleColor.White;
    }

    // NEW: Standardized name access
    public string GetShortName() => _shortName;
}