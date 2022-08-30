using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.BLL.Interfaces
{
    public interface IInfoManager
    {
        Task CreateInfo(InfoModel model);
        Task<InfoModel> GetById(int id);
        Task<int> DeleteInfo(int id);
        Task<List<InfoModel>> GetAll();
        Task UpdateInfo(InfoModel model);
    }
}
