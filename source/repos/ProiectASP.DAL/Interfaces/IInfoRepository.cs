using ProiectASP.DAL.Entities;
using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Interfaces
{
    public interface IInfoRepository
    {
        Task<List<InfoModel>> GetAll();
        Task<Info> GetById(int id);
        Task Create(Info desc);
        Task Update(Info desc);
        Task Delete(Info desc);
        IQueryable<Info> GetAllQuery();
    }
}
