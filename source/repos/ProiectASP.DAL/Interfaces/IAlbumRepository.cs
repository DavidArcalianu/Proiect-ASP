using ProiectASP.DAL.Entities;
using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Interfaces
{
    public interface IAlbumRepository
    {
        Task<List<AlbumModel>> GetAll();
        Task<Album> GetById(int id);
        Task Create(Album album);
        Task Update(Album album);
        Task Delete(Album album);
        IQueryable<Album> GetAllQuery();
    }
}