using Microsoft.AspNetCore.Identity;
using PersonalHub.Api.Extensions;
using PersonalHub.Application.Contracts;
using PersonalHub.Domain.User.Entities;
using PersonalHub.Infrastructure.Data.Seeders;
using PersonalHub.Infrastructure.Data.Seeders.ApiUsers;
using PersonalHub.Infrastructure.Services;

namespace PersonalHub.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        // Register IConfiguration as a singleton
        builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

        // Dependency Injections
        builder.Services
            .AddApplication()
            .AddInfrastructure(builder.Configuration)
            .AddPresentation()
            .AddAuthenticationAndAuthorization(builder.Configuration);

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var seederFeature = scope.ServiceProvider.GetRequiredService<IFeatureSeeder>();
            var seederApiUser = scope.ServiceProvider.GetRequiredService<IApiUserSeeder>();

            await seederFeature.Seed();
            await seederApiUser.Seed();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowAll");

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapGroup("api/identity").MapIdentityApi<ApiUser>();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
