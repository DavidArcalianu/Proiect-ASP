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
    public class InfoController : ControllerBase
    {
        private readonly IInfoManager infoManager;
        public InfoController(IInfoManager manager)
        {
            infoManager = manager;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Get()
        {
            var albums = await infoManager.GetAll();
            return Ok(albums);
        }

        [HttpGet("byId{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var model = await infoManager.GetById(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("create-info")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateInfo([FromBody] InfoModel model)
        {
            await infoManager.CreateInfo(model);
            return Ok("Info added to the database.");
        }

        [HttpDelete("delete-info{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteInfo([FromRoute] int id)
        {
            var response = await infoManager.DeleteInfo(id);
            if (response == -1)
                return Ok("The requested id is not in the database.");

            return Ok("The information has been deleted.");
        }

        [HttpPut("update-info")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateInfo([FromBody] InfoModel model)
        {
            try
            {
                await infoManager.UpdateInfo(model);
                return Ok("Changes made successfully");
            }
            catch (Exception)
            {
                return StatusCode(403);
            }
        }
    }
}
