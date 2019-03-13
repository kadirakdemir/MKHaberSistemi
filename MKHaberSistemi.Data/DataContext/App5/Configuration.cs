namespace MKHaberSistemi.Data.DataContext.App5
{
    using MKHaberSistemi.Core.Domain.Entities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MKHaberSistemi.Data.DataContext.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContext\App5";
        }

       
        protected override void Seed(MKHaberSistemi.Data.DataContext.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Roles.Add(new ApplicationRole { Id="1", Name = "Admin" });
            context.Roles.Add(new ApplicationRole { Name = "Supervizor" });
            context.Roles.Add(new ApplicationRole { Name = "Moderator" });
            context.Roles.Add(new ApplicationRole { Name = "Editor" });
            context.Roles.Add(new ApplicationRole { Name = "Author" });

            context.Users.Add(new ApplicationUser
            {
                Email = "kadirakdemir@hotmail.com",
                PasswordHash = "123456",
                Name = "Kadir",
                SurName = "Akdemir",
                UserName = "Kadir",
                SecurityStamp = "as"
            });

            
            context.HaberTip.Add(new HaberTip
            {
                Ad = "Haber",
                IsActive = true,
                EklemeTarihi = DateTime.Now,
                GuncellemeTarihi = DateTime.Now,
                EkleyenKullaniciId = "0",
                GuncelleyenKullaniciId = "0"
            });

            context.HaberTip.Add(new HaberTip
            {
                Ad = "Köþe Yazýsý",
                IsActive = true,
                EklemeTarihi = DateTime.Now,
                GuncellemeTarihi = DateTime.Now,
                EkleyenKullaniciId = "0",
                GuncelleyenKullaniciId = "0"
            });

            context.HaberPozisyon.Add(new HaberPozisyon
            {
                Ad = "Sol Manþet",
                IsActive = true,
                EklemeTarihi = DateTime.Now,
                GuncellemeTarihi = DateTime.Now,
                EkleyenKullaniciId = "0",
                GuncelleyenKullaniciId = "0"
            });
            context.HaberPozisyon.Add(new HaberPozisyon
            {
                Ad = "Sol Manþet",
                IsActive = true,
                EklemeTarihi = DateTime.Now,
                GuncellemeTarihi = DateTime.Now,
                EkleyenKullaniciId = "0",
                GuncelleyenKullaniciId = "0"
            });
            context.HaberPozisyon.Add(new HaberPozisyon
            {
                Ad = "Sað Manþet",
                IsActive = true,
                EklemeTarihi = DateTime.Now,
                GuncellemeTarihi = DateTime.Now,
                EkleyenKullaniciId = "0",
                GuncelleyenKullaniciId = "0"
            });
        }
    }
}
