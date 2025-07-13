namespace Splitia.Domain;

public class Split : AuditEntity
{
    public string Title { get; private set; }
    public SplitEmoji? Emoji { get; private set; }
    public Guid UserId { get; private set; }
    public List<Guid> Users { get; private set; }
    public List<Expenditure> Expenditures { get; private set; }
    public List<Income> Incomes { get; private set; }

    public Split(string title, SplitEmoji? emoji, Guid userId, List<Guid> users) : base(userId)
    {
        Expenditures = new List<Expenditure>();
        Incomes = new List<Income>();
        
        SetTitle(title);
        SetEmoji(emoji);
        SetUserId(userId);
        SetUsers(users);
    }

    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");
        Title = title.Trim();
    }

    public void SetEmoji(SplitEmoji emoji)
    {
        Emoji = emoji ?? throw new ArgumentNullException(nameof(emoji));
    }

    public void SetUserId(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId cannot be empty.");
        UserId = userId;
    }

    public void SetUsers(List<Guid> users)
    {
        if (users == null || users.Count == 0)
            throw new ArgumentException("There must be at least one user in the split.");
        Users = users;
    }

    public void AddExpenditure(Expenditure expenditure)
    {
        if (expenditure == null)
            throw new ArgumentNullException(nameof(expenditure));
        Expenditures.Add(expenditure);
    }

    public void AddIncome(Income income)
    {
        if (income == null)
            throw new ArgumentNullException(nameof(income));
        Incomes.Add(income);
    }

    public void RemoveExpenditure(Expenditure expenditure)
    {
        if (expenditure == null)
            throw new ArgumentNullException(nameof(expenditure));
        Expenditures.Remove(expenditure);
    }

    public void RemoveIncome(Income income)
    {
        if (income == null)
            throw new ArgumentNullException(nameof(income));
        Incomes.Remove(income);
    }

    public void RemoveUser(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId cannot be empty.");
        if (!Users.Contains(userId))
            throw new InvalidOperationException("User does not exist in the split.");
        if (Users.Count == 1)
            throw new InvalidOperationException("Cannot remove the last user from the split.");
        Users.Remove(userId);
    }
}