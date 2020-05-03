using System;
using System.Threading.Tasks;
using common.Interfaces;
using common.Models;
using common.Services;
using common.Tasks;
using Hangfire;
using Hangfire.Mongo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace server {

    class Program {
        static async Task Main(string[] args) {
            var hostBuilder = new HostBuilder()
                .ConfigureServices((context, services) => {
                    services.AddHangfire(config => {
                        config.UseColouredConsoleLogProvider();
                        config.UseFilter(new Filters.ReportPerformanceFilter());
                        config.UseMongoStorage("mongodb://localhost", "ApplicationDatabase");
                    });
                    services.AddHangfireServer(options => {
                        options.WorkerCount = 4;
                    });

                    services.AddTransient<IMongoDatabase>(serviceProvider => {
                        return new MongoClient("mongodb://localhost/").GetDatabase("current");
                    });

                    services.AddTransient<IMongoCollection<TaskModel>>(serviceProvider => {
                        return serviceProvider
                            .GetService<IMongoDatabase>()
                            .GetCollection<TaskModel>("tasks");
                    });
                    services.AddTransient<ITaskService, TaskService>();
                    services.AddTransient<IAwesomeService, DummyAwesomeService>();
                    services.AddTransient<AwesomeTask>();
                });
            await hostBuilder.RunConsoleAsync();
        }
    }
}