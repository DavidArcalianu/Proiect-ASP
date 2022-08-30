using ProiectASP.DAL.Models;
using ProiectASP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.BLL.Interfaces
{
    public interface IAlbumOrderManager
    {
        Task CreateAlbumOrder(AlbumOrderModel model);
        Task UpdateAlbumOrder(AlbumOrderModel model);
        Task<int> DeleteAlbumOrder(int id);
        Task<List<AlbumOrderModel>> GetAll();
        List<Album> GetOrderItems(int id);
    }
}
