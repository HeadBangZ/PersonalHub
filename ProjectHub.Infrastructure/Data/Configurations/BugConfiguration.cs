using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Infrastructure.Data.Configurations;

internal class BugConfiguration : IEntityTypeConfiguration<Bug>
{
    public void Configure(EntityTypeBuilder<Bug> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).HasConversion(
            bugId => bugId.Id,
            value => new BugId(value));

        builder.Property(b => b.EpicId).HasConversion(
                epicId => epicId.Id,
                value => new EpicId(value));

        builder.HasOne<Epic>()
            .WithMany(e => e.Bugs)
            .HasForeignKey(b => b.EpicId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(b => b.Issue)
            .HasMaxLength(100);

        builder.Property(b => b.Severity)
            .HasConversion<string>()
            .HasMaxLength(50);
    }
}
