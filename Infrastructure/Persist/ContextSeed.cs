using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persist
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync( RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(RoleType.Admin.ToString()));
        }
        public static async Task SeedAdminAsync(UserManager<Admin> userManager)
        {
            var defaultAdmin = new Admin("lilmahyar@protonmail.com");
            if (userManager.Users.All(u => u.Id != defaultAdmin.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultAdmin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultAdmin,"mahyar@2022");
                    await userManager.AddToRoleAsync(defaultAdmin, RoleType.Admin.ToString());
                }
            }
        }
    }
}
