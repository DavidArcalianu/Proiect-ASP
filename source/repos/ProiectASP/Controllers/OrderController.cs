using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASP.BLL.Interfaces;
using ProiectASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager orderManager;
        public OrderController(IOrderManager manager)
        {
            orderManager = manager;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Get()
        {
            var orders = await orderManager.GetAll();
            return Ok(orders);
        }

        [HttpPost("create-order")]
        [Authorize(Policy = "Customer")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel model)
        {
            await orderManager.CreateOrder(model);
            return Ok("Order added to the database.");
        }

        [HttpDelete("delete-order{id}")]
        [Authorize(Policy = "Customer")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var response = await orderManager.DeleteOrder(id);
            if (response == -1)
                return Ok("The requested id is not in the database.");

            return Ok("The order has been deleted.");
        }

        [HttpPut("update-order")]
        [Authorize(Policy = "Customer")]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderModel model)
        {
            try
            {
                await orderManager.UpdateOrder(model);
                return Ok("Changes made successfully");
            }
            catch (Exception)
            {
                return StatusCode(403);
            }
        }
    }
}
