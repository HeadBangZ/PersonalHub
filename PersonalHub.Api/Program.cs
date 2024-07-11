using Microsoft.EntityFrameworkCore;
using PersonalHub.Infrastructure;
using PersonalHub.Infrastructure.Data;

namespace PersonalHub.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var configuration = builder.Configuration;
            var connectionString = configuration.GetConnectionString("PersonalHubDbContext");


            builder.Services.AddDbContext<PersonalHubDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PersonalHubDbContext>();

                try
                {
                    dbContext.Database.EnsureCreated(); // Try to ensure the database exists or migrated
                    Console.WriteLine("Database connection successful.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Database connection failed: {ex.Message}");
                    throw; // Rethrow the exception to halt execution
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
