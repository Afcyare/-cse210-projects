using System;

// Extras implemented:
// - Used a verse from the Qur’an (Surah Maryam 19:88–92).
// - Randomly hides only visible words (stretch requirement).
// - Replaced Console.Clear() with visual separator for better compatibility.
// Author: Farhan Yared | CSE 210 Week 03 Assignment

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Surah Maryam", 19, 88, 92);

        string verseText = "And they say, 'The Most Merciful has taken [for Himself] a son.' You have done an atrocious thing. The heavens almost rupture therefrom and the earth splits open and the mountains collapse in devastation. That they attribute to the Most Merciful a son. It is not appropriate for the Most Merciful that He should take a son.";

        Scripture scripture = new Scripture(reference, verseText);

        while (!scripture.IsCompletelyHidden())
        {
            // Console.WriteLine("\n" + new string('-', 70) + "\n");
            Console.Clear();
            scripture.ShowSentence();

            Console.Write("Press Enter to hide more words or type 'quit' to exit: ");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords(3); // Hide 3 words each round
        }

        // Console.WriteLine("\n" + new string('-', 70) + "\n");
        Console.Clear();
        Console.WriteLine("Final scripture (all words hidden or user exited):");
        scripture.ShowSentence();
    }
}
