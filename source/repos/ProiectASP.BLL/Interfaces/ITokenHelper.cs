using ProiectASP.DAL.Entities;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.BLL.Interfaces
{
    public interface ITokenHelper
    {
        Task<string> CreateAccessToken(User user);
        string CreateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
