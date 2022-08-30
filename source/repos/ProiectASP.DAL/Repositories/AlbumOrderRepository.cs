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
    public class AlbumOrderRepository : IAlbumOrderRepository
    {
        private readonly AppDbContext appDbContext;

        public AlbumOrderRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public async Task Create(AlbumOrder albumOrder)
        {
            await appDbContext.AlbumOrders.AddAsync(albumOrder);
            await appDbContext.SaveChangesAsync();
        }
        public async Task Update(AlbumOrder albumOrder)
        {
            appDbContext.AlbumOrders.Update(albumOrder);
            await appDbContext.SaveChangesAsync();
        }
        public async Task Delete(AlbumOrder albumOrder)
        {
            appDbContext.Remove(albumOrder);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<AlbumOrderModel>> GetAll()
        {
            var orders = await (await GetAllQuery()).ToListAsync();
            var list = new List<AlbumOrderModel>();
            foreach (var order in orders)
            {
                var model = new AlbumOrderModel
                {
                    Id = order.Id,
                    AlbumId = order.AlbumId,
                    OrderId = order.OrderId,
                    Quantity = order.Quantity
                };
                list.Add(model);
            }
            return list;
        }

        public async Task<IQueryable<AlbumOrder>> GetAllQuery()
        {
            var query = appDbContext.AlbumOrders.AsQueryable();
            return query;
        }
        public IQueryable<AlbumOrder> GetFullList()
        {
            var query = appDbContext.AlbumOrders.Include(x => x.Album).AsQueryable();
            return query;
        }

        public async Task<AlbumOrder> GetById(int id)
        {
            var albumOrder = await appDbContext.AlbumOrders.FindAsync(id);
            return albumOrder;
        }
    }
}
