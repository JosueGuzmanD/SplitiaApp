namespace Splitia.Tests.Domain;

public class SplitEmojiTests
{
    [Fact]
    public void StaticInstances_ShouldHaveCorrectEmojiAndName()
    {
        SplitEmoji.Vacation.Emoji.ShouldBe("🏖️");
        SplitEmoji.Vacation.Name.ShouldBe("Vacation");
        
        SplitEmoji.Party.Emoji.ShouldBe("🎉");
        SplitEmoji.Party.Name.ShouldBe("Party");
        
        SplitEmoji.Food.Emoji.ShouldBe("🍽️");
        SplitEmoji.Food.Name.ShouldBe("Food");
        
        SplitEmoji.Home.Emoji.ShouldBe("🏠");
        SplitEmoji.Home.Name.ShouldBe("Home");
        
        SplitEmoji.Travel.Emoji.ShouldBe("✈️");
        SplitEmoji.Travel.Name.ShouldBe("Travel");
        
        SplitEmoji.Gift.Emoji.ShouldBe("🎁");
        SplitEmoji.Gift.Name.ShouldBe("Gift");
        
        SplitEmoji.Shopping.Emoji.ShouldBe("🛍️");
        SplitEmoji.Shopping.Name.ShouldBe("Shopping");
        
        SplitEmoji.Sport.Emoji.ShouldBe("⚽");
        SplitEmoji.Sport.Name.ShouldBe("Sport");
        
        SplitEmoji.Music.Emoji.ShouldBe("🎵");
        SplitEmoji.Music.Name.ShouldBe("Music");
        
        SplitEmoji.Other.Emoji.ShouldBe("🔖");
        SplitEmoji.Other.Name.ShouldBe("Other");
    }

    [Fact]
    public void List_ShouldReturnAllSplitEmojis()
    {
        var list = SplitEmoji.List().ToList();

        list.Count.ShouldBe(10);
        list.ShouldContain(SplitEmoji.Vacation);
        list.ShouldContain(SplitEmoji.Party);
        list.ShouldContain(SplitEmoji.Food);
        list.ShouldContain(SplitEmoji.Home);
        list.ShouldContain(SplitEmoji.Travel);
        list.ShouldContain(SplitEmoji.Gift);
        list.ShouldContain(SplitEmoji.Shopping);
        list.ShouldContain(SplitEmoji.Sport);
        list.ShouldContain(SplitEmoji.Music);
        list.ShouldContain(SplitEmoji.Other);
    }

    [Fact]
    public void List_ShouldReturnItemsInCorrectOrder()
    {
        var list = SplitEmoji.List().ToList();

        list[0].ShouldBe(SplitEmoji.Vacation);
        list[1].ShouldBe(SplitEmoji.Party);
        list[2].ShouldBe(SplitEmoji.Food);
        list[3].ShouldBe(SplitEmoji.Home);
        list[4].ShouldBe(SplitEmoji.Travel);
        list[5].ShouldBe(SplitEmoji.Gift);
        list[6].ShouldBe(SplitEmoji.Shopping);
        list[7].ShouldBe(SplitEmoji.Sport);
        list[8].ShouldBe(SplitEmoji.Music);
        list[9].ShouldBe(SplitEmoji.Other);
    }

    [Fact]
    public void ToString_ShouldReturnEmojiAndName()
    {
        SplitEmoji.Vacation.ToString().ShouldBe("🏖️ Vacation");
        SplitEmoji.Party.ToString().ShouldBe("🎉 Party");
        SplitEmoji.Food.ToString().ShouldBe("🍽️ Food");
        SplitEmoji.Home.ToString().ShouldBe("🏠 Home");
        SplitEmoji.Travel.ToString().ShouldBe("✈️ Travel");
        SplitEmoji.Gift.ToString().ShouldBe("🎁 Gift");
        SplitEmoji.Shopping.ToString().ShouldBe("🛍️ Shopping");
        SplitEmoji.Sport.ToString().ShouldBe("⚽ Sport");
        SplitEmoji.Music.ToString().ShouldBe("🎵 Music");
        SplitEmoji.Other.ToString().ShouldBe("🔖 Other");
    }

    [Fact]
    public void StaticInstances_ShouldBeSameReference()
    {
        var vacation1 = SplitEmoji.Vacation;
        var vacation2 = SplitEmoji.Vacation;

        vacation1.ShouldBeSameAs(vacation2);
    }

    [Fact]
    public void Emoji_ShouldBeReadOnly()
    {
        var emoji = SplitEmoji.Vacation;
        
        emoji.Emoji.ShouldBe("🏖️");
    }

    [Fact]
    public void Name_ShouldBeReadOnly()
    {
        var emoji = SplitEmoji.Vacation;
        
        emoji.Name.ShouldBe("Vacation");
    }

    [Fact]
    public void List_CalledMultipleTimes_ShouldReturnSameValues()
    {
        var list1 = SplitEmoji.List().ToList();
        var list2 = SplitEmoji.List().ToList();

        list1.Count.ShouldBe(list2.Count);
        for (int i = 0; i < list1.Count; i++)
        {
            list1[i].ShouldBeSameAs(list2[i]);
        }
    }

    [Fact]
    public void AllStaticInstances_ShouldHaveUniqueEmojis()
    {
        var emojis = SplitEmoji.List().Select(e => e.Emoji).ToList();
        var uniqueEmojis = emojis.Distinct().ToList();

        emojis.Count.ShouldBe(uniqueEmojis.Count);
    }

    [Fact]
    public void AllStaticInstances_ShouldHaveUniqueNames()
    {
        var names = SplitEmoji.List().Select(e => e.Name).ToList();
        var uniqueNames = names.Distinct().ToList();

        names.Count.ShouldBe(uniqueNames.Count);
    }
}
