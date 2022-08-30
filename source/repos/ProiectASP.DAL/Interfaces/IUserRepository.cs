using ProiectASP.DAL.Entities;
using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAll();
        Task<User> GetById(int id);
        Task Create(User user);
        Task Update(User user);
        Task Delete(User user);
        Task<IQueryable<User>> GetAllQuery();
    }
}
