using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Infrastructure.Data.Configurations;

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

        builder.Property(s => s.Status)
            .HasConversion<string>()
            .HasMaxLength(50);
    }
}
