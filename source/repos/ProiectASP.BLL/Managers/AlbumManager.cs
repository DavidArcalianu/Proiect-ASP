using ProiectASP.BLL.Interfaces;
using ProiectASP.DAL.Entities;
using ProiectASP.DAL.Interfaces;
using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.BLL.Managers
{
    public class AlbumManager : IAlbumManager
    {
        private readonly IAlbumRepository albumRepo;

        public AlbumManager(IAlbumRepository repo)
        {
            albumRepo = repo;
        }

        public async Task CreateAlbum(AlbumModel model)
        {
            var album = new Album
            {
                Name = model.Name,
                Price = model.Price,
                Image = model.Image,
                Genre = model.Genre
            };

            await albumRepo.Create(album);
        }

        public async Task<int> DeleteAlbum(int id)
        {
            var album = await albumRepo.GetById(id);
            if (album == null)
            {
                return -1;
            }

            await albumRepo.Delete(album);
            return 1;
        }

        public async Task<List<AlbumModel>> GetAll()
        {
            var albums = await albumRepo.GetAll();
            return albums;
        }

        public async Task UpdateAlbum(AlbumModel model)
        {
            var album = await albumRepo.GetById(model.Id);
            if (album == null)
            {
                throw new Exception();
            }

            album.Price = model.Price;

            await albumRepo.Update(album);
        }

        public async Task<AlbumModel> GetById(int id)
        {
            var album = albumRepo.GetAllQuery().FirstOrDefault(x => x.Id == id);
            if (album == null)
                throw new Exception();
            var model = new AlbumModel
            {
                Id = album.Id,
                Name = album.Name,
                Price = album.Price,
                Image = album.Image,
                Genre = album.Genre
            };

            return model;
        }

        public async Task<AlbumModel> GetByName(string name)
        {
            var album = albumRepo.GetAllQuery().FirstOrDefault(x => x.Name == name);
            if (album == null)
                throw new Exception();
            var model = new AlbumModel
            {
                Id = album.Id,
                Name = album.Name,
                Price = album.Price,
                Image = album.Image,
                Genre = album.Genre
            };

            return model;
        }

        public async Task<List<AlbumModel>> GetByGenre(string genre)
        {
            var albums = albumRepo.GetAllQuery().Where(x => x.Genre == genre);
            if (albums == null)
                throw new Exception();

            var list = new List<AlbumModel>();
            foreach (var album in albums)
            {
                var model = new AlbumModel
                {
                    Id = album.Id,
                    Name = album.Name,
                    Price = album.Price,
                    Image = album.Image,
                    Genre = album.Genre
                };

                list.Add(model);
            };

            return list;
        }

        public async Task<List<AlbumModel>> GetSorted()
        {
            var albums = albumRepo.GetAllQuery().OrderBy(x => x.Price);
            if (albums == null)
                throw new Exception();

            var list = new List<AlbumModel>();
            foreach (var album in albums)
            {
                var model = new AlbumModel
                {
                    Id = album.Id,
                    Name = album.Name,
                    Price = album.Price,
                    Image = album.Image,
                    Genre = album.Genre
                };

                list.Add(model);
            };

            return list;
        }
    }
}
