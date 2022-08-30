using Microsoft.AspNetCore.Identity;
using ProiectASP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectASP.DAL
{
    public class InitialSeed
    {
        private readonly RoleManager<Role> roleManager;

        public InitialSeed(RoleManager<Role> role)
        {
            roleManager = role;
        }

        public async void CreateRoles()
        {
            string[] roleNames = {
                                "Admin",
                                "Customer"
                                };

            foreach (var roleName in roleNames)
            {
                var role = new Role
                {
                    Name = roleName
                };
                roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
