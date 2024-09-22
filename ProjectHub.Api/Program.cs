using Microsoft.EntityFrameworkCore;
using ProjectHub.Api.Extensions;
using ProjectHub.Api.Middlewares;
using ProjectHub.Domain.User.Entities;
using ProjectHub.Infrastructure.Data.Contexts;
using ProjectHub.Infrastructure.Data.Seeders;
using ProjectHub.Infrastructure.Data.Seeders.ApiUsers;

namespace ProjectHub.Api;

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
            .AddPresentation(builder.Host)
            .AddAuthenticationAndAuthorization(builder.Configuration);


        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var seederSpace = scope.ServiceProvider.GetRequiredService<ISpaceSeeder>();
            var seederApiUser = scope.ServiceProvider.GetRequiredService<IApiUserSeeder>();
            var seederUserProfile = scope.ServiceProvider.GetRequiredService<IUserProfileSeeder>();
            var seederUserRole = scope.ServiceProvider.GetRequiredService<IUserRoleSeeder>();
            var seederRole = scope.ServiceProvider.GetRequiredService<IRoleSeeder>();

            var user = await seederApiUser.Seed();
            await seederRole.Seed();
            await seederUserProfile.Seed(user);
            await seederUserRole.Seed();
            await seederSpace.Seed();
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

        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

        app.MapControllers();

        app.Run();
    }
}
