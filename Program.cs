using Microsoft.EntityFrameworkCore;
using RESTSERVICEAPI.Models;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; // Enable CORS headers
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin(); // <-- Allow any origin
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                      });
}); // Enable CORS headers

// Add services to the container.

builder.Services.AddDbContext<ProductContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins); // Enable CORS headers
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
