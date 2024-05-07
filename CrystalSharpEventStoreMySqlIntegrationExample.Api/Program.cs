using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CrystalSharp;
using CrystalSharp.MySql.Extensions;
using CrystalSharp.MySql.Migrator;
using CrystalSharpEventStoreMySqlIntegrationExample.Application.CommandHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string eventStoreConnectionString = builder.Configuration.GetConnectionString("AppEventStoreConnectionString");
MySqlSettings eventStoreDbSettings = new(eventStoreConnectionString);

IResolver resolver = CrystalSharpAdapter.New(builder.Services)
    .AddCqrs(typeof(CreateProductCommandHandler))
    .AddMySqlEventStoreDb<int>(eventStoreDbSettings)
    .CreateResolver();

IMySqlDatabaseMigrator databaseMigrator = resolver.Resolve<IMySqlDatabaseMigrator>();

MySqlEventStoreSetup.Run(databaseMigrator, eventStoreDbSettings.ConnectionString).Wait();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
