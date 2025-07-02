namespace MVC.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>() where TRepository : class;
        public int SaveChanges();
    }
}
