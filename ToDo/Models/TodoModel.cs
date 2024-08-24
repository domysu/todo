namespace ToDo.Models
{
    public class TodoModel
    {
        public static int nextId = 0;
        public int Id { get; set; }
        public string? TodoText { get; set; }
    public TodoModel() {
            Id = nextId;
            nextId++;

        
        }  
    }
}
