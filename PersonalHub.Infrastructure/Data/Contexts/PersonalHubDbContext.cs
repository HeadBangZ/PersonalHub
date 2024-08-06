using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonalHub.Domain.Entities;
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

        public DbSet<ApiUser> Users { get; set; }
        public DbSet<UserStory> UserStories { get; set; }
        public DbSet<StoryItem> StoryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration(_configuration));
            modelBuilder.ApplyConfiguration(new UserConfiguration(_configuration));
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration(_configuration));

            // ApiUser
            modelBuilder.Entity<ApiUser>()
                .Property(x => x.Id);

            // UserStory
            modelBuilder.Entity<UserStory>()
                .Property(x => x.Id);

            modelBuilder.Entity<UserStory>()
                .HasMany(u => u.Items)
                .WithOne()
                .HasForeignKey(s => s.UserStoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserStoryItems
            modelBuilder.Entity<StoryItem>()
                .Property(x => x.Id);

            modelBuilder.Entity<StoryItem>()
                .Property(x => x.UserStoryId);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonalHubDbContext).Assembly);
        }
    }
}


