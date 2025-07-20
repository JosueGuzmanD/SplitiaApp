using System.Diagnostics.CodeAnalysis;

namespace Splitia.Domain;

public sealed class SplitEmoji
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

    [ExcludeFromCodeCoverage]
    private SplitEmoji()
    {
    }

    private SplitEmoji(string emoji, string name)
    {
        Emoji = emoji;
        Name = name;
    }

    public static IEnumerable<SplitEmoji> List()
    {
        yield return Vacation;
        yield return Party;
        yield return Food;
        yield return Home;
        yield return Travel;
        yield return Gift;
        yield return Shopping;
        yield return Sport;
        yield return Music;
        yield return Other;
    }

    public override string ToString() => $"{Emoji} {Name}";
}