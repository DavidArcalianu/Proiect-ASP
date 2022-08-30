using Microsoft.EntityFrameworkCore;
using ProiectASP.DAL.Entities;
using ProiectASP.DAL.Interfaces;
using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public async Task Create(User user)
        {
            await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
        }
        public async Task Update(User user)
        {
            appDbContext.Users.Update(user);
            await appDbContext.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            appDbContext.Remove(user);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<UserModel>> GetAll()
        {
            var users = await (await GetAllQuery()).ToListAsync();
            var list = new List<UserModel>();
            foreach (var user in users)
            {
                var userModel = new UserModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = user.PasswordHash
                };
                list.Add(userModel);
            }
            return list;
        }

        public async Task<IQueryable<User>> GetAllQuery()
        {
            var query = appDbContext.Users.AsQueryable();
            return query;
        }

        public async Task<User> GetById(int id)
        {
            var user = await appDbContext.Users.FindAsync(id);
            return user;
        }
    }
}
