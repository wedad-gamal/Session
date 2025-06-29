using Microsoft.EntityFrameworkCore;
using MVC.BLL.Interfaces;
using MVC.DAL.Context;

namespace MVC.BLL.Repositories
{
    public class GenereicRepository<T> : IGenereicRepository<T> where T : class
    {
        protected readonly DataContext _dataContext;
        protected DbSet<T> _dbSet;
        public GenereicRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }

        public int Add(T entity)
        {
            _dbSet.Add(entity);
            return _dataContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            _dataContext.SaveChanges();
        }

        public T? Get(int id) => _dbSet.Find(id);

        public IEnumerable<T> GetAll() => _dbSet.AsNoTracking().ToList();

        public int Update(T entity)
        {
            _dbSet.Update(entity);
            return _dataContext.SaveChanges();
        }
    }
}
