namespace Splitia.Domain;

public class Expenditure : AuditEntity
{
    public Guid SplitId { get; private set; }
    public Concept Concept { get; private set; }
    public long Amount { get; private set; }
    public Guid UserId { get; private set; }

    public Expenditure(Guid splitId, Concept concept, long amount, Guid userId) : base(userId)
    {
        Concept = null!;
        SetSplitId(splitId);
        SetConcept(concept);
        SetAmount(amount);
        SetUserId(userId);
    }

    public void SetSplitId(Guid splitId)
    {
        if (splitId == Guid.Empty)
            throw new ArgumentException("SplitId cannot be empty.");
        SplitId = splitId;
    }

    public void SetConcept(Concept concept)
    {
        Concept = concept ?? throw new ArgumentNullException(nameof(concept));
    }

    public void SetAmount(long amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");
        Amount = amount;
    }

    public void SetUserId(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId cannot be empty.");
        UserId = userId;
    }
}
