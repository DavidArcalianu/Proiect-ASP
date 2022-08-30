using Microsoft.AspNetCore.Identity;
using ProiectASP.BLL.Interfaces;
using ProiectASP.BLL.Models;
using ProiectASP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.BLL.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenHelper tokenHelper;

        public AuthManager(UserManager<User> user,
            SignInManager<User> signIn,
            ITokenHelper token)
        {
            userManager = user;
            signInManager = signIn;
            tokenHelper = token;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var user = await userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
                return new LoginResult
                {
                    Success = false
                };
            else
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
                if (result.Succeeded)
                {
                    var token = await tokenHelper.CreateAccessToken(user);
                    var refreshToken = tokenHelper.CreateRefreshToken();

                    user.RefreshToken = refreshToken;
                    await userManager.UpdateAsync(user);

                    return new LoginResult
                    {
                        Success = true,
                        AccessToken = token,
                        RefreshToken = refreshToken
                    };
                }
                else
                    return new LoginResult
                    {
                        Success = false
                    };
            }
        }

        public async Task<bool> Register(RegisterModel registerModel)
        {
            var user = new User
            {
                Email = registerModel.Email,
                UserName = registerModel.Email
            };

            var result = await userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, registerModel.Role);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> Refresh(RefreshModel refreshModel)
        {
            var principal = tokenHelper.GetPrincipalFromExpiredToken(refreshModel.AccessToken);
            var username = principal.Identity.Name;

            var user = await userManager.FindByEmailAsync(username);

            if (user.RefreshToken != refreshModel.RefreshToken)
                return "Bad Refresh";

            var newJwtToken = await tokenHelper.CreateAccessToken(user);

            return newJwtToken;
        }
    }
}
