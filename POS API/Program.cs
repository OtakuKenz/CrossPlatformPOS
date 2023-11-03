using Microsoft.EntityFrameworkCore;
using POS_API.Models;
using static CommonLibrary.Configuration.SharedConfiguration;

var builder = WebApplication.CreateBuilder(args);

var MyAllowedOrigins = "_myCORS";

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowedOrigins, policy =>
    {
        policy.WithOrigins(WebApp)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddDbContext<POSContext>(opt =>
    opt.UseSqlite("WebApiDatabase")
);

var app = builder.Build();

app.MapControllers();
app.UseCors(MyAllowedOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.Run();