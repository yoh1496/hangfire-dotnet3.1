using System;
using System.Threading;
using common.Interfaces;

namespace common.Tasks {
    public class AwesomeTask {
        private IAwesomeService awesomeService;
        public AwesomeTask(IAwesomeService service) {
            this.awesomeService = service;
        }
        public void Execute(string strText) {
            Console.WriteLine("Super heavy task");
            awesomeService.DoSomething();
            Console.WriteLine($"Done: {strText}");
        }
    }
}