using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.BLL.Interfaces
{
    public interface IUserManager
    {
        Task<int> DeleteUser(int id);
        Task<List<UserModel>> GetAll();
    }
}
