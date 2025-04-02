using GraphQLApp.Business.Models;
using GraphQLApp.Repository.Contracts;
using GraphQLApp.Repository.DBContext;

namespace GraphQLApp.Repository.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly GraphQLAppDBContext _dbContext;

        public EmployeeRepository(GraphQLAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employee> GetEmployees()
        {
            return _dbContext.EmployeeEntity.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _dbContext.EmployeeEntity.Where(e => e.Id == id).FirstOrDefault();
        }

        public Employee AddEmployee(Employee employee)
        {
            _dbContext.EmployeeEntity.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        public Employee UpdateEmployee(int id, Employee employee)
        {
            var _employee = _dbContext.EmployeeEntity.Where(_e => _e.Id == id).FirstOrDefault() ?? throw new Exception("Employee doesn't exists");
            if (_employee != null)
            {
                _employee.Email = employee.Email;
                _employee.FirstName = employee.FirstName;
                _employee.LastName = employee.LastName;
            }
            _dbContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(int id)
        {
            var _employee = _dbContext.EmployeeEntity.Where(_e => _e.Id == id).FirstOrDefault() ?? throw new Exception("Employee doesn't exists");

            if ( _employee != null )
            {
                _dbContext.EmployeeEntity.Remove(_employee);
            }
            _dbContext.SaveChanges();
        }
    }
}
