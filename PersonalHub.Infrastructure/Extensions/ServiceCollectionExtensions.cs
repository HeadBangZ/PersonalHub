using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalHub.Application.Contracts.Repositories;
using PersonalHub.Infrastructure.Data.Contexts;
using PersonalHub.Infrastructure.Repositories;

namespace PersonalHub.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PersonalHubDbContext");
        services.AddDbContext<PersonalHubDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}
