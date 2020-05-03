using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using common.Interfaces;
using common.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace common.Services {
    public class TaskService : ITaskService {
        private IMongoCollection<TaskModel> _mongoCollection;
        public TaskService(IMongoCollection<TaskModel> mongoCollection) {
            this._mongoCollection = mongoCollection;
        }
        public async Task<TaskModel> RegisterTask(string taskName) {
            var result = new TaskModel() { Name = taskName };
            await this._mongoCollection.InsertOneAsync(result);
            return result;
        }

        public async Task<List<TaskModel>> Find(Expression<Func<TaskModel, bool>> filter) {
            var result = await this._mongoCollection.FindAsync(filter);
            return await result.ToListAsync();
        }

        public async Task<long> Update(string objectId, TaskModel newOne) {
            var filters = (new FilterDefinitionBuilder<TaskModel>()).Eq(x => x.Id, ObjectId.Parse(objectId));
            return (await this._mongoCollection.ReplaceOneAsync(filters, newOne)).ModifiedCount;
        }
    }
}