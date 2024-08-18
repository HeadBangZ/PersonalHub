using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Infrastructure.Data.Configurations
{
    internal class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(f => f.Id);

            //builder.Property(f => f.Id).HasConversion(
            //    featureId => featureId.Id,
            //    value => new FeatureId(value));

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
