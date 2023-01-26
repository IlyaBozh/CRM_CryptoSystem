using CRM_CryptoSystem.API.Infastructure;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

var dbConfig = new DbConfig();
builder.Configuration.Bind(dbConfig);

builder.Services.AddScoped<IDbConnection>(c => new SqlConnection(dbConfig.CRM_CONNECTION_STRING));

// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
