using ProiectASP.DAL.Models;
using ProiectASP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> GetAll();
        Task<Order> GetById(int id);
        Task Create(Order order);
        Task Update(Order order);
        Task Delete(Order order);
        Task<IQueryable<Order>> GetAllQuery();
    }
}
