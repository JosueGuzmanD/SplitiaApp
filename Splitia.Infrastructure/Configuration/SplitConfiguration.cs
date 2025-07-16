using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitia.Domain;

namespace Splitia.Infrastructure.Configuration;

public class SplitConfiguration : IEntityTypeConfiguration<Split>
{
    public void Configure(EntityTypeBuilder<Split> builder)
    {
        builder.HasKey(i => i.Id);

        builder.OwnsOne(e => e.Emoji, emoji =>
        {
            emoji.Property(e => e.Emoji)
                .HasColumnName("Emoji")
                .IsRequired();

            emoji.Property(e => e.Name)
                .HasColumnName("EmojiName")
                .IsRequired();
        });
    }
}