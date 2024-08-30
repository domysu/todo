using MongoDB.Bson;

namespace ToDo.Models
{
    public class TodoModel
    {

        public ObjectId Id { get; set; }
        public int TodoId { get; set; }
        public string? TodoText { get; set; }
  
    }
}
