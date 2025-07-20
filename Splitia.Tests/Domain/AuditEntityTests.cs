namespace Splitia.Tests.Domain;

public class AuditEntityTests
{
    private class TestableAuditEntity : AuditEntity
    {
        public TestableAuditEntity() : base() { }
        public TestableAuditEntity(Guid createdBy) : base(createdBy) { }
    }

    [Fact]
    public void Constructor_WithoutParameters_ShouldInitializeWithDefaultValues()
    {
        var entity = new TestableAuditEntity();

        entity.Id.ShouldBe(Guid.Empty);
        entity.CreatedAt.ShouldBe(default(DateTime));
        entity.UpdatedAt.ShouldBeNull();
        entity.CreatedBy.ShouldBe(Guid.Empty);
        entity.UpdatedBy.ShouldBeNull();
        entity.IsDeleted.ShouldBeFalse();
        entity.DeletedAt.ShouldBeNull();
    }

    [Fact]
    public void Constructor_WithCreatedBy_ShouldInitializeCreatedProperties()
    {
        var createdBy = Guid.NewGuid();
        var beforeCreation = DateTime.UtcNow;

        var entity = new TestableAuditEntity(createdBy);

        var afterCreation = DateTime.UtcNow;

        entity.Id.ShouldBe(Guid.Empty);
        entity.CreatedAt.ShouldBeGreaterThanOrEqualTo(beforeCreation);
        entity.CreatedAt.ShouldBeLessThanOrEqualTo(afterCreation);
        entity.UpdatedAt.ShouldBeNull();
        entity.CreatedBy.ShouldBe(createdBy);
        entity.UpdatedBy.ShouldBeNull();
        entity.IsDeleted.ShouldBeFalse();
        entity.DeletedAt.ShouldBeNull();
    }

    [Fact]
    public void SetAsDeleted_ShouldSetIsDeletedToTrueAndSetDeletedAt()
    {
        var entity = new TestableAuditEntity(Guid.NewGuid());
        var beforeDeletion = DateTime.UtcNow;

        entity.SetAsDeleted();

        var afterDeletion = DateTime.UtcNow;

        entity.IsDeleted.ShouldBeTrue();
        entity.DeletedAt.ShouldNotBeNull();
        entity.DeletedAt.Value.ShouldBeGreaterThanOrEqualTo(beforeDeletion);
        entity.DeletedAt.Value.ShouldBeLessThanOrEqualTo(afterDeletion);
    }

    [Fact]
    public void SetUpdated_ShouldSetUpdatedAtAndUpdatedBy()
    {
        var entity = new TestableAuditEntity(Guid.NewGuid());
        var updatedBy = Guid.NewGuid();
        var beforeUpdate = DateTime.UtcNow;

        entity.SetUpdated(updatedBy);

        var afterUpdate = DateTime.UtcNow;

        entity.UpdatedAt.ShouldNotBeNull();
        entity.UpdatedAt.Value.ShouldBeGreaterThanOrEqualTo(beforeUpdate);
        entity.UpdatedAt.Value.ShouldBeLessThanOrEqualTo(afterUpdate);
        entity.UpdatedBy.ShouldBe(updatedBy);
    }

    [Fact]
    public void SetUpdated_CalledMultipleTimes_ShouldUpdateToLatestValues()
    {
        var entity = new TestableAuditEntity(Guid.NewGuid());
        var firstUpdater = Guid.NewGuid();
        var secondUpdater = Guid.NewGuid();

        entity.SetUpdated(firstUpdater);
        var firstUpdateTime = entity.UpdatedAt;

        Thread.Sleep(1);

        entity.SetUpdated(secondUpdater);

        entity.UpdatedAt.ShouldNotBeNull();
        firstUpdateTime.ShouldNotBeNull();
        entity.UpdatedAt.Value.ShouldBeGreaterThan(firstUpdateTime.Value);
        entity.UpdatedBy.ShouldBe(secondUpdater);
    }
}
