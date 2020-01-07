using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DSAL.Models
{
    public class EntityMongoRepository : IRepository
    {
        MongoDbContext db = new MongoDbContext();
        public async Task Add(Employee entity)
        {
            try
            {
                dynamic dynamicEntity = entity;
                dynamicEntity.DbType = "MongoDB";
                await db.Entity.InsertOneAsync(dynamicEntity);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Employee> GetData(string id)
        {
            try
            {
                FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq("Id", id);
                return await db.Entity.Find(filter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllData()
        {
            try
            {
                return await db.Entity.Find(_ => true).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Employee entity)
        {
            try
            {
                int filterid = ((dynamic)entity).Id;
                var id = (IEnumerable<dynamic>)db.Entity;
             
             //   await db.Entity.ReplaceOneAsync(filter: g =>  replacement: entity);
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(string id)
        {
            try
            {
                FilterDefinition<Employee> data = Builders<Employee>.Filter.Eq("Id", id);
                await db.Entity.DeleteOneAsync(data);
            }
            catch
            {
                throw;
            }
        }
    }
}