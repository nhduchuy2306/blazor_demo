using Microsoft.EntityFrameworkCore;
using ServerLibrary.Models;

namespace ServerLibrary.Repositories
{
    public abstract class AbstractRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly ManagementdbContext _context;

        protected AbstractRepository(ManagementdbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity? GetById(TKey id)
        {
            return _context.Set<TEntity>().SingleOrDefault(e => e.Equals(id));
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.ChangeTracker.Clear();
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
