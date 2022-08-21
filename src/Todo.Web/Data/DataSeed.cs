using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Todo.Web.Data.Entities;

namespace Todo.Web.Data
{
    public static class DataSeed
    {
        private const string AdminRoleName = "Admin";
        private const string UserRoleName = "User";

        private const string AdminLogin = "Admin";
        private const string AdminPassword = "V868171v#";
        private const string AdminEmail = "Adm123456@gmail.com";

        private const string UserLogin = "User";
        private const string UserPassword = "V868171v#";
        private const string UserEmail = "Usr123456@gmail.com";

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(UserRoleName).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = UserRoleName;
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync(AdminRoleName).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = AdminRoleName;
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }

        private static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync(UserLogin).Result == null)
            {
                User user = new User();
                user.UserName = UserLogin;
                user.Email = UserEmail;
                user.Name = "John Doe";

                IdentityResult result = userManager.CreateAsync(user, UserPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, UserRoleName).Wait();
                }
            }


            if (userManager.FindByNameAsync(AdminLogin).Result == null)
            {
                User user = new User();
                user.UserName = AdminLogin;
                user.Email = AdminEmail;
                user.Name = "John Doe";

                IdentityResult result = userManager.CreateAsync(user, AdminPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, AdminRoleName).Wait();
                }
            }
        }

        public static void SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
    }
}
