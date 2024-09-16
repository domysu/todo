using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using ToDo.Models;

namespace ToDo.Services
{
    public class TodoService
    {
        private readonly IMongoCollection<TodoModel> _collection;

        public TodoService() 
        {

            var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
            if (connectionString == null)
            {
                Console.WriteLine("Connection string is not set up properly, https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#std-label-csharp-quickstart");
            }
              var client = new MongoClient(connectionString);
            var database = client.GetDatabase("TODO");
            _collection = database.GetCollection<TodoModel>("TodoList");



        

        }

        public async Task<List<TodoModel>> GetTodoListAsync()
        {
         var filter = Builders<TodoModel>.Filter.Empty;
         var result = await _collection.Find(filter)
                .Sort(Builders<TodoModel>.Sort.Descending("IsPinned"))
                .ToListAsync();
         return result;
        }
        
        public async Task AddItemAsync(TodoModel item)
        {
            
             await _collection.InsertOneAsync(item);
             
        }
        
        public async Task RemoveItemAsync(TodoModel item)
        {
            var filter = Builders<TodoModel>.Filter.Eq(t => t.Id,item.Id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task DeleteAll()
        {
            var filter = Builders<TodoModel>.Filter.Empty;
            await _collection.DeleteManyAsync(filter);
           

        }
        public async Task UpdateItemAsync(TodoModel item)
        {

            var filter = Builders<TodoModel>.Filter.Eq(t=>t.Id,item.Id);
            var update = Builders<TodoModel>.Update
                .Set(t => t.TodoText, item.TodoText)
                .Set(t => t.IsChecked, item.IsChecked)
                .Set(t => t.IsPinned, item.IsPinned);
            await _collection.UpdateOneAsync(filter, update);
        }
        
      
      
        

    }
}
