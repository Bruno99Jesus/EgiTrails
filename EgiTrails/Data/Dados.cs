using EgiTrails.Models;
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
        private const string ROLE_GUIA = "Guia";
        private const string ROLE_TURISTA = "Turista";

        internal static async Task SeedDefaultAdminAsync(UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, DEFAULT_ADMIN_USER, DEFAULT_ADMIN_PASSWORD, ROLE_ADMINISTRATOR);
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
            await EnsureRoleIsCreated(roleManager, ROLE_GUIA);
            await EnsureRoleIsCreated(roleManager, ROLE_TURISTA);
        }

        private static async Task EnsureRoleIsCreated(RoleManager<IdentityRole> roleManager, String role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        internal static async Task SeedDevUsersAsync(UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, "guia@egi.pt", "egi2021", ROLE_GUIA);
            await EnsureUserIsCreated(userManager, "toze@gmail.com", "ze12345", ROLE_TURISTA);
        }

        internal static void SeedDevData(ApplicationDbContext db)
        {
            if (db.Turista.Any()) return;

            db.Turista.Add(new Turista
            {
                NIF = 325548961,
                Nome = "To Ze",
                Telemovel = 965123745,
                Email = "toze@gmail.com"

            });
            db.SaveChanges();
        }
    }
}
