public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
     public string _mood; // New field for mood tracking

    public void Display()
    {
        Console.WriteLine($"Date: {_date}  - Mood: {_mood}"); 
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}\n");
    }
}