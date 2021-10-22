using CarDealership.Models;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(CarDealership.UI.Startup))]
namespace CarDealership.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<AppUser>(new UserStore<AppUser>(context));

            if (!roleManager.RoleExists("admin"))
            {
                var user = new AppUser();
                user.Email = "adminTest@guildCars.edu";
                user.UserName = "admin";

                var role = new AppRole();
                role.Name = "admin";
                roleManager.Create(role);

                string userPWD = "testing123";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "admin");
                }
            }

            if (!roleManager.RoleExists("sales"))
            {
                var role = new AppRole();
                role.Name = "sales";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("disabled"))
            {
                var role = new AppRole();
                role.Name = "disabled";
                roleManager.Create(role);
            }

        }

    }
}
