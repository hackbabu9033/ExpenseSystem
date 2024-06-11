using ExpenseAPI.Data;
using ExpenseAPI.Repo;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add json serializer options¡Aenable convert enum to string
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// add ExpenseContext to the services¡Aand use in-memory database
builder.Services.AddDbContext<ExpenseContext>(options =>
    options.UseInMemoryDatabase("Expenses"));

// add services for ExpenseRepository
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// enable cors configuration
app.UseCors(builder => builder
    .AllowAnyOrigin()
       .AllowAnyMethod()
          .AllowAnyHeader());

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


