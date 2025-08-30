using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using GamesSystemBackEnd.Application.AutoMapping;
using GamesSystemBackEnd.Application.IServices;
using GamesSystemBackEnd.Application.Services;
using GamesSystemBackEnd.Domain.Interfaces;
using GamesSystemBackEnd.Domain.UseCases;
using GamesSystemBackEnd.Infraestrutura.Data;
using GamesSystemBackEnd.Infraestrutura.Respositorys;
using GamesSystemBackEnd.Infraestrutura.Transactions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GamesSystemBackEnd.API.DependencyInjection
{
    public static class ServicesRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            // DbContext
            services.AddDbContext<AppDataSqlServerContext>(options =>
                options.UseSqlServer(connectionString)
            );

            // Services / UseCases
            services.AddScoped<IServiceJogador, JogadoresServices>();
            services.AddScoped<JogadorUseCase>();

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<IJogadores, JogadoresRepository>();

            // AutoMapper
            services.AddAutoMapper(typeof(AutoMappingJogador));

            //MediatR
            services.AddMediatR( cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
        }
    }
}