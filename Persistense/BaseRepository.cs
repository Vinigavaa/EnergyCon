using Domain.Entidades;
using Domain.Interfaces;
using EnergyCom.Context;
using Microsoft.EntityFrameworkCore;

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
            entity.CreatedAt = DateTime.Now;
            Context.Add(entity);
        }
         
        public void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            Context.Add(entity);
        }

        public void Delete(T entity)
        {
            entity.DeleteAt = DateTime.Now;
            Context.Add(entity);
        }

        public async Task<List<T>> GetById(int id, CancellationToken cancellation)
        {
            return await Context.Set<T>().ToListAsync(cancellation);
        }

        public async Task<T> Get(int id, CancellationToken cancellation)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellation);
        }
    }
}
