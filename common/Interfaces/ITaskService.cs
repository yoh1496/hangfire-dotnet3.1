using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using common.Models;

namespace common.Interfaces {
    public interface ITaskService {
        Task<TaskModel> RegisterTask(string taskName);
        Task<List<TaskModel>> Find(Expression<Func<TaskModel, bool>> filter);
        Task<long> Update(string objectId, TaskModel newOne);
    }
}