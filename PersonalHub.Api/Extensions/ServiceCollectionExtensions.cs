using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PersonalHub.Api.Middlewares;
using PersonalHub.Application.Contracts;
using PersonalHub.Application.Services;
using PersonalHub.Domain.Contracts;
using PersonalHub.Domain.User.Entities;
using PersonalHub.Infrastructure.Data.Contexts;
using PersonalHub.Infrastructure.Data.Seeders;
using PersonalHub.Infrastructure.Data.Seeders.ApiUsers;
using PersonalHub.Infrastructure.Repositories;
using PersonalHub.Infrastructure.Repositories.Auth;
using PersonalHub.Infrastructure.Repositories.GenericRepositories;
using PersonalHub.Infrastructure.Services;
using System.Text;
using System.Text.Json.Serialization;
using Serilog;

namespace PersonalHub.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PersonalHubDbContext");
        services.AddDbContext<PersonalHubDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<ISpaceSeeder, SpaceSeeder>();
        services.AddScoped<IApiUserSeeder, ApiUserSeeder>();
        services.AddScoped<IUserRoleSeeder, UserRoleSeeder>();

        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IFeatureRepository, FeatureRepository>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<AuthService>();
        services.AddScoped<FeatureService>();

        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services, IHostBuilder host)
    {
        host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
        services.AddTransient<GlobalExceptionHandlingMiddleware>();

        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddSwaggerGen(s =>
        {
            s.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            s.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }

    public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                b => b.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"])),
            };
        });

        services.AddScoped<ITokenService, TokenService>(provider =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var userManager = provider.GetRequiredService<UserManager<ApiUser>>();
            return new TokenService(
                configuration["JwtSettings:Key"]!,
                configuration["JwtSettings:Issuer"]!,
                configuration["JwtSettings:Audience"]!,
                int.Parse(configuration["JwtSettings:DurationInMinutes"]!),
                userManager
            );
        });

        services.AddAuthorization();

        services.AddIdentityCore<ApiUser>()
            .AddRoles<IdentityRole>()
            .AddTokenProvider<DataProtectorTokenProvider<ApiUser>>("https://localhost:7149/")
            .AddEntityFrameworkStores<PersonalHubDbContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityApiEndpoints<ApiUser>(options =>
        {
            // TODO: Change the password rules
            options.Password.RequiredLength = 8;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = false;
        }).AddEntityFrameworkStores<PersonalHubDbContext>();

        return services;
    }
}
