namespace WebApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApp.Persistence.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Controller"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Controller" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "AppUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppUser" };

                manager.Create(role);
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            
            if (!context.Users.Any(u => u.UserName == "admin@yahoo.com"))
            {
                var user = new ApplicationUser() { Id = "admin", UserName = "admin@yahoo.com", Email = "admin@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Admin123!"), Tip = "student", Name = "dasdas", Surname = "dasdasda" };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "appu@yahoo.com"))
            { 
                var user = new ApplicationUser() { Id = "appu", UserName = "appu@yahoo.com", Email = "appu@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Appu123!"), Tip = "student", Name = "dasdas", Surname = "dasdasda" };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "AppUser");
            }
            if (!context.RedoviVoznje.Any(u => u.Linija.RedniBroj == 1))
            {
                RedVoznje red = new RedVoznje();
                RedVoznje red2 = new RedVoznje();
           
          
                red.Id = 1;
                red2.Id = 2;
               
              
                Linija lin = new Linija();
                Linija lin2 = new Linija();
                Linija lin3 = new Linija();
                lin.Id = 1;
                lin.RedniBroj = 1;
                red.DanUNedelji = "Nedelja";
                red.Polasci = "11:00 12:21";
                red2.DanUNedelji = "Subota";
                red2.Polasci = "12:00 15:21";

                lin.RedoviVoznje = new List<RedVoznje>();

                lin2.RedoviVoznje = new List<RedVoznje>();
                lin3.RedoviVoznje = new List<RedVoznje>();
                lin.RedoviVoznje.Add(red);
                lin.RedoviVoznje.Add(red2);
                lin2.RedniBroj = 2;
                lin2.Id = 2;
               
                lin3.RedniBroj = 3;
                lin3.Id = 3;

                context.RedoviVoznje.Add(red);
                context.RedoviVoznje.Add(red2);
                context.Linije.Add(lin);
                context.Linije.Add(lin2);
                context.Linije.Add(lin3);
              
                context.SaveChanges();
            }
        }
    }
}
