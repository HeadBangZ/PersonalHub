using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.Repositories;
using PersonalHub.Infrastructure.Data.Contexts;
using PersonalHub.Infrastructure.Data.Seeders;
using PersonalHub.Infrastructure.Repositories;
using PersonalHub.Infrastructure.Repositories.Auth;

namespace PersonalHub.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PersonalHubDbContext");
        services.AddDbContext<PersonalHubDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IUserStorySeeder, UserStorySeeder>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IUserStoryRepository, UserStoryRepository>();
    }
}
