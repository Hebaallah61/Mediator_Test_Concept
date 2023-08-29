using FluentValidation;
using MediatorDemoLibrary.Commands;
using MediatorDemoLibrary.DataAccess;
using MediatorDemoLibrary.Models;
using MediatorDemoLibrary.PiplineBehaviour;
using MediatorDemoLibrary.Validation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;
using System.Reflection;
using FluentValidation.AspNetCore;

namespace DemoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<InsertUserCommandValidator>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IDataAccess, DemoDataAccess>();
            builder.Services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(DemoDataAccess).Assembly);
            });
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBahaviour<,>));
            //RegisterValidators(typeof(InsertUserCommandValidator).Assembly, builder.Services);


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

        //private static void RegisterValidators(Assembly assembly, IServiceCollection services)
        //{
        //    var validatorType = typeof(IValidator<>);

        //    var validatorTypes = assembly.GetTypes()
        //        .Where(type => type.GetInterfaces()
        //            .Any(interfaceType => interfaceType.IsGenericType &&
        //                                  interfaceType.GetGenericTypeDefinition() == validatorType))
        //        .ToList();

        //    foreach (var validator in validatorTypes)
        //    {
        //        services.AddTransient(validator);
        //    }
        //}
    }
}