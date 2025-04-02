using GraphQL.Server;
using GraphQLApp.Graph.Query;
using GraphQLApp.Graph.Schema;
using GraphQLApp.Repository.Contracts;
using GraphQLApp.Repository.DBContext;
using GraphQLApp.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<EmployeeGraphQuery>();
builder.Services.AddScoped<AppSchema>();
builder.Services.AddGraphQL().AddSystemTextJson();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DBContext Registration

var Connection = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<GraphQLAppDBContext>(options => 
    options.UseSqlServer(
        connectionString: Connection, 
        sqlServerOptions => sqlServerOptions.CommandTimeout(60)
    ), 
    ServiceLifetime.Transient
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGraphQL<AppSchema>();
app.UseGraphQLGraphiQL("/ui/graphql");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
