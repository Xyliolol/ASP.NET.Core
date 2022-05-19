using WebApp.Models;

namespace WebApp.Interface
{
    public interface IScoreRepository : IScore<ScoreModel>
    {

    }
    public interface IScore<T> where T : class
    {
        Task Add();
        Task Close(T entity);       
        IEnumerable<T> Get();
        Task Action(T entity);
    }
}
