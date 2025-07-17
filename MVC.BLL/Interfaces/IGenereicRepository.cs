namespace MVC.BLL.Interfaces
{
    public interface IGenereicRepository<T>
    {
        Task AddAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(int id);
        Task<T>? GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        void Update(T entity);
    }
}
