using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSystemBackEnd.Domain.Interfaces;
using GamesSystemBackEnd.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace GamesSystemBackEnd.Infraestrutura.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {   
        private IDbContextTransaction? _transaction;
        private readonly AppDataSqlServerContext _context;
        public UnitOfWork(AppDataSqlServerContext context)
        {
            _context = context;
        }
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }
        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }
        public async Task RollBackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }
    }
}