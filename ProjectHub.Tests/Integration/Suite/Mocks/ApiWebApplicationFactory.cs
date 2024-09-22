using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectHub.Api;
using ProjectHub.Infrastructure.Data.Contexts;
using System.Data.Common;

namespace ProjectHub.Tests.Integration.Suite.Mocks;

public class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(ProjectHubDbContext));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddSingleton<DbConnection>(container =>
            {
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();

                return connection;
            });

            services.AddDbContext<ProjectHubDbContext>((container, options) =>
            {
                var connection = container.GetRequiredService<DbConnection>();
                options.UseSqlite(connection);
            });

            var sp = services.BuildServiceProvider();

            var scope = sp.CreateScope();
            var appContext = scope.ServiceProvider.GetRequiredService<ProjectHubDbContext>();

            try
            {
                appContext.Database.EnsureCreated();
            }
            catch (Exception)
            {
                throw;
            }
        });
    }

    public ProjectHubDbContext CreateDbContext()
    {
        var dbContext = Services.CreateScope().ServiceProvider.GetRequiredService<ProjectHubDbContext>();
        dbContext.Database.EnsureCreated();
        return dbContext;
    }
}
