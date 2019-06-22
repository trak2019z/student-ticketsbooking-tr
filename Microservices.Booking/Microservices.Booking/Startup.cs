using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microservices.Booking.BussinessLogic.Commands.BookSeatForMovieShow;
using Microservices.Booking.Infrastructure.IoC;
using Microservices.Booking.Web.Controllers;
using Microservices.Common;
using Microservices.Common.Bus.RabbitMqBus;
using Microservices.Common.Mvc;
using Microservices.Common.Mvc.Filters;
using Microservices.Common.Mvc.Middleware;
using Microservices.Common.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Booking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(cfg => cfg.Filters.Add<ValidateModelAttribute>())
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TicketsController>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCustomMvc();
            services.RegisterSettings(Configuration);
            Container = services.BuildAutofacContainer();        
            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime applicationLifetime, IStartupInitializer startupInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMvc();
            app.UseRabbitMq()
                .SubscribeCommand<BookSeatForMovieShowCommand>();
            app.UseSwaggerDocs();
            applicationLifetime.ApplicationStopped.Register(() => Container.Dispose());
            startupInitializer.InitializeAsync();
        }
    }
}