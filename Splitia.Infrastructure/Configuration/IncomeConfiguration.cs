using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitia.Domain;

namespace Splitia.Infrastructure.Configuration;

public class IncomeConfiguration : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.HasKey(i => i.Id);
        builder.OwnsOne(i => i.Concept, concept =>
        {
            concept.Property(c => c.Title)
                .IsRequired();
            concept.Property(c => c.Description)
                .IsRequired(false);
        });
    }
}