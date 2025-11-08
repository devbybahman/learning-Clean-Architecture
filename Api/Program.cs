using clean_arch.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ProjectBootstrapper.Configure(builder.Services);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
