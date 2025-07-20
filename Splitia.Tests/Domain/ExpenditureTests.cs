namespace Splitia.Tests.Domain;

public class ExpenditureTests
{
    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateExpenditure()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var userId = Guid.NewGuid();

        var expenditure = new Expenditure(splitId, concept, amount, userId);

        expenditure.SplitId.ShouldBe(splitId);
        expenditure.Concept.ShouldBe(concept);
        expenditure.Amount.ShouldBe(amount);
        expenditure.UserId.ShouldBe(userId);
    }

    [Fact]
    public void Constructor_WithEmptySplitId_ShouldThrowArgumentException()
    {
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var userId = Guid.NewGuid();

        var exception = Should.Throw<ArgumentException>(() =>
            new Expenditure(Guid.Empty, concept, amount, userId));

        exception.Message.ShouldBe("SplitId cannot be empty.");
    }

    [Fact]
    public void Constructor_WithNullConcept_ShouldThrowArgumentNullException()
    {
        var splitId = Guid.NewGuid();
        var amount = 1000L;
        var userId = Guid.NewGuid();

        var exception = Should.Throw<ArgumentNullException>(() =>
            new Expenditure(splitId, null!, amount, userId));

        exception.ParamName.ShouldBe("concept");
    }

    [Fact]
    public void Constructor_WithZeroAmount_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var userId = Guid.NewGuid();

        var exception = Should.Throw<ArgumentException>(() =>
            new Expenditure(splitId, concept, 0, userId));

        exception.Message.ShouldBe("Amount must be greater than zero.");
    }

    [Fact]
    public void Constructor_WithNegativeAmount_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var userId = Guid.NewGuid();

        var exception = Should.Throw<ArgumentException>(() =>
            new Expenditure(splitId, concept, -100, userId));

        exception.Message.ShouldBe("Amount must be greater than zero.");
    }

    [Fact]
    public void Constructor_WithEmptyUserId_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;

        var exception = Should.Throw<ArgumentException>(() =>
            new Expenditure(splitId, concept, amount, Guid.Empty));

        exception.Message.ShouldBe("UserId cannot be empty.");
    }

    [Fact]
    public void SetSplitId_WithValidGuid_ShouldSetSplitId()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var userId = Guid.NewGuid();
        var expenditure = new Expenditure(splitId, concept, amount, userId);
        var newSplitId = Guid.NewGuid();

        expenditure.SetSplitId(newSplitId);

        expenditure.SplitId.ShouldBe(newSplitId);
    }

    [Fact]
    public void SetSplitId_WithEmptyGuid_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var userId = Guid.NewGuid();
        var expenditure = new Expenditure(splitId, concept, amount, userId);

        var exception = Should.Throw<ArgumentException>(() =>
            expenditure.SetSplitId(Guid.Empty));

        exception.Message.ShouldBe("SplitId cannot be empty.");
    }

    [Fact]
    public void SetConcept_WithValidConcept_ShouldSetConcept()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var userId = Guid.NewGuid();
        var expenditure = new Expenditure(splitId, concept, amount, userId);
        var newConcept = new Concept("New concept", "New description");

        expenditure.SetConcept(newConcept);

        expenditure.Concept.ShouldBe(newConcept);
    }

    [Fact]
    public void SetConcept_WithNullConcept_ShouldThrowArgumentNullException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var userId = Guid.NewGuid();
        var expenditure = new Expenditure(splitId, concept, amount, userId);

        var exception = Should.Throw<ArgumentNullException>(() =>
            expenditure.SetConcept(null!));

        exception.ParamName.ShouldBe("concept");
    }

    [Fact]
    public void SetAmount_WithValidAmount_ShouldSetAmount()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var userId = Guid.NewGuid();
        var expenditure = new Expenditure(splitId, concept, amount, userId);
        var newAmount = 2000L;

        expenditure.SetAmount(newAmount);

        expenditure.Amount.ShouldBe(newAmount);
    }

    [Fact]
    public void SetAmount_WithZeroAmount_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var userId = Guid.NewGuid();
        var expenditure = new Expenditure(splitId, concept, amount, userId);

        var exception = Should.Throw<ArgumentException>(() =>
            expenditure.SetAmount(0));

        exception.Message.ShouldBe("Amount must be greater than zero.");
    }

    [Fact]
    public void SetAmount_WithNegativeAmount_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var userId = Guid.NewGuid();
        var expenditure = new Expenditure(splitId, concept, amount, userId);

        var exception = Should.Throw<ArgumentException>(() =>
            expenditure.SetAmount(-100));

        exception.Message.ShouldBe("Amount must be greater than zero.");
    }

    [Fact]
    public void SetUserId_WithValidGuid_ShouldSetUserId()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var userId = Guid.NewGuid();
        var expenditure = new Expenditure(splitId, concept, amount, userId);
        var newUserId = Guid.NewGuid();

        expenditure.SetUserId(newUserId);

        expenditure.UserId.ShouldBe(newUserId);
    }

    [Fact]
    public void SetUserId_WithEmptyGuid_ShouldThrowArgumentException()
    {
        var splitId = Guid.NewGuid();
        var concept = new Concept("Test concept", "Test description");
        var amount = 1000L;
        var userId = Guid.NewGuid();
        var expenditure = new Expenditure(splitId, concept, amount, userId);

        var exception = Should.Throw<ArgumentException>(() =>
            expenditure.SetUserId(Guid.Empty));

        exception.Message.ShouldBe("UserId cannot be empty.");
    }
}