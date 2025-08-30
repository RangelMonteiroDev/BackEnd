using GamesSystemBackEnd.API.DependencyInjection;
using GamesSystemBackEnd.Application.AutoMapping;
using GamesSystemBackEnd.Application.IServices;
using GamesSystemBackEnd.Application.Services;
using GamesSystemBackEnd.Domain.Interfaces;
using GamesSystemBackEnd.Domain.UseCases;
using GamesSystemBackEnd.Infraestrutura.Data;
using GamesSystemBackEnd.Infraestrutura.Respositorys;
using GamesSystemBackEnd.Infraestrutura.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(
    builder.Configuration.GetConnectionString("SqlServer")
);


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
