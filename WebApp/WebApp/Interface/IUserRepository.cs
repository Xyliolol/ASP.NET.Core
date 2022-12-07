﻿using WebApp.Models;

namespace WebApp.Repositories
{
    public interface IUserRepository : IUsRepository<UserModel>
    {    
    }
    public interface IUsRepository<T> where T : class
    {
        IEnumerable<T> Get();
        void Update(T entity);
        void Add(T entity);
        void Delete(int id);
    }
}
