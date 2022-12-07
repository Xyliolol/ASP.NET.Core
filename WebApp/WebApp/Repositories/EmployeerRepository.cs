using Microsoft.EntityFrameworkCore;

namespace WebApp.Repositories
{
    public class EmployeerRepository : IEmployeerRepository
    {
       
        private readonly MyDBContext _context;
        public EmployeerRepository(MyDBContext context)
        {
            this._context = context;
        }
        public void Add(EmployeerModel entity)
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
        public IEnumerable<EmployeerModel> Get()
        {
            var employee = _context.Employeers.ToList();
            return employee;
        }
        public void Update(EmployeerModel entity)
        {
            var employee = _context.Employeers.FirstOrDefault(en => en.Id == entity.Id);
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
