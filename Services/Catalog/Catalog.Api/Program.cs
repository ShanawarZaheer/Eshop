var builder = WebApplication.CreateBuilder(args);
// Add services to the container (DI)
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});
builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();
// configure the HTTP request pipeline 
app.MapCarter();
app.Run();
