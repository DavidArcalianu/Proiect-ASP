using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.BLL.Interfaces
{
    public interface IAlbumManager
    {
        Task CreateAlbum(AlbumModel model);
        Task UpdateAlbum(AlbumModel model);
        Task<int> DeleteAlbum(int id);
        Task<List<AlbumModel>> GetAll();
        Task<AlbumModel> GetById(int id);
        Task<AlbumModel> GetByName(string name);
        Task<List<AlbumModel>> GetByGenre(string genre);
        Task<List<AlbumModel>> GetSorted();
    }
}
