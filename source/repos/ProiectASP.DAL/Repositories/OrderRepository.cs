using Microsoft.EntityFrameworkCore;
using ProiectASP.DAL.Entities;
using ProiectASP.DAL.Interfaces;
using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext appDbContext;

        public OrderRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public async Task Create(Order order)
        {
            await appDbContext.Orders.AddAsync(order);
            await appDbContext.SaveChangesAsync();
        }
        public async Task Update(Order order)
        {
            appDbContext.Orders.Update(order);
            await appDbContext.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            appDbContext.Remove(order);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<OrderModel>> GetAll()
        {
            var orders = await (await GetAllQuery()).ToListAsync();
            var list = new List<OrderModel>();
            foreach (var order in orders)
            {
                var orderModel = new OrderModel
                {
                    Id = order.Id,
                    Address = order.Address,
                    Price = order.Price,
                    OrderDate = order.OrderDate,
                    ShippingDate = order.ShippingDate,
                    UserId = order.UserId

                };
                list.Add(orderModel);
            }
            return list;
        }

        public async Task<IQueryable<Order>> GetAllQuery()
        {
            var query = appDbContext.Orders.AsQueryable();
            return query;
        }

        public async Task<Order> GetById(int id)
        {
            var order = await appDbContext.Orders.FindAsync(id);
            return order;
        }
    }
}
