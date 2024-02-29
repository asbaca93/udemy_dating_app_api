using API.Data;
using API.Repositories;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    //options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    var connectionStringBuilder = new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
    var searchPaths = connectionStringBuilder.SearchPath?.Split(',');

    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), o =>
    {
        if (searchPaths is { Length: > 0 })
        {
            var mainSchema = searchPaths[0];
            o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, mainSchema);
        }
    });
});
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IAccountsService, AccountsService>();
builder.Services.AddTransient<IAccountsRepository, AccountsRepository>();
builder.Services.AddCors();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(corsPolicyBuilder =>
{
    corsPolicyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
});

app.MapControllers();

app.Run();

