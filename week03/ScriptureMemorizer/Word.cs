using System;

public class Word
{
    private string _text;      // Stores the actual word text
    private bool _isHidden;    // Indicates whether the word is hidden

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false; // Not hidden by default
    }

    // Hides the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Returns whether the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns the display version of the word (either the actual word or underscores)
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Return underscores of same length as word
            string underscores = "";
            for (int i = 0; i < _text.Length; i++)
            {
                underscores += "_";
            }
            return underscores;
        }
        else
        {
            return _text;
        }
    }
}
