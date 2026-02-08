using Domain.Interfaces;
using Persistense.Context;

namespace Persistense
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task Commit(CancellationToken cancellation)
        {
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
