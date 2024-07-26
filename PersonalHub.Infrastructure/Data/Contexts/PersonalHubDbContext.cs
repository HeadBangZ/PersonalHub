using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;
using PersonalHub.Infrastructure.Data.Configurations;
using System.Text.Json;

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
        public DbSet<StoryTask> StoryTasks { get; set; }

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
                .Property(x => x.Id)
                .HasConversion(id => id.Value, id => new UserStoryId(id));

            modelBuilder.Entity<UserStory>()
                .HasMany(x => x.Items)
                .WithOne(x => x.UserStory)
                .HasForeignKey(x => x.UserStoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserStoryItems
            modelBuilder.Entity<StoryTask>()
                .Property(x => x.Id)
                .HasConversion(id => id.Value, id => new StoryTaskId(id));

            modelBuilder.Entity<StoryTask>()
                .Property(x => x.UserStoryId)
                .HasConversion(id => id.Value, id => new UserStoryId(id));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonalHubDbContext).Assembly);
        }
    }
}


