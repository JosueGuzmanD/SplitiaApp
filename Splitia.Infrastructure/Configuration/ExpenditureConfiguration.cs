using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitia.Domain;

namespace Splitia.Infrastructure.Configuration;

public class ExpenditureConfiguration : IEntityTypeConfiguration<Expenditure>
{
    public void Configure(EntityTypeBuilder<Expenditure> builder)
    {
        builder.HasKey(e => e.Id);
        builder.OwnsOne(e => e.Concept, concept =>
        {
            concept.Property(c => c.Title)
                .IsRequired();
            concept.Property(c => c.Description)
                .IsRequired(false);
        });
        
        
        
    }
}