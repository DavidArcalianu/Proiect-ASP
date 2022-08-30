using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.BLL.Interfaces
{
    public interface IOrderManager
    {
        Task CreateOrder(OrderModel model);
        Task<int> DeleteOrder(int id);
        Task<List<OrderModel>> GetAll();
        Task UpdateOrder(OrderModel model);
    }
}
