using Domain.Interfaces;
using EnergyCom.Domains;
using Persistense.Context;

namespace Persistense
{
    public class UcRepository : BaseRepository<Uc>, IUcRepository
    {
        public UcRepository(AppDbContext context) : base(context) { }
    }
}
