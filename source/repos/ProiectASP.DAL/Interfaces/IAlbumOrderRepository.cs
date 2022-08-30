using ProiectASP.DAL.Entities;
using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Interfaces
{
    public interface IAlbumOrderRepository
    {
        Task<List<AlbumOrderModel>> GetAll();
        Task<AlbumOrder> GetById(int id);
        Task Create(AlbumOrder albumOrder);
        Task Update(AlbumOrder albumOrder);
        Task Delete(AlbumOrder albumOrder);
        Task<IQueryable<AlbumOrder>> GetAllQuery();
        public IQueryable<AlbumOrder> GetFullList();
    }
}
