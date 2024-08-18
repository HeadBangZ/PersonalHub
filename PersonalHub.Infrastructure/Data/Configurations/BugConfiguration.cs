using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalHub.Domain.Workspace.Entities;

namespace PersonalHub.Infrastructure.Data.Configurations;

internal class BugConfiguration : IEntityTypeConfiguration<Bug>
{
    public void Configure(EntityTypeBuilder<Bug> builder)
    {
        builder.HasKey(b => b.Id);

        //builder.Property(b => b.Id).HasConversion(
        //    bugId => bugId.Value,
        //    value => new BugId(value));

        builder.Property(b => b.Issue)
            .HasMaxLength(100);

        builder.Property(b => b.Severity)
            .HasConversion<string>()
            .HasMaxLength(50);
    }
}
