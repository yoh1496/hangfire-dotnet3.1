using System;
using System.Threading.Tasks;
using common.Interfaces;
using Hangfire;
using Hangfire.Mongo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                    services.AddTransient<IAwesomeService, DummyAwesomeService>();
                });
            await hostBuilder.RunConsoleAsync();
        }
    }
}