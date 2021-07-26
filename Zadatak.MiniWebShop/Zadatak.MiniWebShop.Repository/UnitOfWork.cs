using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Infrastructure.Domain;

namespace Zadatak.MiniWebShop.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext _dbContext;
        public UnitOfWork(ShopDbContext context)
        {
            _dbContext = context;
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
