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

            public async Task<List<TodoModel>> GetTodoList()
            {
            var filter = Builders<TodoModel>.Filter.Empty;
            var result = await _collection.Find(filter).ToListAsync();

            return result;
            }

    }
}
