using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectHub.Api;
using ProjectHub.Infrastructure.Data.Contexts;

namespace ProjectHub.Tests.Integration.Suite.Mocks;

public class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(ReplaceDbContextWithInMemoryDb);
    }

    private static void ReplaceDbContextWithInMemoryDb(IServiceCollection services)
    {
        var existingDbContextRegistration = services.SingleOrDefault(d => d.ServiceType == typeof(ProjectHubDbContext));

        if (existingDbContextRegistration != null)
        {
            services.Remove(existingDbContextRegistration);
        }

        var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "sql_lite_tests" };
        var connectionString = connectionStringBuilder.ToString();
        services.AddDbContext<ProjectHubDbContext>(options => options.UseSqlite(connectionString));
    }

    public ProjectHubDbContext CreateDbContext()
    {
        var dbContext = Services.CreateScope().ServiceProvider.GetService<ProjectHubDbContext>()!;
        dbContext.Database.EnsureCreated();

        return dbContext;
    }
}
