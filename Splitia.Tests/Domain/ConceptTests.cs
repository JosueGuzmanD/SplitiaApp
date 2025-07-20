namespace Splitia.Tests.Domain;

public class ConceptTests
{
    [Fact]
    public void Constructor_WithValidTitleAndDescription_ShouldCreateConcept()
    {
        var title = "Test Title";
        var description = "Test Description";

        var concept = new Concept(title, description);

        concept.Title.ShouldBe(title);
        concept.Description.ShouldBe(description);
    }

    [Fact]
    public void Constructor_WithValidTitleAndNullDescription_ShouldCreateConceptWithEmptyDescription()
    {
        var title = "Test Title";

        var concept = new Concept(title, null);

        concept.Title.ShouldBe(title);
        concept.Description.ShouldBe(string.Empty);
    }

    [Fact]
    public void Constructor_WithValidTitleAndEmptyDescription_ShouldCreateConceptWithEmptyDescription()
    {
        var title = "Test Title";
        var description = "";

        var concept = new Concept(title, description);

        concept.Title.ShouldBe(title);
        concept.Description.ShouldBe(string.Empty);
    }

    [Fact]
    public void Constructor_WithTitleContainingWhitespace_ShouldTrimTitle()
    {
        var title = "  Test Title  ";
        var description = "Test Description";

        var concept = new Concept(title, description);

        concept.Title.ShouldBe("Test Title");
        concept.Description.ShouldBe(description);
    }

    [Fact]
    public void Constructor_WithDescriptionContainingWhitespace_ShouldTrimDescription()
    {
        var title = "Test Title";
        var description = "  Test Description  ";

        var concept = new Concept(title, description);

        concept.Title.ShouldBe(title);
        concept.Description.ShouldBe("Test Description");
    }

    [Fact]
    public void Constructor_WithEmptyTitle_ShouldThrowArgumentException()
    {
        var description = "Test Description";

        var exception = Should.Throw<ArgumentException>(() => 
            new Concept("", description));

        exception.Message.ShouldBe("Title cannot be empty.");
    }

    [Fact]
    public void Constructor_WithNullTitle_ShouldThrowArgumentException()
    {
        var description = "Test Description";

        var exception = Should.Throw<ArgumentException>(() => 
            new Concept(null!, description));

        exception.Message.ShouldBe("Title cannot be empty.");
    }

    [Fact]
    public void Constructor_WithWhitespaceOnlyTitle_ShouldThrowArgumentException()
    {
        var description = "Test Description";

        var exception = Should.Throw<ArgumentException>(() => 
            new Concept("   ", description));

        exception.Message.ShouldBe("Title cannot be empty.");
    }

    [Fact]
    public void Constructor_WithWhitespaceOnlyDescription_ShouldCreateConceptWithEmptyDescription()
    {
        var title = "Test Title";
        var description = "   ";

        var concept = new Concept(title, description);

        concept.Title.ShouldBe(title);
        concept.Description.ShouldBe(string.Empty);
    }

    [Fact]
    public void Equals_WithSameValues_ShouldReturnTrue()
    {
        var concept1 = new Concept("Test Title", "Test Description");
        var concept2 = new Concept("Test Title", "Test Description");

        concept1.ShouldBe(concept2);
        concept1.Equals(concept2).ShouldBeTrue();
        (concept1 == concept2).ShouldBeTrue();
        (concept1 != concept2).ShouldBeFalse();
    }

    [Fact]
    public void Equals_WithDifferentTitles_ShouldReturnFalse()
    {
        var concept1 = new Concept("Test Title 1", "Test Description");
        var concept2 = new Concept("Test Title 2", "Test Description");

        concept1.ShouldNotBe(concept2);
        concept1.Equals(concept2).ShouldBeFalse();
        (concept1 == concept2).ShouldBeFalse();
        (concept1 != concept2).ShouldBeTrue();
    }

    [Fact]
    public void Equals_WithDifferentDescriptions_ShouldReturnFalse()
    {
        var concept1 = new Concept("Test Title", "Test Description 1");
        var concept2 = new Concept("Test Title", "Test Description 2");

        concept1.ShouldNotBe(concept2);
        concept1.Equals(concept2).ShouldBeFalse();
        (concept1 == concept2).ShouldBeFalse();
        (concept1 != concept2).ShouldBeTrue();
    }

    [Fact]
    public void Equals_WithNullDescription_ShouldWork()
    {
        var concept1 = new Concept("Test Title", null);
        var concept2 = new Concept("Test Title", "");

        concept1.ShouldBe(concept2);
        concept1.Equals(concept2).ShouldBeTrue();
        (concept1 == concept2).ShouldBeTrue();
    }

    [Fact]
    public void GetHashCode_WithSameValues_ShouldReturnSameHashCode()
    {
        var concept1 = new Concept("Test Title", "Test Description");
        var concept2 = new Concept("Test Title", "Test Description");

        concept1.GetHashCode().ShouldBe(concept2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_WithDifferentValues_ShouldReturnDifferentHashCode()
    {
        var concept1 = new Concept("Test Title 1", "Test Description");
        var concept2 = new Concept("Test Title 2", "Test Description");

        concept1.GetHashCode().ShouldNotBe(concept2.GetHashCode());
    }

    [Fact]
    public void ToString_ShouldReturnStringRepresentation()
    {
        var concept = new Concept("Test Title", "Test Description");

        var result = concept.ToString();

        result.ShouldContain("Test Title");
        result.ShouldContain("Test Description");
    }

    [Fact]
    public void Title_ShouldBeReadOnly()
    {
        var concept = new Concept("Test Title", "Test Description");

        concept.Title.ShouldBe("Test Title");
    }

    [Fact]
    public void Description_ShouldBeReadOnly()
    {
        var concept = new Concept("Test Title", "Test Description");

        concept.Description.ShouldBe("Test Description");
    }
}
