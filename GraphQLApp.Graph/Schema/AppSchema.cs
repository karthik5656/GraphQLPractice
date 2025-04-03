using GraphQLApp.Graph.Mutations;
using GraphQLApp.Graph.Query;

namespace GraphQLApp.Graph.Schema
{
    public class AppSchema: GraphQL.Types.Schema
    {
        public AppSchema(EmployeeGraphQuery query, EmployeeMutations employeeMutations)
        {
            this.Query = query;
            this.Mutation = employeeMutations;
        }
    }
}
