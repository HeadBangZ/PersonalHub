using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Infrastructure.Data.Configurations;

internal class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasConversion(
            activityId => activityId.Id,
            value => new ActivityId(value));

        builder.Property(a => a.FeatureId).HasConversion(
            featureId => featureId.Id,
            value => new FeatureId(value));

        builder.HasOne<Feature>()
            .WithMany(f => f.Activities)
            .HasForeignKey(a => a.FeatureId)
            .IsRequired();

        builder.Property(a => a.Name)
            .HasMaxLength(100);
    }
}
