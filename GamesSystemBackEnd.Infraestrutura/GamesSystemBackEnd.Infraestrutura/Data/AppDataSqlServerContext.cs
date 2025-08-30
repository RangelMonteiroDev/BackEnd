using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSystemBackEnd.Domain.Entitys;
using GamesSystemBackEnd.Infraestrutura.Core;
using Microsoft.EntityFrameworkCore;

namespace GamesSystemBackEnd.Infraestrutura.Data
{
    public class AppDataSqlServerContext : DbContext
    {   
        public AppDataSqlServerContext(DbContextOptions<AppDataSqlServerContext> options)
            : base(options)
        {
        }

        public DbSet<Jogadores> Jogadores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigureTypeJogadores());
        }
        
    }
}