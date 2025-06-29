namespace MVC.BLL.Interfaces
{
    public interface IGenereicRepository<T>
    {
        int Add(T entity);
        void Delete(T entity);
        void Delete(int id);
        T? Get(int id);
        IEnumerable<T> GetAll();
        int Update(T entity);
    }
}
