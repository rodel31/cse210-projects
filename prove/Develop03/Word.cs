public class Word
{
    private string _text;
    private bool _isHidden;
    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
    // Hide the word
    public void Hide()
    {
        _isHidden = true;
    }
    // Show the word
    public void Show()
    {
        _isHidden = false;
    }
    // Check if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }
    // Get the display text of the word
    public string GetDisplayText()
    {
        return _isHidden ? "____" : _text;
    }
}
