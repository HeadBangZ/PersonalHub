using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Infrastructure.Data.Configurations;

internal class SectionConfiguration : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).HasConversion(
            sectionId => sectionId.Id,
            value => new SectionId(value));

        builder.Property(s => s.SpaceId).HasConversion(
            spaceId => spaceId.Id,
            value => new SpaceId(value));

        builder.HasOne<Space>()
            .WithMany(s => s.Sections)
            .HasForeignKey(s => s.SpaceId)
            .IsRequired();

        builder.Property(s => s.Name)
            .HasMaxLength(75);

        builder.HasMany(s => s.Epics)
            .WithOne()
            .HasForeignKey(e => e.SectionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
