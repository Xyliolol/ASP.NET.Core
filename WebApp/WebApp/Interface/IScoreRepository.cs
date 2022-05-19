using WebApp.Models;

namespace WebApp.Interface
{
    public interface IScoreRepository : IScore<ScoreModel>
    {

    }
    public interface IScore<T> where T : class
    {
        void Add(T entity);
        void Close(T entity);       
        IEnumerable<T> Get();
        void Action(T entity);
    }
}
