using GraphQL;
using GraphQL.Types;
using GraphQLApp.Business.Models;
using GraphQLApp.Graph.Models;
using GraphQLApp.Repository.Contracts;

namespace GraphQLApp.Graph.Mutations
{
    public class EmployeeMutations: ObjectGraphType
    {
        public EmployeeMutations(IEmployeeRepository repository)
        {
            Field<EmployeeGraphType>(
                "addEmployee",
                "To Add an Employee to DB",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee", Description = "Add Employee Input Graph Type" }
                ),
                resolve: context =>
                {
                    var employee = context.GetArgument<Employee>("employee");
                    if(employee == null )
                    {
                        throw new ArgumentNullException("Employee is null");
                    }
                    return repository.AddEmployee(employee);
                }
            );
        }
    }
}
