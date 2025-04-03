using GraphQL.Server;
using GraphQLApp.Graph.Mutations;
using GraphQLApp.Graph.Query;
using GraphQLApp.Graph.Schema;
using GraphQLApp.Repository.Contracts;
using GraphQLApp.Repository.DBContext;
using GraphQLApp.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<EmployeeGraphQuery>();
builder.Services.AddScoped<EmployeeMutations>();
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

app.Lifetime.ApplicationStarted.Register(() =>
{
    var launchURLs = builder.Configuration.GetValue<string>("LaunchURLs").Split(", ");

    if (launchURLs != null)
    {
        foreach (var url in launchURLs)
        {
            OpenBrowser(url);
        }
    }
});

app.Run();

static void OpenBrowser(string url)
{
    try
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to open URL {url}: {ex.Message}");
    }
}