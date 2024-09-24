using MongoDB.Bson;

namespace ToDo.Models
{
    public class TodoModel
    {

        public ObjectId Id { get; set; }
        public string? TodoText { get; set; }

        public string? TodoDescription { get; set; }

        public bool IsChecked { get; set; }

        public bool IsPinned { get; set; } 
        
    }
}
