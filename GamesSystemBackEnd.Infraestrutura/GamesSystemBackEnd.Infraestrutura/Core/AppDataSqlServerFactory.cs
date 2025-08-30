using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSystemBackEnd.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace GamesSystemBackEnd.Infraestrutura.Core
{
    public class AppDataSqlServerFactory : IDesignTimeDbContextFactory<AppDataSqlServerContext>
    {
        public AppDataSqlServerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDataSqlServerContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=DataGames2025;Trusted_Connection=True;TrustServerCertificate=True;");

            return new AppDataSqlServerContext(optionsBuilder.Options);
        }
    }
}