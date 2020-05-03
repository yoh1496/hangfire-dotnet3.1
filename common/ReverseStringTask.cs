using System;
using System.Linq;
using System.Threading;
using common.Interfaces;
using Hangfire;
using Hangfire.Server;

namespace common.Tasks {
    public class ReverseStringTask {
        private ITaskService _taskService;
        public ReverseStringTask(ITaskService _taskService) {
            this._taskService = _taskService;
        }
        public void Execute(string objectId, PerformContext context) {
            Console.WriteLine($"Super heavy task #{context.BackgroundJob.Id}");
            var taskModel = _taskService.Find(x => x.Id == MongoDB.Bson.ObjectId.Parse(objectId)).Result[0];
            taskModel.Status = "DONE";
            taskModel.Result = new string(taskModel.Name.Reverse().ToArray());
            _taskService.Update(objectId, taskModel);
            Console.WriteLine($"Done: {taskModel.Name}");
        }
    }
}