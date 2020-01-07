using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DSAL.Models
{
    public class EntitySqlRepository : IRepository, IDisposable 
    {
        private readonly SqlDbContext<Employee> db = new SqlDbContext<Employee>();
        bool disposed = false;
        public async Task Add(Employee entity)
        {
            dynamic dynamicEntity = entity;
            dynamicEntity.Id = Guid.NewGuid().ToString();
            dynamicEntity.DbType = "MS SQL";

            db.Data.Add(dynamicEntity);
            try
            {
                await db.SaveChangesAsync();
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
                Employee data = (Employee)await db.Data.FindAsync(id);
                if (data == null)
                {
                    return data;
                }
                return data;
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
                var allrecords = await db.Data.ToListAsync();
                return allrecords.AsQueryable().Cast<Employee>();
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
                db.Entry(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
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
                Employee entity = (Employee)await db.Data.FindAsync(id);
                db.Data.Remove(entity);
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        private bool DataExists(string id)
        {
            IEnumerable<Employee> allrecords = db.Data.Cast<Employee>();
            return allrecords.Count() > 0;
        }

        ~EntitySqlRepository()
        {
            if (!disposed)
            {
                disposed = true;
                Dispose(true);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

       
    }
}