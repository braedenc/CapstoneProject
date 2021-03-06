﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Vacay.Models;

[assembly: OwinStartupAttribute(typeof(Vacay.Startup))]
namespace Vacay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);                 

                var user = new ApplicationUser();
                user.UserName = "braedenchriske@gmail.com";
                user.Email = "braedenchriske@gmail.com";

                string userPWD = "Braedenc!1";

                var chkUser = UserManager.Create(user, userPWD);
   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }
    
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }

        }
    }
}
