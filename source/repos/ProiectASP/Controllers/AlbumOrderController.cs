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
    public class AlbumOrderController : ControllerBase
    {
        private readonly IAlbumOrderManager albumManager;
        public AlbumOrderController(IAlbumOrderManager manager)
        {
            albumManager = manager;
        }

        [HttpGet]
        [Authorize("Admin")]
        public async Task<IActionResult> Get()
        {
            var objs = await albumManager.GetAll();
            return Ok(objs);
        }

        [HttpGet("get-list{id}")]
        [Authorize("Customer, Admin")]
        public async Task<IActionResult> GetListOfItems([FromRoute] int id)
        {
            try
            {
                var albums = albumManager.GetOrderItems(id);
                return Ok(albums);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("create-albumOrder")]
        [Authorize("Customer, Admin")]
        public async Task<IActionResult> CreateAlbumOrder([FromBody] AlbumOrderModel model)
        {
            await albumManager.CreateAlbumOrder(model);
            return Ok("Album order added to the database.");
        }

        [HttpDelete("delete-albumOrder{id}")]
        [Authorize("Customer, Admin")]
        public async Task<IActionResult> DeleteAlbumOrder([FromRoute] int id)
        {
            var response = await albumManager.DeleteAlbumOrder(id);
            if (response == -1)
                return Ok("The requested id is not in the database.");

            return Ok("The album order has been deleted.");
        }

        [HttpPut("update-albumOrder")]
        [Authorize("Customer, Admin")]
        public async Task<IActionResult> UpdateAlbumOrder([FromBody] AlbumOrderModel model)
        {
            try
            {
                await albumManager.UpdateAlbumOrder(model);
                return Ok("Changes made successfully");
            }
            catch (Exception)
            {
                return StatusCode(403);
            }
        }
    }
}
