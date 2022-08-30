using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASP.BLL.Interfaces;
using ProiectASP.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager authManager;

        public AuthController(IAuthManager manager)
        {
            authManager = manager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var result = await authManager.Register(registerModel);
            return result ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await authManager.Login(loginModel);
            return result.Success ? Ok(result) : BadRequest("Failed to login");
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshModel refreshModel)
        {
            var result = await authManager.Refresh(refreshModel);
            return !result.Contains("Bad") ? Ok(result) : BadRequest("Failed to refresh");
        }
    }
}
