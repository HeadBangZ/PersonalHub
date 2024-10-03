using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using ProjectHub.Api.Middlewares;
using ProjectHub.Application.Contracts;
using ProjectHub.Application.Services;
using ProjectHub.Domain.Contracts;
using ProjectHub.Domain.User.Entities;
using ProjectHub.Infrastructure.Data.Contexts;
using ProjectHub.Infrastructure.Data.Seeders;
using ProjectHub.Infrastructure.Data.Seeders.ApiUsers;
using ProjectHub.Infrastructure.Repositories;
using ProjectHub.Infrastructure.Repositories.Auth;
using ProjectHub.Infrastructure.Repositories.GenericRepositories;
using ProjectHub.Infrastructure.Services;
using Serilog;
using System.Text;

namespace ProjectHub.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ProjectHubDbContext");
        services.AddDbContext<ProjectHubDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<ISpaceSeeder, SpaceSeeder>();
        services.AddScoped<IApiUserSeeder, ApiUserSeeder>();
        services.AddScoped<IUserProfileSeeder, UserProfileSeeder>();
        services.AddScoped<IUserRoleSeeder, UserRoleSeeder>();
        services.AddScoped<IRoleSeeder, RoleSeeder>();

        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<ISpaceRepository, SpaceRepository>();
        services.AddScoped<ISectionRepository, SectionRepository>();
        services.AddScoped<IFeatureRepository, FeatureRepository>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ISpaceService, SpaceService>();
        services.AddScoped<ISectionService, SectionService>();
        services.AddScoped<IFeatureService, FeatureService>();

        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services, IHostBuilder host)
    {
        host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
        services.AddTransient<GlobalExceptionHandlingMiddleware>();

        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
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
            .AddEntityFrameworkStores<ProjectHubDbContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityApiEndpoints<ApiUser>(options =>
        {
            // TODO: Change the password rules
            options.Password.RequiredLength = 8;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = false;
        }).AddEntityFrameworkStores<ProjectHubDbContext>();

        return services;
    }
}
