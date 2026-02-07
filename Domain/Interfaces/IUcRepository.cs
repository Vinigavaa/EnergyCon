using EnergyCom.Domains;

namespace Domain.Interfaces
{
    public interface IUcRepository : IBaseRepository<Uc>
    {
        Task<List<Uc>> GetAll(CancellationToken cancellationToken);
    }
}
