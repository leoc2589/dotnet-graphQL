using App.Extensions;
using App.Middlewares;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services
    .AddServices();

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext()
    .RegisterServices()
    .RegisterQueries()
    .RegisterMutations()
    .RegisterTypes()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .UseField<DomainExceptionMiddleware>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

await app.RunAsync();