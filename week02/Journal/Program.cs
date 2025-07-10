using System;

/*
=== EXCEEDS REQUIREMENTS ===
1. Mood Tracking 😊😢😡😴
   - Added emotional context to entries
   - Helps identify mood patterns over time
2. Excel-Compatible CSV Export
   - Proper CSV formatting with headers
   - Handles special characters in text
   - Can be opened directly in Excel
*/

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        
        Console.WriteLine("Welcome to your Journal App!\n");

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal (TXT or CSV)");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = promptGen.GetRandomPrompt();
                
                Console.WriteLine($"\nPrompt: {newEntry._promptText}");
                Console.WriteLine("How are you feeling? (😊 Happy, 😢 Sad, 😡 Angry, 😐 Neutral)");
                Console.Write("Mood: ");
                newEntry._mood = Console.ReadLine();
                
                Console.WriteLine("Write your entry:");
                Console.Write("> ");
                newEntry._entryText = Console.ReadLine();
                
                journal.AddEntry(newEntry);
                Console.WriteLine("✓ Entry added!\n");
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n=== YOUR JOURNAL ===");
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("\nEnter filename (journal.txt or journal.csv): ");
                string saveFile = Console.ReadLine();
                journal.SaveToFile(saveFile);
            }
            else if (choice == "4")
            {
                Console.Write("\nEnter filename to load: ");
                string loadFile = Console.ReadLine();
                journal.LoadFromFile(loadFile);
            }
            else if (choice == "5")
            {
                Console.WriteLine("\nGoodbye! Keep journaling!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }
}