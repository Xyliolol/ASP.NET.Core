namespace WebApp.Repositories
{
    public interface IEmployeerRepository : IEmpRepository<EmployeerModel>
    {
    }
    public interface IEmpRepository<T> where T : class
    { 
        IEnumerable<T> Get();
        void Update(T entity);
        void Add(T entity);
        void Delete(int id);
    }
}
