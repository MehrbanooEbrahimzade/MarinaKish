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
            await roleManager.CreateAsync(new IdentityRole(RoleType.Buyer.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RoleType.Seller.ToString()));


        }
        public static async Task SeedAdminAsync(UserManager<User> userManager)
        {
            var defaultAdmin = new User("maahyar@protonmail.com")
            {
                Email = "maahyar@protonmail.com"
            };
           
            if (userManager.Users.All(u => u.Id != defaultAdmin.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultAdmin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultAdmin,"ano!20mahyar");
                    await userManager.AddToRoleAsync(defaultAdmin, RoleType.Admin.ToString());
                }
            }
        }
    }
}
