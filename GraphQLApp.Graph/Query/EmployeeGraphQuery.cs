using GraphQL;
using GraphQL.Types;
using GraphQLApp.Graph.Models;
using GraphQLApp.Repository.Contracts;

namespace GraphQLApp.Graph.Query
{
    public class EmployeeGraphQuery : ObjectGraphType
    {
        public EmployeeGraphQuery(IEmployeeRepository repository)
        {
            Field<ListGraphType<EmployeeGraphType>>(
                "employees",
                "Return All Employees",
                resolve: context => repository.GetEmployees()
            );

            Field<EmployeeGraphType>(
                "employee",
                "Return A Single Employee By Id",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Employee Id" }
                ),
                resolve: context => repository.GetEmployeeById(context.GetArgument("id", int.MinValue))
            );

            

            //Field<ListGraphType<EmployeeGraphType>>(
            //    "employees",
            //    "Return All Employees",
            //    resolve: context => repository.GetEmployees()
            //);
        }

    }
}
