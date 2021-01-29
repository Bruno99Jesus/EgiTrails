using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgiTrails.Data
{
    public class Dados
    {
        private const string DEFAULT_ADMIN_USER = "trilhos@egi.pt";
        private const string DEFAULT_ADMIN_PASSWORD = "egi2021";
        private const string ROLE_ADMINISTRATOR = "Admin";

        internal static async Task SeedDefaultAdminAsync(UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, DEFAULT_ADMIN_USER, DEFAULT_ADMIN_PASSWORD,ROLE_ADMINISTRATOR);
        }

        private static async Task EnsureUserIsCreated(UserManager<IdentityUser> userManager, string username, string password, string role)
        {
            IdentityUser user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                user = new IdentityUser(username);
                await userManager.CreateAsync(user, password);
            }
            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }

        internal static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            await EnsureRoleIsCreated(roleManager, ROLE_ADMINISTRATOR);
        }

        private static async Task EnsureRoleIsCreated(RoleManager<IdentityRole> roleManager,String role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        internal static void SeedDevUsers(UserManager<IdentityUser> userManager)
        {
           // EnsureUserIsCreated(userManager)
        }
    }
}
