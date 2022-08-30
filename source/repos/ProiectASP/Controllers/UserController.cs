using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASP.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager manager)
        {
            userManager = manager;
        }

        [HttpGet]
        [Authorize("Admin")]
        public async Task<IActionResult> Get()
        {
            var albums = await userManager.GetAll();
            return Ok(albums);
        }

        [HttpDelete("delete-user{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteDescription([FromRoute] int id)
        {
            var response = await userManager.DeleteUser(id);
            if (response == -1)
                return Ok("The requested id is not in the database.");

            return Ok("The offer has been deleted.");
        }
    }
}
