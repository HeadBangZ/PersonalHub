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
                .Property(s => s.Id);

            modelBuilder.Entity<StoryItem>()
                .Property(s => s.UserStoryId);

            modelBuilder.Entity<StoryItem>()
                .Property(s => s.StoryItemType)
                .HasConversion<string>();

            modelBuilder.Entity<StoryItem>()
                .Property(s => s.StoryItemPriority)
                .HasConversion<string>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonalHubDbContext).Assembly);
        }
    }
}


