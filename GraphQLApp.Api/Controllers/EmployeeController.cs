using GraphQLApp.Business.Models;
using GraphQLApp.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_employeeRepository.GetEmployees());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_employeeRepository.GetEmployeeById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            return Ok(_employeeRepository.AddEmployee(employee));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }
    }
}
