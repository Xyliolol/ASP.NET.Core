using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDBContext _context;
        public UserRepository(MyDBContext context)
        {
            this._context = context;
        }
        public void Add(UserModel entity)
        {
            entity.IsDeleted = false;
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            try
            {
                _context.Remove(id);
                _context.SaveChanges();
            }
            catch
            {
                return;
            }
        }
        public IEnumerable<UserModel> Get()
        {
            var employee =  _context.Users.ToList();
            return (IEnumerable<UserModel>)employee;           
        }
        public void Update(UserModel entity)
        {
            var employee = _context.Users.FirstOrDefault(en => en.Id == entity.Id);
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.Email = entity.Email;
            employee.Company = entity.Company;
            employee.Age = entity.Age;
            employee.IsDeleted = entity.IsDeleted;
            _context.SaveChanges();
        }
    }
}
