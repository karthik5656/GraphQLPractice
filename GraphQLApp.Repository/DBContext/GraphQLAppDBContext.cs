using Microsoft.EntityFrameworkCore;
using GraphQLApp.Business.Models;

namespace GraphQLApp.Repository.DBContext
{
    public class GraphQLAppDBContext : DbContext
    {
        public GraphQLAppDBContext(DbContextOptions<GraphQLAppDBContext> options): base(options) { }
        

        public DbSet<Employee> EmployeeEntity { get; set; }
    }
}
