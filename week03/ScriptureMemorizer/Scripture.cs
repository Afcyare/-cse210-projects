using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;       // Reference to the verse (book, chapter, verse)
    private List<Word> _words;          // List of words in the verse

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the verse into words manually
        string[] splitWords = text.Split(' ');

        // Add each word to the _words list
        foreach (string word in splitWords)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
    }

    // Hides a given number of random visible words
    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide)
        {
            List<Word> visibleWords = new List<Word>();

            // Collect all visible words
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    visibleWords.Add(word);
                }
            }

            // Stop if no visible words left
            if (visibleWords.Count == 0)
            {
                break;
            }

            // Pick a random visible word to hide
            int randomIndex = rand.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            hiddenCount++;
        }
    }

    // Shows the scripture as a string with visible/hidden words
    public void ShowSentence()
    {
        Console.WriteLine(_reference.GetDisplayText());
        Console.WriteLine();

        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }

        Console.WriteLine("\n");
    }

    // Check if all words are hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
