using PersonalHub.Api.Extensions;
using PersonalHub.Api.Middlewares;
using PersonalHub.Domain.User.Entities;
using PersonalHub.Infrastructure.Data.Seeders;
using PersonalHub.Infrastructure.Data.Seeders.ApiUsers;

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
            .AddPresentation(builder.Host)
            .AddAuthenticationAndAuthorization(builder.Configuration);


        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var seederSpace = scope.ServiceProvider.GetRequiredService<ISpaceSeeder>();
            var seederApiUser = scope.ServiceProvider.GetRequiredService<IApiUserSeeder>();
            var seederUserRole = scope.ServiceProvider.GetRequiredService<IUserRoleSeeder>();

            await seederApiUser.Seed();
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
