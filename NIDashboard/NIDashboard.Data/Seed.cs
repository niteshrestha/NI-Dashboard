using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NIDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NIDashboard.Data
{
    public static class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "HOD", "Teacher", "Student" };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                //Creating roles and seeding them into database
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //Creating a super user
            var poweruser = new ApplicationUser
            {
                UserName = Configuration.GetSection("AppSettings")["Username"],
                Email = Configuration.GetSection("AppSettings")["UserEmail"]
            };

            string userPassword = Configuration.GetSection("AppSettings")["UserPassword"];
            var user = await userManager.FindByEmailAsync(Configuration.GetSection("AppSettings")["UserEmail"]);

            if (user == null)
            {
                var createPowerUser = await userManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the "HOD" role 
                    await userManager.AddToRoleAsync(poweruser, "HOD");

                }
            }
        }
    }
}
