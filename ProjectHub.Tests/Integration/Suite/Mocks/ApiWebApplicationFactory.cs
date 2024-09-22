using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectHub.Api;
using ProjectHub.Api.Controllers;
using ProjectHub.Infrastructure.Data.Contexts;


namespace ProjectHub.Tests.Integration.Suite.Mocks;

public class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ProjectHubDbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<ProjectHubDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDatabase");
            });

            services.AddControllersWithViews().AddApplicationPart(typeof(SpacesController).Assembly);

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ProjectHubDbContext>();
                db.Database.EnsureCreated();
            }
        });

        builder.Configure(app =>
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        });
    }
}
