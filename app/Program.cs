using System;
using System.Threading;
using common.Tasks;
using Hangfire;
using Hangfire.Logging;
using Hangfire.Mongo;

namespace app {
    class Program {

        static void Main(string[] args) {

            var migrationOptions = new MongoMigrationOptions {
                Strategy = MongoMigrationStrategy.Drop,
                BackupStrategy = MongoBackupStrategy.Collections
            };
            var storageOptions = new MongoStorageOptions {
                MigrationOptions = migrationOptions
            };
            GlobalConfiguration.Configuration
                .UseColouredConsoleLogProvider(Hangfire.Logging.LogLevel.Error)
                .UseMongoStorage("mongodb://localhost", "ApplicationDatabase", storageOptions);
            int Cnt = 10;
            for (int i = 0; i < Cnt; i++) {
                BackgroundJob.Enqueue<AwesomeTask>(x => x.Execute($"task #{i}"));
                Console.WriteLine($"Enqueued task#{i}");
            }
        }
    }
}