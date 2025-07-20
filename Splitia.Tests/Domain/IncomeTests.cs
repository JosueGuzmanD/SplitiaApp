namespace Splitia.Tests.Domain;

public class IncomeTests
{
    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateIncome()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();

        var income = new Income(splitId, concept, amount, timestamp, userId);

        income.SplitId.ShouldBe(splitId);
        income.Concept.ShouldBe(concept);
        income.Amount.ShouldBe(amount);
        income.Timestamp.ShouldBe(timestamp);
        income.UserId.ShouldBe(userId);
    }

    [Fact]
    public void Constructor_WithEmptySplitId_ShouldThrowArgumentException()
    {
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();

        var exception = Should.Throw<ArgumentException>(() => 
            new Income(Guid.Empty, concept, amount, timestamp, userId));

        exception.Message.ShouldBe("SplitId cannot be empty.");
    }

    [Fact]
    public void Constructor_WithNullConcept_ShouldThrowArgumentNullException()
    {
        var splitId = Guid.NewGuid();
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();

        var exception = Should.Throw<ArgumentNullException>(() => 
            new Income(splitId, null!, amount, timestamp, userId));

        exception.ParamName.ShouldBe("concept");
    }

    [Fact]
    public void Constructor_WithZeroAmount_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();

        var exception = Should.Throw<ArgumentException>(() => 
            new Income(splitId, concept, 0, timestamp, userId));

        exception.Message.ShouldBe("Amount must be greater than zero.");
    }

    [Fact]
    public void Constructor_WithNegativeAmount_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();

        var exception = Should.Throw<ArgumentException>(() => 
            new Income(splitId, concept, -100, timestamp, userId));

        exception.Message.ShouldBe("Amount must be greater than zero.");
    }

    [Fact]
    public void Constructor_WithDefaultTimestamp_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var userId = Guid.NewGuid();

        var exception = Should.Throw<ArgumentException>(() => 
            new Income(splitId, concept, amount, default(DateTime), userId));

        exception.Message.ShouldBe("Timestamp must be a valid date.");
    }

    [Fact]
    public void Constructor_WithEmptyUserId_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;

        var exception = Should.Throw<ArgumentException>(() => 
            new Income(splitId, concept, amount, timestamp, Guid.Empty));

        exception.Message.ShouldBe("UserId cannot be empty.");
    }

    [Fact]
    public void SetSplitId_WithValidGuid_ShouldSetSplitId()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();
        var income = new Income(splitId, concept, amount, timestamp, userId);
        var newSplitId = Guid.NewGuid();

        income.SetSplitId(newSplitId);

        income.SplitId.ShouldBe(newSplitId);
    }

    [Fact]
    public void SetSplitId_WithEmptyGuid_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();
        var income = new Income(splitId, concept, amount, timestamp, userId);

        var exception = Should.Throw<ArgumentException>(() => 
            income.SetSplitId(Guid.Empty));

        exception.Message.ShouldBe("SplitId cannot be empty.");
    }

    [Fact]
    public void SetConcept_WithValidConcept_ShouldSetConcept()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();
        var income = new Income(splitId, concept, amount, timestamp, userId);
        var newConcept = new Concept("New concept", "New description");

        income.SetConcept(newConcept);

        income.Concept.ShouldBe(newConcept);
    }

    [Fact]
    public void SetConcept_WithNullConcept_ShouldThrowArgumentNullException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();
        var income = new Income(splitId, concept, amount, timestamp, userId);

        var exception = Should.Throw<ArgumentNullException>(() => 
            income.SetConcept(null!));

        exception.ParamName.ShouldBe("concept");
    }

    [Fact]
    public void SetAmount_WithValidAmount_ShouldSetAmount()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();
        var income = new Income(splitId, concept, amount, timestamp, userId);
        var newAmount = 2000L;

        income.SetAmount(newAmount);

        income.Amount.ShouldBe(newAmount);
    }

    [Fact]
    public void SetAmount_WithZeroAmount_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();
        var income = new Income(splitId, concept, amount, timestamp, userId);

        var exception = Should.Throw<ArgumentException>(() => 
            income.SetAmount(0));

        exception.Message.ShouldBe("Amount must be greater than zero.");
    }

    [Fact]
    public void SetAmount_WithNegativeAmount_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();
        var income = new Income(splitId, concept, amount, timestamp, userId);

        var exception = Should.Throw<ArgumentException>(() => 
            income.SetAmount(-100));

        exception.Message.ShouldBe("Amount must be greater than zero.");
    }

    [Fact]
    public void SetTimestamp_WithValidTimestamp_ShouldSetTimestamp()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();
        var income = new Income(splitId, concept, amount, timestamp, userId);
        var newTimestamp = DateTime.UtcNow.AddDays(1);

        income.SetTimestamp(newTimestamp);

        income.Timestamp.ShouldBe(newTimestamp);
    }

    [Fact]
    public void SetTimestamp_WithDefaultTimestamp_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();
        var income = new Income(splitId, concept, amount, timestamp, userId);

        var exception = Should.Throw<ArgumentException>(() => 
            income.SetTimestamp(default(DateTime)));

        exception.Message.ShouldBe("Timestamp must be a valid date.");
    }

    [Fact]
    public void SetUserId_WithValidGuid_ShouldSetUserId()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();
        var income = new Income(splitId, concept, amount, timestamp, userId);
        var newUserId = Guid.NewGuid();

        income.SetUserId(newUserId);

        income.UserId.ShouldBe(newUserId);
    }

    [Fact]
    public void SetUserId_WithEmptyGuid_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var timestamp = DateTime.UtcNow;
        var userId = Guid.NewGuid();
        var income = new Income(splitId, concept, amount, timestamp, userId);

        var exception = Should.Throw<ArgumentException>(() => 
            income.SetUserId(Guid.Empty));

        exception.Message.ShouldBe("UserId cannot be empty.");
    }
}
