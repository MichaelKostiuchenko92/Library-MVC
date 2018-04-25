using Library.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DLL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private LibraryContext _databaseLibraryContext;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(string connection)
        {
            _databaseLibraryContext = new LibraryContext(connection);
            _dbSet = _databaseLibraryContext.Set<TEntity>();
        }

        public virtual void Create(TEntity item)
        {
            _dbSet.Add(item);
            _databaseLibraryContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            _databaseLibraryContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public virtual void Update(TEntity item)
        {
            _databaseLibraryContext.Entry(item).State = EntityState.Modified;
            _databaseLibraryContext.SaveChanges();
        }

        public void Dispose ()
        {
            _databaseLibraryContext.Dispose();
        }
    }
}
