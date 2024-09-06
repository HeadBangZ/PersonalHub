using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Infrastructure.Data.Configurations
{
    internal class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).HasConversion(
                featureId => featureId.Id,
                value => new FeatureId(value));

            builder.Property(f => f.EpicId).HasConversion(
                    epicId => epicId.Id,
                    value => new EpicId(value));

            builder.HasOne<Epic>()
                .WithMany(e => e.Features)
                .HasForeignKey(f => f.EpicId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(f => f.Name)
                .HasMaxLength(100);

            builder.HasMany(f => f.Activities)
                .WithOne()
                .HasForeignKey(a => a.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(f => f.Importance)
                .HasConversion<string>()
                .HasMaxLength(50);
        }
    }
}
