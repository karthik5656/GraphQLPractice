using GraphQLApp.Business.Models;

namespace GraphQLApp.Repository.Contracts
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetEmployees();

        public Employee GetEmployeeById(int id);

        public Employee AddEmployee(Employee employee);

        public Employee UpdateEmployee(int id, Employee employee);

        public void DeleteEmployee(int id);
    }
}
