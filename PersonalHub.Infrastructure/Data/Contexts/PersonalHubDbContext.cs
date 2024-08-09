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

        public DbSet<ApiUser> Users => Set<ApiUser>();
        public DbSet<UserStory> UserStories => Set<UserStory>();
        public DbSet<StoryItem> StoryItems => Set<StoryItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration(_configuration));
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration(_configuration));

            // ApiUser
            modelBuilder.Entity<ApiUser>()
                .ComplexProperty(u => u.Information).IsRequired();

            // UserStory
            modelBuilder.Entity<UserStory>()
                .HasMany(u => u.Items)
                .WithOne()
                .HasForeignKey(s => s.UserStoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserStoryItems
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


