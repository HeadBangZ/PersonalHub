using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalHub.Domain.Workspace.Entities;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Infrastructure.Data.Configurations;

internal class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasKey(a => a.Id);

        //builder.Property(a => a.Id).HasConversion(
        //    activityId => activityId.Value,
        //    value => new ActivityId(value));

        builder.HasOne<Feature>()
            .WithMany(f => f.Activities)
            .HasForeignKey(a => a.FeatureId)
            .IsRequired();

        builder.Property(a => a.Name)
            .HasMaxLength(100);
    }
}
