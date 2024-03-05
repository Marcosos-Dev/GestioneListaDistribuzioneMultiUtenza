using GestioneListaDistribuzioneMultiUtenza.Models.Context;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected MyDbContext _ctx;
        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddAsync(T entity)
        {
            await _ctx.Set<T>().AddAsync(entity);
        }


        public async Task<T> GetAsync(object id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _ctx.SaveChangesAsync();
        }

    }
}
