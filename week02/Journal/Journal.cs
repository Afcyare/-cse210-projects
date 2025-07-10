using System.IO;
using System.Linq;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Enhanced Save with CSV support
    public void SaveToFile(string file)
    {
        try
        {
            if (file.EndsWith(".csv"))
            {
                SaveToCSV(file);
            }
            else
            {
                SaveToTXT(file);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving: {ex.Message}");
        }
    }

    private void SaveToTXT(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._mood}|{entry._promptText}|{entry._entryText}");
            }
        }
        Console.WriteLine($"✓ Saved {_entries.Count} entries to {file}");
    }

    private void SaveToCSV(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine("Date,Mood,Prompt,Response"); // CSV header
            foreach (Entry entry in _entries)
            {
                string safePrompt = EscapeCsv(entry._promptText);
                string safeResponse = EscapeCsv(entry._entryText);
                writer.WriteLine($"{entry._date},{entry._mood},{safePrompt},{safeResponse}");
            }
        }
        Console.WriteLine($"✓ Saved {_entries.Count} entries as Excel-compatible CSV");
    }

    private string EscapeCsv(string input)
    {
        if (input.Contains(",") || input.Contains("\"") || input.Contains("\n"))
        {
            return $"\"{input.Replace("\"", "\"\"")}\"";
        }
        return input;
    }

    public void LoadFromFile(string file)
    {
        try
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(file);

            if (file.EndsWith(".csv") && lines.Length > 0)
            {
                // Skip header row for CSV
                lines = lines.Skip(1).ToArray();
            }

            foreach (string line in lines)
            {
                string[] parts = line.Split('|'); // Works for both TXT and CSV
                if (parts.Length >= 4)
                {
                    Entry loadedEntry = new Entry
                    {
                        _date = parts[0],
                        _mood = parts[1],
                        _promptText = parts[2],
                        _entryText = parts[3]
                    };
                    _entries.Add(loadedEntry);
                }
            }
            Console.WriteLine($"✓ Loaded {_entries.Count} entries from {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading: {ex.Message}");
        }
    }
}