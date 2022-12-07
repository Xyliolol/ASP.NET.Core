using WebApp.Models;

namespace WebApp.Repositories
{
    public interface IPersonRepository : IRepository<PersonModel>
    {      
    }
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        void Update(T entity);
        void Add(T entity);
        void Delete(int id);
    }
}
