namespace WebApp
{
    public interface IRepository<T>
    {
        List<T> GetEmployeerById(int Id);
        List<T> GetEmployeerByName(string Firstname);
        List<T> UpdateEmployeer(T entity);
        List<T> AddEmployeer (T entity);
        List<T> DeleteEmployeer (T entity);
    }

}
