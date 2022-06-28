using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Movie_Cart.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _db;
        public EntityBaseRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity= await _db.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry entityEntry = _db.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _db.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _db.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
            
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _db.Set<T>().FirstOrDefaultAsync(x=> x.Id== id);
            return result;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _db.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
