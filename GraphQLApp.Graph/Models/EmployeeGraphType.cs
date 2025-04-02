using GraphQL.Types;
using GraphQLApp.Business.Models;

namespace GraphQLApp.Graph.Models
{
    public class EmployeeGraphType : ObjectGraphType<Employee>
    {
        public EmployeeGraphType()
        {
            Field(f => f.Id, type: typeof(IdGraphType)).Description("Id property for Employee Class");
            Field(f => f.FirstName, type: typeof(StringGraphType)).Description("FirstName property for Employee Class");
            Field(f => f.LastName, type: typeof(StringGraphType)).Description("LastName property for Employee Class");
            Field(f => f.Email, type: typeof(StringGraphType)).Description("Email property for Employee Class");
        }
    }
}
