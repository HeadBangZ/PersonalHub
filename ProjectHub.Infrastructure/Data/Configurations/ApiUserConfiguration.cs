using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectHub.Domain.User.Entities;
using ProjectHub.Domain.User.ValueObjects;

namespace ProjectHub.Infrastructure.Data.Configurations
{
    internal class ApiUserConfiguration : IEntityTypeConfiguration<ApiUser>
    {
        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(b => b.UserProfileId).HasConversion(
                userProfileId => userProfileId.Id,
                value => new UserProfileId(value));

            builder.HasOne(u => u.UserProfile)
                .WithOne(up => up.ApiUser)
                .HasForeignKey<ApiUser>(u => u.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}