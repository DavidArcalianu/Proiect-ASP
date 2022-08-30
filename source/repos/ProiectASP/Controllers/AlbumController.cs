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
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumManager albumManager;
        public AlbumController(IAlbumManager manager)
        {
            albumManager = manager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var albums = await albumManager.GetAll();
            return Ok(albums);
        }

        [HttpGet("byId{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var model = await albumManager.GetById(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("byName{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            try
            {
                var model = await albumManager.GetByName(name);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("byGenre{genre}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByGenre([FromRoute] string genre)
        {
            try
            {
                var models = await albumManager.GetByGenre(genre);
                return Ok(models);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("sorted")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSorted()
        {
            var list = await albumManager.GetSorted();
            return Ok(list);
        }

        [HttpPost("create-album")]
        [Authorize("Admin")]
        public async Task<IActionResult> CreateAlbum([FromBody] AlbumModel album)
        {
            await albumManager.CreateAlbum(album);
            return Ok("Album added to the database.");
        }

        [HttpDelete("delete-album{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteAlbum([FromRoute] int id)
        {
            var response = await albumManager.DeleteAlbum(id);
            if (response == -1)
                return Ok("The requested id is not in the database.");

            return Ok("The album has been deleted.");
        }

        [HttpPut("update-album")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateAlbum([FromBody] AlbumModel model)
        {
            try
            {
                await albumManager.UpdateAlbum(model);
                return Ok("Changes made successfully");
            }
            catch (Exception)
            {
                return StatusCode(403);
            }
        }
    }
}
