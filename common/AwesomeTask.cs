using System;
using System.Threading;

namespace common.Tasks {
    public class AwesomeTask {
        public void Execute(string strText) {
            Console.WriteLine("Super heavy task");
            Thread.Sleep(3000); // wait 3 sec
            Console.WriteLine($"Done: {strText}");
        }
    }
}