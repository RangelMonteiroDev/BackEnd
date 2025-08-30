using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSystemBackEnd.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollBackAsync();
    }
}