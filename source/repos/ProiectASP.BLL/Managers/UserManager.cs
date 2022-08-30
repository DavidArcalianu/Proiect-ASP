using ProiectASP.BLL.Interfaces;
using ProiectASP.DAL.Interfaces;
using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.BLL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepo;

        public UserManager(IUserRepository repo)
        {
            userRepo = repo;
        }
        public async Task<int> DeleteUser(int id)
        {
            var user = await userRepo.GetById(id);
            if (user == null)
            {
                return -1;
            }

            await userRepo.Delete(user);
            return 1;
        }

        public async Task<List<UserModel>> GetAll()
        {
            var users = await userRepo.GetAll();
            return users;
        }
    }
}
