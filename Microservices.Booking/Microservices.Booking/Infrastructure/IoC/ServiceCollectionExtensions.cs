using System.Collections.Generic;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Humanizer;
using Microservices.Booking.BussinessLogic.Services.MoviePremieresReader.Settings;
using Microservices.Booking.BussinessLogic.Settings;
using Microservices.Booking.Domain.Entities;
using Microservices.Booking.Web.Controllers;
using Microservices.Common.Abstractions;
using Microservices.Common.Bus.RabbitMqBus;
using Microservices.Common.Consul;
using Microservices.Common.Dispatchers;
using Microservices.Common.Mongo;
using Microservices.Common.Mvc;
using Microservices.Common.Mvc.Middleware;
using Microservices.Common.Redis;
using Microservices.Common.Security.DataEncryptors;
using Microservices.Common.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Booking.Infrastructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IContainer BuildAutofacContainer(this IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            var importModule = new BookingApiModule();
            builder.AddRabbitMq();
            builder.RegisterModule(importModule);            
            services.AddCustomMvc();
            services.AddSwaggerDocs();
            services.AddConsul();
            services.AddRedis();
            services.AddInitializers(typeof(IMongoDbInitializer));
            builder.AddAbstractions();
            builder.AddStringEncryptor();
            builder.AddMongo();
            builder.AddMongoRepository<Cinema>(nameof(Cinema)
                .Pluralize());
            builder.AddMongoRepository<MovieShows>(nameof(MovieShows)
                .Pluralize());
            builder.AddDispatchers();
            builder.AddExceptionHandlers();
            services.AddOptions();

            builder.RegisterAssemblyTypes(typeof(TicketsController).Assembly)
                .AsImplementedInterfaces();
            builder.Populate(services);
            return builder.Build();
        }

        public static void RegisterSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EncryptionSettings>(configuration.GetSection("Encryption"));
            services.Configure<TheMovieDbApiSettings>(configuration.GetSection("TheMovieDbApiSettings"));
            services.Configure<CinemasSettings>(configuration.GetSection("CinemaSettings"));          
        }
    }
}
