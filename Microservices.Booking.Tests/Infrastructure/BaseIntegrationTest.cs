﻿using System;
using System.Collections.Generic;
using Flurl.Http;
using Microservices.Common.Mongo;
using Microservices.Common.Types;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Microservices.Booking.Tests.Infrastructure
{
    public abstract class BaseIntegrationTest : IDisposable
    {
        protected BaseIntegrationTest()
        {
            RunId = Guid.NewGuid().ToString();
            var builder = WebHost.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .UseStartup<Startup>();
            var server = new TestServer(builder);
            Services = server.Host.Services;
            var client = server.CreateClient();
            FlurlClient = new FlurlClient(client);
        }

        private IFlurlClient FlurlClient { get; }

        private string RunId { get; }

        protected const string Token = "XXX";

        private IServiceProvider Services { get; }

        private void ConfigureAppConfiguration(IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddJsonFile("appsettings.json");
            configurationBuilder.AddEnvironmentVariables();
            configurationBuilder.AddInMemoryCollection(new Dictionary<string, string>
            {
                {"MongoDb:database", $"microservices-booking-test{RunId}"}
            });
        }

        protected IMongoRepository<T> GetMongoDbRepository<T>() where T : IIdentifiable
        {
            return Services.GetService<IMongoRepository<T>>();
        }

        protected void ClearMongoDb()
        {
            var mongoClient = Services.GetService<IMongoDatabase>();
            var config = Services.GetService<MongoDbSettings>();
            mongoClient.Client.DropDatabase(config.Database);
        }

        public void Dispose()
        {
            FlurlClient?.Dispose();
            ClearMongoDb();
        }
    }
}
