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

            // TODO: Change the CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    b => b.AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod());
            });

            builder.Services.AddDbContext<PersonalHubDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("PersonalHubDbContext"));
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

            app.UseCors("AllowAll");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
