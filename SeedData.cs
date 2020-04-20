using aspnet_tut1.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace aspnet_tut1
{
    public static class SeedData
    {
        public static void Seed(UserManager<Employee> userManager,
                                RoleManager<IdentityRole> roleManager)
        {
         
        SeedRoles(roleManager, "administrator");
        SeedUsers(userManager, "admin@admin.com", "administrator");

        }
        private static void SeedUsers(UserManager<Employee> userManager, string userName, string userRole)
        {

            if (userManager.FindByNameAsync(userName).Result == null)
            {
                var user = new Employee
                {
                    UserName = userName,
                    Email = "test@test.com"
                };

                var userCreationResult = userManager.CreateAsync(user, "P@ssword1!!!").Result;

                if (userCreationResult.Succeeded)
                {
                    var result =  userManager.AddToRoleAsync(user, userRole).Result;
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var role = new IdentityRole { Name = roleName };

            if (!roleManager.RoleExistsAsync(roleName).Result)
            {
                var result = roleManager.CreateAsync(role).Result;
            }
        } 
    }
}
