using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PersonalHub.Application.Contracts;
using PersonalHub.Application.Services;
using PersonalHub.Domain.Entities;
using PersonalHub.Infrastructure.Data.Contexts;
using PersonalHub.Infrastructure.Data.Seeders;
using PersonalHub.Infrastructure.Data.Seeders.ApiUsers;
using PersonalHub.Infrastructure.Extensions;
using PersonalHub.Infrastructure.Services;
using System.Text;

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
        builder.Services.AddSwaggerGen(s =>
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
                    []
                }
            });
        });

        builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

        // TODO: Change the CORS policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                b => b.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());
        });

        // Services
        builder.Services.AddInfrastructure(builder.Configuration);

        // Scopes
        builder.Services.AddScoped<AuthService>();
        builder.Services.AddScoped<UserStoryService>();

        builder.Services.AddIdentityCore<ApiUser>()
            .AddRoles<IdentityRole>()
            .AddTokenProvider<DataProtectorTokenProvider<ApiUser>>("https://localhost:7149/")
            .AddEntityFrameworkStores<PersonalHubDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddAuthentication(options =>
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
                ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                ValidAudience = builder.Configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])),
            };
        });

        builder.Services.AddIdentityApiEndpoints<ApiUser>(options =>
        {
            // TODO: Change the password rules
            options.Password.RequiredLength = 8;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = false;
        }).AddEntityFrameworkStores<PersonalHubDbContext>();

        // JWT Token Generator
        builder.Services.AddScoped<ITokenService, TokenService>(provider =>
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

        builder.Services.AddAuthorization();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var seederUserStory = scope.ServiceProvider.GetRequiredService<IUserStorySeeder>();
            var seederApiUser = scope.ServiceProvider.GetRequiredService<IApiUserSeeder>();

            await seederUserStory.Seed();
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
