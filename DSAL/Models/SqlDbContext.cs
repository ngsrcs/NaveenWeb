using System.Data.Entity;

namespace DSAL.Models
{
    public class SqlDbContext<Employee> : DbContext 
    {
        private readonly string _entity;
        public SqlDbContext() : base("name=SqlConnection")
        {
            _entity = typeof(Employee).Name.ToString();
        }
        public DbSet Data { get; set; }
    }
}