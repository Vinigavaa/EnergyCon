using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistense.Context;

namespace Persistense
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;

        public BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            entity.CreatedAt = DateTimeOffset.Now;
            Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTimeOffset.Now;
            Context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            entity.DeleteAt = DateTimeOffset.Now;
            Context.Set<T>().Remove(entity);
        }

        public async Task<T> GetById(int id, CancellationToken cancellationToken)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }
    }
}
