using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Maps the /openapi/v1.json endpoint 
    app.MapOpenApi();
    
    // Spins up the Scalar visual portal (default path: /scalar/v1)
    app.MapScalarApiReference("/docs");
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();