using GraphQL.Types;

namespace GraphQLApp.Graph.Models
{
    public class EmployeeInputType: InputObjectGraphType
    {
        public EmployeeInputType()
        {
            Name = "EmployeeInputGraphType";
            Field<StringGraphType>("FirstName");
            Field<StringGraphType>("LastName");
            Field<StringGraphType>("Email");
        }
    }
}
