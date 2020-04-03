using System;
using Hangfire;
using Hangfire.Mongo;

namespace server {
    class Program {
        static void Main(string[] args) {
            GlobalConfiguration.Configuration
                .UseColouredConsoleLogProvider(Hangfire.Logging.LogLevel.Error)
                .UseMongoStorage("mongodb://localhost", "ApplicationDatabase");
            using(var server = new BackgroundJobServer()) {
                Console.WriteLine("Started BackgroundJobServer. Press Enter to exit.");
                Console.ReadLine();
            }
        }
    }
}