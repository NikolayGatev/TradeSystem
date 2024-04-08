using Microsoft.AspNetCore.Identity;
using TradeSystem.Data.Models;
using static TradeSystem.Common.RoleConstants;

namespace TradeSystem.Web.Extensions
{
    public static class ApplicationBuilderExtentions
    {
        public static async Task CreateAdminRole(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if(userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdminRole) == false)
            {
                var role = new IdentityRole();
                await roleManager.CreateAsync(role);
            }
        }
    }
}
