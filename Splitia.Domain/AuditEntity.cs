using System.Diagnostics.CodeAnalysis;

namespace Splitia.Domain;

public abstract class AuditEntity
{
    public Guid Id { get; private set; } 
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
    public Guid CreatedBy { get; protected set; }
    public Guid? UpdatedBy { get; protected set; }
    public bool IsDeleted { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }
    [ExcludeFromCodeCoverage]
    protected AuditEntity()
    {
        
    }
    protected AuditEntity(Guid createdBy)
    {
        CreatedAt = DateTime.UtcNow;
        CreatedBy = createdBy;
    }

    public void SetAsDeleted()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
    }
    

    public void SetUpdated(Guid updatedBy)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = updatedBy;
    }
}
