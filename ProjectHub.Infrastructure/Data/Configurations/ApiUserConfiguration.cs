using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectHub.Domain.User.Entities;

namespace ProjectHub.Infrastructure.Data.Configurations
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