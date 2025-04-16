
using Microsoft.Extensions.DependencyInjection;
using TodoList.Context;
using TodoList.Interfaces;
using TodoList.Servicios;

namespace TodoList
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

            builder.Services.AddSqlServer<Contexto>(builder.Configuration.GetConnectionString("AppConnection"));

            builder.Services.AddTransient<ITareas,TareasServicio>();
            builder.Services.AddTransient<IUsuarios, UsuarioServicios>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("PermitirFrontend", policy =>
                {
                    policy.WithOrigins("http://127.0.0.1:5500")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

             app.UseCors("PermitirFrontend");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
