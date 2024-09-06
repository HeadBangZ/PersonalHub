using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalHub.Domain.User.Entities;

namespace PersonalHub.Infrastructure.Data.Configurations
{
    internal class ApiUserConfiguration : IEntityTypeConfiguration<ApiUser>
    {
        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ComplexProperty(u => u.Information)
                .IsRequired();
        }
    }
}