using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _experience;
    private int _level;
    private List<string> _achievements;
    private const int XP_PER_LEVEL = 1000;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _experience = 0;
        _level = 1;
        _achievements = new List<string>();
    }

    public void Start()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n=== Eternal Quest Program ===");
        Console.ResetColor();

        while (true)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. View Achievements");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    DisplayAchievements();
                    break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nCurrent Score: {_score} points");
        Console.WriteLine($"Level: {_level} (XP: {_experience}/{_level * XP_PER_LEVEL})");
        Console.ResetColor();
        Console.WriteLine("----------------------------");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet!");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet!");
            return;
        }

        Console.WriteLine("\nGoal Details:");
        Console.WriteLine("----------------------------");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
            Console.WriteLine("----------------------------");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nSelect goal type:");
        Console.WriteLine("1. Simple Goal (One-time)");
        Console.WriteLine("2. Eternal Goal (Repeating)");
        Console.WriteLine("3. Checklist Goal (Requires multiple completions)");

        int choice = GetValidIntInput("Enter your choice (1-3): ", 1, 3);

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter description: ");
        string desc = Console.ReadLine();

        int points = GetValidIntInput("Enter point value: ", 1);

        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case 3:
                int target = GetValidIntInput("Enter target completions: ", 1);
                int bonus = GetValidIntInput("Enter bonus points: ", 1);
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Goal added successfully!");
        Console.ResetColor();

        // Check for achievement
        if (_goals.Count == 5 && !_achievements.Contains("Goal Setter"))
        {
            _achievements.Add("Goal Setter");
            ShowAchievement("Goal Setter", "Created 5 goals");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        ListGoalNames();
        int index = GetValidIntInput("Select goal to complete: ", 1, _goals.Count);

        Goal selected = _goals[index - 1];
        int pointsEarned = selected.RecordEvent();
        _score += pointsEarned;
        _experience += pointsEarned;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nEvent recorded! Earned {pointsEarned} points.");
        Console.ResetColor();

        if (selected is ChecklistGoal checklist && checklist.IsComplete())
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"★ Bonus achieved! Total points for this goal: {pointsEarned} ★");
            Console.ResetColor();
        }

        CheckLevelUp();
        CheckGoalAchievements();
    }

    private void CheckLevelUp()
    {
        while (_experience >= _level * XP_PER_LEVEL)
        {
            _experience -= _level * XP_PER_LEVEL;
            _level++;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n★ LEVEL UP! You reached level {_level}! ★");
            Console.ResetColor();

            // Award achievement every 5 levels
            if (_level % 5 == 0 && !_achievements.Contains($"Level {_level}"))
            {
                string achievement = $"Level {_level}";
                _achievements.Add(achievement);
                ShowAchievement(achievement, $"Reached level {_level}");
            }
        }
    }

    private void CheckGoalAchievements()
    {
        int completedGoals = _goals.FindAll(g => g.IsComplete()).Count;

        if (completedGoals >= 3 && !_achievements.Contains("Goal Getter"))
        {
            _achievements.Add("Goal Getter");
            ShowAchievement("Goal Getter", "Completed 3 goals");
        }

        if (completedGoals >= 10 && !_achievements.Contains("Goal Master"))
        {
            _achievements.Add("Goal Master");
            ShowAchievement("Goal Master", "Completed 10 goals");
        }
    }

    private void ShowAchievement(string title, string description)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n=================================");
        Console.WriteLine($"★ ACHIEVEMENT UNLOCKED: {title} ★");
        Console.WriteLine(description);
        Console.WriteLine("=================================");
        Console.ResetColor();
    }

    public void DisplayAchievements()
    {
        if (_achievements.Count == 0)
        {
            Console.WriteLine("No achievements earned yet!");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nYour Achievements:");
        Console.WriteLine("----------------------------");
        foreach (string achievement in _achievements)
        {
            Console.WriteLine($"★ {achievement}");
        }
        Console.WriteLine("----------------------------");
        Console.ResetColor();
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                // Save progress data
                outputFile.WriteLine(_score);
                outputFile.WriteLine(_experience);
                outputFile.WriteLine(_level);
                outputFile.WriteLine(string.Join("|", _achievements));

                // Save goals
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Goals saved successfully!");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error saving goals: {ex.Message}");
            Console.ResetColor();
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("File not found.");
            Console.ResetColor();
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            
            // Load progress data
            _score = int.Parse(lines[0]);
            _experience = int.Parse(lines[1]);
            _level = int.Parse(lines[2]);
            _achievements = new List<string>(lines[3].Split('|'));

            // Load goals
            _goals = new List<Goal>();
            for (int i = 4; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                
                switch (parts[0])
                {
                    case "SimpleGoal":
                        var simple = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (bool.Parse(parts[4])) simple.RecordEvent();
                        _goals.Add(simple);
                        break;

                    case "EternalGoal":
                        var eternal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        for (int j = 0; j < int.Parse(parts[4]); j++) eternal.RecordEvent();
                        _goals.Add(eternal);
                        break;

                    case "ChecklistGoal":
                        var checklist = new ChecklistGoal(
                            parts[1], parts[2], int.Parse(parts[3]),
                            int.Parse(parts[5]), int.Parse(parts[4]));
                        for (int j = 0; j < int.Parse(parts[6]); j++) checklist.RecordEvent();
                        _goals.Add(checklist);
                        break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Goals loaded successfully!");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error loading goals: {ex.Message}");
            Console.ResetColor();
            _goals = new List<Goal>();
            _score = 0;
            _experience = 0;
            _level = 1;
            _achievements = new List<string>();
        }
    }

    private int GetValidIntInput(string prompt, int min = 1, int max = int.MaxValue)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
            {
                return value;
            }
            Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
        }
    }
}