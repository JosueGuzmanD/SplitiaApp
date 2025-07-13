namespace Splitia.Domain;

public record SplitEmoji
{
    public static readonly SplitEmoji Vacation = new("🏖️", "Vacation");
    public static readonly SplitEmoji Party = new("🎉", "Party");
    public static readonly SplitEmoji Food = new("🍽️", "Food");
    public static readonly SplitEmoji Home = new("🏠", "Home");
    public static readonly SplitEmoji Travel = new("✈️", "Travel");
    public static readonly SplitEmoji Gift = new("🎁", "Gift");
    public static readonly SplitEmoji Shopping = new("🛍️", "Shopping");
    public static readonly SplitEmoji Sport = new("⚽", "Sport");
    public static readonly SplitEmoji Music = new("🎵", "Music");
    public static readonly SplitEmoji Other = new("🔖", "Other");

    public string Emoji { get; }
    public string Name { get; }

    public SplitEmoji(string emoji, string name)
    {
        Emoji = emoji;
        Name = name;
    }
}