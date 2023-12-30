using Guani.Domain.Core;
using Guani.Domain.Interfaces.V1_0.Customers;
using Guani.Domain.Services.V1_0;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using Guani.Infrastructure;

namespace Guani.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            var applicationAssembly = Assembly.Load("Guani.Application");
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = true);

            builder.Services.AddDbContext<GuaniContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            
            builder.Services.AddScoped<IGuaniContext, GuaniContext>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            #region Domain Services

            builder.Services.AddTransient<ICustomerDomainService, CustomerDomainService>();

            #endregion

            var app = builder.Build();

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