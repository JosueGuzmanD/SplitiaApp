namespace Splitia.Tests.Domain;

public class SplitTests
{
    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateSplit()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId, Guid.NewGuid() };

        var split = new Split(title, emoji, userId, users);

        split.Title.ShouldBe(title);
        split.Emoji.ShouldBe(emoji);
        split.UserId.ShouldBe(userId);
        split.Users.ShouldBe(users);
        split.Expenditures.ShouldBeEmpty();
        split.Incomes.ShouldBeEmpty();
    }

    [Fact]
    public void Constructor_WithNullTitle_ShouldThrowArgumentException()
    {
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };

        var exception = Should.Throw<ArgumentException>(() => 
            new Split(null!, emoji, userId, users));

        exception.Message.ShouldBe("Title cannot be empty.");
    }

    [Fact]
    public void Constructor_WithEmptyTitle_ShouldThrowArgumentException()
    {
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };

        var exception = Should.Throw<ArgumentException>(() => 
            new Split("", emoji, userId, users));

        exception.Message.ShouldBe("Title cannot be empty.");
    }

    [Fact]
    public void Constructor_WithWhitespaceTitle_ShouldThrowArgumentException()
    {
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };

        var exception = Should.Throw<ArgumentException>(() => 
            new Split("   ", emoji, userId, users));

        exception.Message.ShouldBe("Title cannot be empty.");
    }

    [Fact]
    public void Constructor_WithNullEmoji_ShouldThrowArgumentNullException()
    {
        var title = "Test Split";
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };

        var exception = Should.Throw<ArgumentNullException>(() => 
            new Split(title, null!, userId, users));

        exception.ParamName.ShouldBe("emoji");
    }

    [Fact]
    public void Constructor_WithEmptyUserId_ShouldThrowArgumentException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var users = new List<Guid> { Guid.NewGuid() };

        var exception = Should.Throw<ArgumentException>(() => 
            new Split(title, emoji, Guid.Empty, users));

        exception.Message.ShouldBe("UserId cannot be empty.");
    }

    [Fact]
    public void Constructor_WithNullUsers_ShouldThrowArgumentException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();

        var exception = Should.Throw<ArgumentException>(() => 
            new Split(title, emoji, userId, null!));

        exception.Message.ShouldBe("There must be at least one user in the split.");
    }

    [Fact]
    public void Constructor_WithEmptyUsers_ShouldThrowArgumentException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid>();

        var exception = Should.Throw<ArgumentException>(() => 
            new Split(title, emoji, userId, users));

        exception.Message.ShouldBe("There must be at least one user in the split.");
    }

    [Fact]
    public void SetTitle_WithValidTitle_ShouldSetTitleTrimmed()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);
        var newTitle = "  New Title  ";

        split.SetTitle(newTitle);

        split.Title.ShouldBe("New Title");
    }

    [Fact]
    public void SetTitle_WithEmptyTitle_ShouldThrowArgumentException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);

        var exception = Should.Throw<ArgumentException>(() => 
            split.SetTitle(""));

        exception.Message.ShouldBe("Title cannot be empty.");
    }

    [Fact]
    public void SetTitle_WithNullTitle_ShouldThrowArgumentException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);

        var exception = Should.Throw<ArgumentException>(() => 
            split.SetTitle(null!));

        exception.Message.ShouldBe("Title cannot be empty.");
    }

    [Fact]
    public void SetTitle_WithWhitespaceTitle_ShouldThrowArgumentException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);

        var exception = Should.Throw<ArgumentException>(() => 
            split.SetTitle("   "));

        exception.Message.ShouldBe("Title cannot be empty.");
    }

    [Fact]
    public void SetEmoji_WithValidEmoji_ShouldSetEmoji()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);
        var newEmoji = SplitEmoji.Party;

        split.SetEmoji(newEmoji);

        split.Emoji.ShouldBe(newEmoji);
    }

    [Fact]
    public void SetEmoji_WithNullEmoji_ShouldThrowArgumentNullException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);

        var exception = Should.Throw<ArgumentNullException>(() => 
            split.SetEmoji(null!));

        exception.ParamName.ShouldBe("emoji");
    }

    [Fact]
    public void SetUserId_WithValidGuid_ShouldSetUserId()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);
        var newUserId = Guid.NewGuid();

        split.SetUserId(newUserId);

        split.UserId.ShouldBe(newUserId);
    }

    [Fact]
    public void SetUserId_WithEmptyGuid_ShouldThrowArgumentException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);

        var exception = Should.Throw<ArgumentException>(() => 
            split.SetUserId(Guid.Empty));

        exception.Message.ShouldBe("UserId cannot be empty.");
    }

    [Fact]
    public void SetUsers_WithValidUsers_ShouldSetUsers()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);
        var newUsers = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };

        split.SetUsers(newUsers);

        split.Users.ShouldBe(newUsers);
    }

    [Fact]
    public void SetUsers_WithNullUsers_ShouldThrowArgumentException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);

        var exception = Should.Throw<ArgumentException>(() => 
            split.SetUsers(null!));

        exception.Message.ShouldBe("There must be at least one user in the split.");
    }

    [Fact]
    public void SetUsers_WithEmptyUsers_ShouldThrowArgumentException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);

        var exception = Should.Throw<ArgumentException>(() => 
            split.SetUsers(new List<Guid>()));

        exception.Message.ShouldBe("There must be at least one user in the split.");
    }

    [Fact]
    public void AddExpenditure_WithValidExpenditure_ShouldAddExpenditure()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);
        var expenditure = new Expenditure(Guid.NewGuid(), new Concept("Test", "Test"), 1000, userId);

        split.AddExpenditure(expenditure);

        split.Expenditures.Count.ShouldBe(1);
        split.Expenditures.ShouldContain(expenditure);
    }

    [Fact]
    public void AddExpenditure_WithNullExpenditure_ShouldThrowArgumentNullException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);

        var exception = Should.Throw<ArgumentNullException>(() => 
            split.AddExpenditure(null!));

        exception.ParamName.ShouldBe("expenditure");
    }

    [Fact]
    public void AddIncome_WithValidIncome_ShouldAddIncome()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);
        var income = new Income(Guid.NewGuid(), new Concept("Test", "Test"), 1000, DateTime.UtcNow, userId);

        split.AddIncome(income);

        split.Incomes.Count.ShouldBe(1);
        split.Incomes.ShouldContain(income);
    }

    [Fact]
    public void AddIncome_WithNullIncome_ShouldThrowArgumentNullException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);

        var exception = Should.Throw<ArgumentNullException>(() => 
            split.AddIncome(null!));

        exception.ParamName.ShouldBe("income");
    }

    [Fact]
    public void RemoveExpenditure_WithValidExpenditure_ShouldRemoveExpenditure()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);
        var expenditure = new Expenditure(Guid.NewGuid(), new Concept("Test", "Test"), 1000, userId);
        split.AddExpenditure(expenditure);

        split.RemoveExpenditure(expenditure);

        split.Expenditures.ShouldBeEmpty();
    }

    [Fact]
    public void RemoveExpenditure_WithNullExpenditure_ShouldThrowArgumentNullException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);

        var exception = Should.Throw<ArgumentNullException>(() => 
            split.RemoveExpenditure(null!));

        exception.ParamName.ShouldBe("expenditure");
    }

    [Fact]
    public void RemoveIncome_WithValidIncome_ShouldRemoveIncome()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);
        var income = new Income(Guid.NewGuid(), new Concept("Test", "Test"), 1000, DateTime.UtcNow, userId);
        split.AddIncome(income);

        split.RemoveIncome(income);

        split.Incomes.ShouldBeEmpty();
    }

    [Fact]
    public void RemoveIncome_WithNullIncome_ShouldThrowArgumentNullException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);

        var exception = Should.Throw<ArgumentNullException>(() => 
            split.RemoveIncome(null!));

        exception.ParamName.ShouldBe("income");
    }

    [Fact]
    public void RemoveUser_WithValidUserId_ShouldRemoveUser()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var userToRemove = Guid.NewGuid();
        var users = new List<Guid> { userId, userToRemove };
        var split = new Split(title, emoji, userId, users);

        split.RemoveUser(userToRemove);

        split.Users.Count.ShouldBe(1);
        split.Users.ShouldNotContain(userToRemove);
        split.Users.ShouldContain(userId);
    }

    [Fact]
    public void RemoveUser_WithEmptyGuid_ShouldThrowArgumentException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);

        var exception = Should.Throw<ArgumentException>(() => 
            split.RemoveUser(Guid.Empty));

        exception.Message.ShouldBe("UserId cannot be empty.");
    }

    [Fact]
    public void RemoveUser_WithNonExistentUser_ShouldThrowInvalidOperationException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);
        var nonExistentUser = Guid.NewGuid();

        var exception = Should.Throw<InvalidOperationException>(() => 
            split.RemoveUser(nonExistentUser));

        exception.Message.ShouldBe("User does not exist in the split.");
    }

    [Fact]
    public void RemoveUser_WithLastUser_ShouldThrowInvalidOperationException()
    {
        var title = "Test Split";
        var emoji = SplitEmoji.Vacation;
        var userId = Guid.NewGuid();
        var users = new List<Guid> { userId };
        var split = new Split(title, emoji, userId, users);

        var exception = Should.Throw<InvalidOperationException>(() => 
            split.RemoveUser(userId));

        exception.Message.ShouldBe("Cannot remove the last user from the split.");
    }
}
