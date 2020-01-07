using MongoDB.Driver;

namespace DSAL.Models
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _mongoDb;
        private readonly string _entity;
        public MongoDbContext()
        {            
            var client = new MongoClient("mongodb://localhost:27017");
            _entity = typeof(Employee).Name.ToString();
            _mongoDb = client.GetDatabase(_entity + "Db");
        }
        public IMongoCollection<Employee> Entity
        {
            get
            {
                return _mongoDb.GetCollection<Employee>(_entity);
            }
        }
    }
}