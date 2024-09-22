using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectHub.Domain.Common.Entities;
using ProjectHub.Domain.Common.ValueObjects;
using ProjectHub.Domain.User.Entities;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.RelationShips;
using ProjectHub.Domain.Workspace.ValueObjects;
using ProjectHub.Infrastructure.Data.Configurations;

namespace ProjectHub.Infrastructure.Data.Contexts
{
    public class ProjectHubDbContext : IdentityDbContext<ApiUser>
    {
        public ProjectHubDbContext(DbContextOptions<ProjectHubDbContext> options) : base(options) { }

        // Shared
        public DbSet<Tag> Tags => Set<Tag>();

        // User
        public DbSet<ApiUser> Users => Set<ApiUser>();
        public DbSet<UserProfile> UserProfiles => Set<UserProfile>();

        // Workspace
        public DbSet<Space> Spaces => Set<Space>();
        public DbSet<Section> Sections => Set<Section>();
        public DbSet<Epic> Epics => Set<Epic>();
        public DbSet<Feature> Features => Set<Feature>();
        public DbSet<Bug> Bugs => Set<Bug>();
        public DbSet<Activity> Activities => Set<Activity>();

        // Relationship
        public DbSet<EpicTag> EpicTags => Set<EpicTag>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CreateModelEpicTag(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectHubDbContext).Assembly);
        }

        private void CreateModelEpicTag(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EpicTag>()
                .HasKey(et => new { et.EpicId, et.TagId });

            modelBuilder.Entity<EpicTag>()
                .Property(et => et.EpicId).HasConversion(
                epicId => epicId.Id,
                value => new EpicId(value));

            modelBuilder.Entity<EpicTag>()
                .Property(et => et.TagId).HasConversion(
                tagId => tagId.Id,
                value => new TagId(value));

            modelBuilder.Entity<EpicTag>()
                .HasOne(et => et.Epic)
                .WithMany(e => e.EpicTags)
                .HasForeignKey(et => et.EpicId);

            modelBuilder.Entity<EpicTag>()
                .HasOne(et => et.Tag)
                .WithMany(e => e.EpicTags)
                .HasForeignKey(et => et.TagId);
        }
    }
}


