namespace WebApp
{
    public interface IRepository< T > where T : class  
    {
        IList<T> GetById (int id );

    }
}
