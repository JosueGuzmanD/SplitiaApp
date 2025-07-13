namespace Splitia.Domain;

public sealed record Concept
{
    public string Title { get; }
    public string Description { get; }

    public Concept(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");
        Title = title.Trim();
        Description = description?.Trim() ?? string.Empty;
    }
}