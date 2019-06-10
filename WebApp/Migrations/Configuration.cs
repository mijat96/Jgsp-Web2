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
            if (!context.RedoviVoznje.Any(u => u.Linija.RedniBroj == "1"))
            {
                RedVoznje red = new RedVoznje();
                RedVoznje red2 = new RedVoznje();
           
          
                red.Id = 1;
                red2.Id = 2;
               
              
                Linija lin = new Linija();
                Linija lin2 = new Linija();
                Linija lin3 = new Linija();
                lin.Id = 1;
                lin.RedniBroj = "1";
                red.DanUNedelji = "Nedelja";
                red.Polasci = "11:00 12:21";
                red2.DanUNedelji = "Subota";
                red2.Polasci = "12:00 15:21";

                lin.RedoviVoznje = new List<RedVoznje>();

                lin2.RedoviVoznje = new List<RedVoznje>();
                lin3.RedoviVoznje = new List<RedVoznje>();
                lin.RedoviVoznje.Add(red);
                lin.RedoviVoznje.Add(red2);
                lin2.RedniBroj = "2";
                lin2.Id = 2;
               
                lin3.RedniBroj = "3";
                lin3.Id = 3;

                context.RedoviVoznje.Add(red);
                context.RedoviVoznje.Add(red2);
                context.Linije.Add(lin);
                context.Linije.Add(lin2);
                context.Linije.Add(lin3);
              
                context.SaveChanges();
            }
            if (!context.CeneKarti.Any(u => u.Cena==200))
            {
                //var user1 = new ApplicationUser() { Id = "appu1", UserName = "appu1@yahoo.com", Email = "appu1@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Appu1123!"), Tip = "student", Name = "dasdas", Surname = "dasdasda" };
                //userManager.Create(user1);
                //userManager.AddToRole(user1.Id, "AppUser");



                Cenovnik cenovnik = new Cenovnik();
                cenovnik.CeneKarti = new List<CenaKarte>();

                CenaKarte cenaKarte = new CenaKarte();
                CenaKarte cenaKarte2 = new CenaKarte();
                CenaKarte cenaKarte3 = new CenaKarte();
                CenaKarte cenaKarte4 = new CenaKarte();

                cenaKarte.Karte = new List<Karta>();
                cenaKarte2.Karte = new List<Karta>();
                cenaKarte3.Karte = new List<Karta>();
                cenaKarte4.Karte = new List<Karta>();
                cenaKarte.Cena = 90;
                cenaKarte2.Cena = 4500;
                cenaKarte3.Cena = 900;
                cenaKarte4.Cena = 100;

                cenovnik.VaziDo = DateTime.UtcNow;
                cenovnik.VaziOd = DateTime.UtcNow;

               




                cenaKarte.Cenovnik = cenovnik;
                cenaKarte.TipKarte = "Dnevna";
                cenaKarte.TipKupca = "Student";
                cenaKarte2.TipKarte = "Godisnja";
                cenaKarte2.TipKupca = "Student";
                cenaKarte3.TipKarte = "Mesecna";
                cenaKarte3.TipKupca = "Student";
                cenaKarte4.TipKarte = "Dnevna";
                cenaKarte4.TipKupca = "Obican";
                cenovnik.CeneKarti.Add(cenaKarte);
                cenovnik.CeneKarti.Add(cenaKarte2);
                cenovnik.CeneKarti.Add(cenaKarte3);
                cenovnik.CeneKarti.Add(cenaKarte4);
                Karta kartaDnevna = new Karta();
                kartaDnevna.Tip = "Dnevna";
                kartaDnevna.IdKarte = 1;
                //user1.Karte = new List<Karta>();
                //user1.Karte.Add(kartaDnevna);
                //kartaDnevna.ApplicationUser = user1;
                //kartaDnevna.CekiranaUTrenutku = DateTime.UtcNow;

                //kartaDnevna.CenaKarteId = cenaKarte.IdCenaKarte;
                kartaDnevna.CenaKarte = cenaKarte;

                cenaKarte.Karte.Add(kartaDnevna);

                context.Karte.Add(kartaDnevna);
                context.CeneKarti.Add(cenaKarte);
                context.CeneKarti.Add(cenaKarte2);
                context.CeneKarti.Add(cenaKarte3);
                context.CeneKarti.Add(cenaKarte4);

                context.Cenovnici.Add(cenovnik);
            }
        }
    }
}
