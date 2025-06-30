namespace MVC.BLL.Interfaces
{
    public interface IGenereicRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Delete(int id);
        T? Get(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
