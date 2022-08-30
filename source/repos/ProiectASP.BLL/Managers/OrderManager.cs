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
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository orderRepo;

        public OrderManager(IOrderRepository repo)
        {
            orderRepo = repo;
        }

        public async Task CreateOrder(OrderModel model)
        {
            var order = new Order
            {
                Address = model.Address,
                Price = model.Price,
                OrderDate = model.OrderDate,
                ShippingDate = model.ShippingDate
            };

            await orderRepo.Create(order);
        }
        public async Task UpdateOrder(OrderModel model)
        {
            var order = await orderRepo.GetById(model.Id);
            if (order == null)
            {
                throw new Exception();
            }

            order.Address = model.Address;
            await orderRepo.Update(order);
        }

        public async Task<int> DeleteOrder(int id)
        {
            var order = await orderRepo.GetById(id);
            if (order == null)
            {
                return -1;
            }

            await orderRepo.Delete(order);
            return 1;
        }

        public async Task<List<OrderModel>> GetAll()
        {
            var orders = await orderRepo.GetAll();
            return orders;
        }
    }
}
