using System;
using System.Threading;
using common.Interfaces;
using Hangfire.Server;

namespace common.Tasks {
    public class AwesomeTask {
        private IAwesomeService awesomeService;
        public AwesomeTask(IAwesomeService service) {
            this.awesomeService = service;
        }
        public void Execute(string strText, PerformContext context) {
            Console.WriteLine($"Super heavy task #{context.BackgroundJob.Id}");
            awesomeService.DoSomething();
            Console.WriteLine($"Done: {strText}");
        }
    }
}