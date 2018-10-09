using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ESVS
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            //var adminEmail = configuration["AdminLogin"];
            //var password = configuration["AdminPassword"];

            string adminEmail = "vladisa375@gmail.com";
            string password = "Vladball45@";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new Role()
                {
                    Name = "admin"
                });
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new Role()
                {
                    Name = "user"
                });
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                    await userManager.AddToRoleAsync(admin, "user");
                }
            }

        }
    }
}
