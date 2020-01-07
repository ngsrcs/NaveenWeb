using DSAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace DSAL.Controllers
{
    public class EmployeesApiController<Employee> : ApiController
    {
        private IRepository _iEmployeeRepository;

        public EmployeesApiController(IRepository iEmployeeRepository)
        {
            _iEmployeeRepository = iEmployeeRepository;
        }
        [HttpGet]
        [Route("api/Employees/Get")]
        public async Task<Models.Employee> Get()
        {
            return (Models.Employee)await _iEmployeeRepository.GetAllData();
        }

        [HttpPost]
        [Route("api/Employees/Create")]
        public async Task CreateAsync([FromBody]Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _iEmployeeRepository.Add(employee);
            }
        }

        [HttpGet]
        [Route("api/Employees/Details/{id}")]
        public async Task<Models.Employee> Details(string id)
        {
            var result = (Models.Employee)await _iEmployeeRepository.GetData(id);
            return result;
        }

        [HttpPut]
        [Route("api/Employees/Edit")]
        public async Task EditAsync([FromBody]Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _iEmployeeRepository.Update(employee);
            }
        }

        [HttpDelete]
        [Route("api/Employees/Delete/{id}")]
        public async Task DeleteConfirmedAsync(string id)
        {
            await _iEmployeeRepository.Delete(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _iEmployeeRepository = null;
            }
            base.Dispose(disposing);
        }
    }
}