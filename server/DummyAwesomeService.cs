using System;
using System.Threading;
using common.Interfaces;

namespace server {
    class DummyAwesomeService : IAwesomeService {
        public void DoSomething() {
            Console.WriteLine("DummyAwesomeService#DoSomething start");
            Thread.Sleep(3000); // wait 3 sec
            Console.WriteLine("DummyAwesomeService#DoSomething end");
        }
    }
}