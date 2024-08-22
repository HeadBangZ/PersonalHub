using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalHub.Domain.User.Entities;
using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Infrastructure.Data.Configurations;

internal class EpicConfiguration : IEntityTypeConfiguration<Epic>
{
    public void Configure(EntityTypeBuilder<Epic> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasConversion(
            epicId => epicId.Id,
            value => new EpicId(value));

        //builder.Property(e => e.SectionId).HasConversion(
        //    sectionId => sectionId.Id,
        //    value => new SectionId(value));

        //builder.HasOne<Section>()
        //    .WithMany(s => s.Epics)
        //    .HasForeignKey(e => e.SectionId)
        //    .IsRequired();

        builder.HasOne<ApiUser>()
            .WithMany()
            .HasForeignKey(e => e.AssignedToUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ApiUser>()
            .WithMany()
            .HasForeignKey(e => e.ReviewerUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(a => a.Name)
            .HasMaxLength(100);

        builder.Property(e => e.Status)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(e => e.Tags)
            .HasConversion(
                tags => string.Join(';', tags),
                tagString => tagString.Split(';', StringSplitOptions.RemoveEmptyEntries)
            )
            .HasMaxLength(1000);

        builder.HasMany(e => e.Features)
            .WithOne()
            .HasForeignKey(f => f.EpicId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Bugs)
            .WithOne()
            .HasForeignKey(b => b.EpicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
