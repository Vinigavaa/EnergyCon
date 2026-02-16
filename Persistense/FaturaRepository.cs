using Domain.Interfaces;
using EnergyCom.Domains;
using Persistense.Context;

namespace Persistense
{
    public class FaturaRepository : BaseRepository<Fatura>, IFaturaRepository
    {
        public FaturaRepository(AppDbContext _context) : base(_context){ }
    }
}
