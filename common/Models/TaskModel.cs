using MongoDB.Bson;

namespace common.Models
{
    public class TaskModel
    {
        public TaskModel()
        {
            Status = "CREATED";
            Result = null;
        }
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }
    }
}