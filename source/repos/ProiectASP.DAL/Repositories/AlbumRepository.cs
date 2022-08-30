using Microsoft.EntityFrameworkCore;
using ProiectASP.DAL.Entities;
using ProiectASP.DAL.Interfaces;
using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AppDbContext appDbContext;

        public AlbumRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public async Task Create(Album album)
        {
            await appDbContext.Albums.AddAsync(album);
            await appDbContext.SaveChangesAsync();
        }
        public async Task Update(Album album)
        {
            appDbContext.Albums.Update(album);
            await appDbContext.SaveChangesAsync();
        }
        public async Task Delete(Album album)
        {
            appDbContext.Remove(album);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<AlbumModel>> GetAll()
        {
            var albums = await GetAllQuery().ToListAsync();
            var list = new List<AlbumModel>();
            foreach (var album in albums)
            {
                var albumModel = new AlbumModel
                {
                    Id = album.Id,
                    Name = album.Name,
                    Genre = album.Genre,
                    Price = album.Price,
                    Image = album.Image
                };
                list.Add(albumModel);
            }
            return list;
        }

        public IQueryable<Album> GetAllQuery()
        {
            var query = appDbContext.Albums.AsQueryable();
            return query;
        }

        public async Task<Album> GetById(int id)
        {
            var album = await appDbContext.Albums.FindAsync(id);
            return album;
        }
    }
}