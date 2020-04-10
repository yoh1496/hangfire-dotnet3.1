using System;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Mongo;
using Microsoft.Extensions.Hosting;

namespace server {
    class Program {
        static async Task Main(string[] args) {
            var hostBuilder = new HostBuilder()
                .ConfigureServices((context, services) => {
                    services.AddHangfire(config => {
                        config.UseColouredConsoleLogProvider();
                        config.UseMongoStorage("mongodb://localhost", "ApplicationDatabase");
                    });
                    services.AddHangfireServer(options => {
                        options.WorkerCount = 4;
                    });
                });
            await hostBuilder.RunConsoleAsync();
        }
    }
}