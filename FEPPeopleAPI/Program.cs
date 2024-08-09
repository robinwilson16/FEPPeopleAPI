using FEPPeopleAPI;
using FEPPeopleAPI.Data;
using FEPPeopleAPI.Models;
using FEPPeopleAPI.Services;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add Authentication
builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();

//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    //options.FallbackPolicy = options.DefaultPolicy;
});

//Add Services Here
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<PersonTypeService>();

//Get connection string elements to asemble
var databaseSettings = builder.Configuration.GetSection("DatabaseConnection");
var server = databaseSettings["Server"];
var database = databaseSettings["Database"];
var useWindowsAuth = databaseSettings.GetValue<bool>("UseWindowsAuth");
var username = databaseSettings["Username"];
var password = databaseSettings["Password"];

var conStrBuilder = new SqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."));

conStrBuilder.DataSource = server;
conStrBuilder.InitialCatalog = database;

if (useWindowsAuth == true)
{
    conStrBuilder.IntegratedSecurity = useWindowsAuth;
}
else
{
    conStrBuilder.UserID = username;
    conStrBuilder.Password = password;
}

//Add SQL Server Connection
//builder.Configuration
//    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Secrets.json");
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var connectionString = conStrBuilder.ConnectionString;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//Allow access from another URL
string? APIEndpoint = builder.Configuration["APIEndpoint"];

string? origins = "origins";
builder.Services.AddCors(options =>
    options.AddPolicy(origins,
        policy =>
        {
            //policy.WithOrigins("https://localhost:7062")
            policy.WithOrigins(APIEndpoint ?? "")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        })
);

var app = builder.Build();

//Add Authentication
//app.MapIdentityApi<ApplicationUser>();
app.MapGroup("/User").MapIdentityApi<ApplicationUser>();

app.UseCors(origins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.MapControllers().RequireAuthorization();

app.Run();
