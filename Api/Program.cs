
using System.Reflection;
using Api.Interfaces;
using Api.Repositories;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // CORS — добавляем политику "AllowAll"
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // Репозиторий
            builder.Services.AddSingleton<IProductRepository, ProductRepository>();

            builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

            // MediatR
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            // ВАЖНО! Подключаем CORS перед MapControllers
            app.UseCors("AllowAll");

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();

        }
    }
}
