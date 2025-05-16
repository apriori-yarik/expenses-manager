using ExpensesManager.Data;
using ExpensesManager.Data.Repositories;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Services;
using ExpensesManager.DomainServices;
using Microsoft.EntityFrameworkCore;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IExpensesRepository, ExpensesRepository>();

builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IExpensesService, ExpensesService>();

builder.Services.AddSingleton<ITools, PdfTools>();
builder.Services.AddSingleton<IConverter, SynchronizedConverter>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<ExpensesManagerDbContext>();

var app = builder.Build();

using var scope = app.Services.CreateScope();

var db = scope.ServiceProvider.GetRequiredService<ExpensesManagerDbContext>();
await db.Database.MigrateAsync();

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
