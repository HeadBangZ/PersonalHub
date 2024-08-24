using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonalHub.Domain.Shared.Entities;
using PersonalHub.Domain.Shared.ValueObjects;
using PersonalHub.Domain.User.Entities;
using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.RelationShips;
using PersonalHub.Domain.Workspace.ValueObjects;
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

        // Shared
        public DbSet<Tag> Tags => Set<Tag>();

        // User
        public DbSet<ApiUser> Users => Set<ApiUser>();

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
            modelBuilder.ApplyConfiguration(new RoleConfiguration(_configuration));

            CreateModelEpicTag(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonalHubDbContext).Assembly);
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


