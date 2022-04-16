using WebApp.Models;

namespace WebApp.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyDBContext _context;
        public PersonRepository(MyDBContext context)
        {
            this._context = context;
        }
        public void Add(PersonModel entity)
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
        public IEnumerable<PersonModel> Get()
        {
            var employee = _context.Employeers.ToList();
            return (IEnumerable<PersonModel>)employee;
        }
        public void Update(PersonModel entity)
        {
            var employee =  _context.Persons.FirstOrDefault(en => en.Id == entity.Id);
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
