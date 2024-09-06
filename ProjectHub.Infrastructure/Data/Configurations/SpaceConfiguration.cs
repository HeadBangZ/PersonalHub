using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Infrastructure.Data.Configurations;

internal class SpaceConfiguration : IEntityTypeConfiguration<Space>
{
    public void Configure(EntityTypeBuilder<Space> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).HasConversion(
            spaceId => spaceId.Id,
            value => new SpaceId(value));

        builder.Property(s => s.Name)
            .HasMaxLength(100);

        builder.HasIndex(s => s.Name);

        builder.Property(s => s.State)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.HasMany(s => s.Sections)
            .WithOne()
            .HasForeignKey(s => s.SpaceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
