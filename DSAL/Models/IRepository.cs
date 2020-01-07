using System.Collections.Generic;
using System.Threading.Tasks;

namespace DSAL.Models
{
    public interface IRepository
    {
        Task Add(Employee employee);
        Task Update(Employee employee);
        Task Delete(string id);
        Task<Employee> GetData(string id);
        Task<IEnumerable<Employee>> GetAllData();
    }
}
