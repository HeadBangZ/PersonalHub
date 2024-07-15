using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;

namespace PersonalHub.Infrastructure.Data.Contexts
{
    public class PersonalHubDbContext : IdentityDbContext<ApiUser>
    {
        public PersonalHubDbContext(DbContextOptions<PersonalHubDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApiUser>()
                .Property(x => x.Id);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonalHubDbContext).Assembly);
        }
        public DbSet<ApiUser> Users { get; set; }
    }
}
