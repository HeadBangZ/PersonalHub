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
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration(_configuration));
            modelBuilder.ApplyConfiguration(new UserConfiguration(_configuration));
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration(_configuration));

            // ApiUser
            modelBuilder.Entity<ApiUser>()
                .Property(x => x.Id);

            // ToDoList
            modelBuilder.Entity<ToDoList>()
                .Property(x => x.Id)
                .HasConversion(id => id.Value, id => new ToDoListId(id));

            modelBuilder.Entity<ToDoList>()
                .HasMany(x => x.Items)
                .WithOne(x => x.ToDoList)
                .HasForeignKey(x => x.ToDoListId)
                .OnDelete(DeleteBehavior.Cascade);

            // ToDoItems
            modelBuilder.Entity<ToDoItem>()
                .Property(x => x.Id)
                .HasConversion(id => id.Value, id => new ToDoItemId(id));

            modelBuilder.Entity<ToDoItem>()
                .Property(x => x.ToDoListId)
                .HasConversion(id => id.Value, id => new ToDoListId(id));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonalHubDbContext).Assembly);
        }
    }
}


