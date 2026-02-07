using Domain.Interfaces;
using EnergyCom.Context;
using EnergyCom.Domains;
using Microsoft.EntityFrameworkCore;

namespace Persistense
{
    public class UcRepository : BaseRepository<Uc>, IUcRepository
    {
        public UcRepository(AppDbContext context) : base(context) { }

        public async Task<List<Uc>> GetAll(CancellationToken cancellationToken)
        {
            return await Context.Set<Uc>().ToListAsync(cancellationToken);
        }
    }
}
