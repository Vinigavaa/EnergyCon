using Domain.Interfaces;
using EnergyCom.Domains;
using Persistense.Context;

namespace Persistense
{
    public class ConsumidorRepository : BaseRepository<Consumidor>, IConsumidorRepository
    {
        public ConsumidorRepository(AppDbContext context) : base(context) { }
    }
}
