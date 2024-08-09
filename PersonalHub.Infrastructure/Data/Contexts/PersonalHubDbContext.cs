using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonalHub.Domain.User.Entities;
using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Infrastructure.Data.Configurations;

namespace PersonalHub.Infrastructure.Data.Contexts
{
    public class PersonalHubDbContext : IdentityDbContext<ApiUser>
    {
        private readonly IConfiguration _configuration;

        public PersonalHubDbContext(DbContextOptions<PersonalHubDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<ApiUser> Users => Set<ApiUser>();
        public DbSet<Feature> Features => Set<Feature>();
        public DbSet<Activity> Activities => Set<Activity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration(_configuration));
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration(_configuration));

            // ApiUser
            modelBuilder.Entity<ApiUser>()
                .ComplexProperty(u => u.Information).IsRequired();

            // Features
            modelBuilder.Entity<Feature>()
                .HasMany(u => u.Activities)
                .WithOne()
                .HasForeignKey(s => s.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);

            // Activites
            modelBuilder.Entity<Activity>()
                .Property(s => s.FeatureId);

            modelBuilder.Entity<Activity>()
                .Property(s => s.ActivityItemType)
                .HasConversion<string>();

            modelBuilder.Entity<Activity>()
                .Property(s => s.ActivityPriority)
                .HasConversion<string>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonalHubDbContext).Assembly);
        }
    }
}


