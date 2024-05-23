using Microsoft.AspNetCore.Identity;
using TM.Application.Common.Models.Roles;

namespace TM.API.Helpers
{
    public class SeedHelper
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (roleManager != null)
            {
                var roles = new[] { Roles.Admin, Roles.Member };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.ToString()))
                        await roleManager.CreateAsync(new IdentityRole(role.ToString()));
                }
            }
        }
        public static async Task SeedAdminAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            if (userManager != null)
            {
                var adminEmail = "admin@admin.com";
                var adminPassword = "Admin123!";
                
                if(await userManager.FindByEmailAsync(adminEmail) is null)
                {
                    var admin = new IdentityUser { UserName = adminEmail, Email = adminEmail };
                    await userManager.CreateAsync(admin, adminPassword);

                    await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
                }
            }
        }
    }
}
