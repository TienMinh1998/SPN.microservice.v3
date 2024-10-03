using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseCore.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
