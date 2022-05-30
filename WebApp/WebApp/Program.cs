using Microsoft.EntityFrameworkCore;
using WebApp;
using WebApp.Repositories;
using WebApp.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = Config.GetConnectionString("database");
builder.Services.AddDbContext<MyDBContext>(options => options.UseSqlite(connectionString));

builder.Services.AddScoped<PersonRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<EmployeerRepository>();
builder.Services.AddScoped<IPersonValidator, PersonValidationService>();
builder.Services.AddScoped<IPersDelValidator, PersDelValidator>();
builder.Services.AddScoped<IUserValidator, UserValidationService>();
builder.Services.AddScoped<IUserDelValidator, UserDelValidator>();
builder.Services.AddScoped<IEmployeerValidator, EmployeeValidationService>();
builder.Services.AddScoped<IEmpDelValidator, EmpDelValidator>();
var app = builder.Build();

startup.Configure(app, app.Environment);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();