using Microsoft.EntityFrameworkCore;

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

        public void Add(T entity) => _dbSet.Add(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public void Delete(int id) => _dbSet.Remove(_dbSet.Find(id));

        public T? Get(int id) => _dbSet.Find(id);

        public IEnumerable<T> GetAll() => _dbSet.AsNoTracking().ToList();

        public void Update(T entity) => _dbSet.Update(entity);
    }
}
