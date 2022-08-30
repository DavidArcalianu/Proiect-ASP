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
    public class AlbumOrderManager : IAlbumOrderManager
    {
        private readonly IAlbumOrderRepository albumOrderRepo;

        public AlbumOrderManager(IAlbumOrderRepository repo)
        {
            albumOrderRepo = repo;
        }

        public async Task CreateAlbumOrder(AlbumOrderModel model)
        {
            var albumOrder = new AlbumOrder
            {
                AlbumId = model.AlbumId,
                OrderId = model.OrderId,
                Quantity = model.Quantity
            };

            await albumOrderRepo.Create(albumOrder);
        }
        public async Task UpdateAlbumOrder(AlbumOrderModel model)
        {
            var albumOrder = await albumOrderRepo.GetById(model.Id);
            if (albumOrder == null)
            {
                throw new Exception();
            }

            albumOrder.Quantity = albumOrder.Quantity;
            await albumOrderRepo.Update(albumOrder);
        }

        public async Task<int> DeleteAlbumOrder(int id)
        {
            var albumOrder = await albumOrderRepo.GetById(id);
            if (albumOrder == null)
            {
                return -1;
            }

            await albumOrderRepo.Delete(albumOrder);
            return 1;
        }

        public async Task<List<AlbumOrderModel>> GetAll()
        {
            var albumOrders = await albumOrderRepo.GetAll();
            return albumOrders;
        }

        public List<Album> GetOrderItems(int id)
        {
            var albumOrders = albumOrderRepo.GetFullList().Where(x => x.OrderId == id).Select(x => x.Album).ToList();
            if (albumOrders == null)
                throw new Exception();
            return albumOrders;
        }
    }
}
