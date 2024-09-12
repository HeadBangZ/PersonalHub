using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectHub.Domain.User.Entities;
using ProjectHub.Domain.User.ValueObjects;

namespace ProjectHub.Infrastructure.Data.Configurations;

internal class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(up => up.Id);

        builder.Property(b => b.Id).HasConversion(
            userProfileId => userProfileId.Id,
            value => new UserProfileId(value));

        builder.ComplexProperty(up => up.Information).IsRequired();

        builder.ComplexProperty(up => up.AddressInfo).IsRequired();

        builder.HasOne(up => up.ApiUser)
            .WithOne(u => u.UserProfile)
            .HasForeignKey<UserProfile>(up => up.ApiUserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(true);
    }
}
