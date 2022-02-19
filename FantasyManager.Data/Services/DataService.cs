using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FantasyManager.Data.Services
{
    public class DataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly FootballContextFactory _contextFactory;

        public DataService(FootballContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> CreateAsync(T entity)
        {
            using(FootballContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();

                return entities;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

                return entity;
            }
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;

                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
