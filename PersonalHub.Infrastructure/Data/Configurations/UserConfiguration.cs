using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApiUser>
    {
        private readonly IConfiguration _configuration;

        public UserConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            var id = _configuration["UserAuth:UserId"];
            var firstName = _configuration["UserAuth:FirstName"];
            var lastName = _configuration["UserAuth:LastName"];
            var email = _configuration["UserAuth:Email"];

            var user = new ApiUser
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                EmailConfirmed = true,
                NormalizedUserName = email.ToUpper(),
                NormalizedEmail = email.ToUpper()
            };

            PasswordHasher<ApiUser> ph = new PasswordHasher<ApiUser>();
            user.PasswordHash = ph.HashPassword(user, _configuration["UserAuth:Pwd"]);

            builder.HasData(user);
        }
    }
}
