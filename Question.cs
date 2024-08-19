public abstract class Question
{
    public string Text { get; set; }

    public Question(string text)
    {
        Text = text;
    }
    public abstract bool IsCorrect(string answer);
}