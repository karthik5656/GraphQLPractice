using GraphQLApp.Graph.Query;

namespace GraphQLApp.Graph.Schema
{
    public class AppSchema: GraphQL.Types.Schema
    {
        public AppSchema(EmployeeGraphQuery query)
        {
            this.Query = query;
        }
    }
}
