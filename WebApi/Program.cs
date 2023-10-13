using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieStoreDbContext>(options => options.UseInMemoryDatabase(databaseName:"BookStoreDB"));
builder.Services.AddScoped<IMovieStoreDbContext, MovieStoreDbContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//1. Find the service layer within our scope.
var scope = app.Services.CreateScope();

//2. Get the instance of BoardGamesDBContext in our services layer
var services = scope.ServiceProvider;

//3. Call the DataGenerator to create sample data
DataGenarator.Initialize(services);

//Continue to run the application

app.Run();
