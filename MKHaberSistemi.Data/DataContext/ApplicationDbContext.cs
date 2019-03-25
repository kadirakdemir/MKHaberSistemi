using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Data.DataContext;
using MKHaberSistemi.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MKHaberSistemi.Data.DataContext
{

    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, string, ApplicationUserLogin, ApplicationUserRole,
        ApplicationUserClaim>, IUserStore<ApplicationUser>, IDisposable
    {
        public ApplicationUserStore(ApplicationDbContext context) : base(context) { }
    }

    public class ApplicationRoleStore : RoleStore<ApplicationRole, string, ApplicationUserRole>, IRoleStore<ApplicationRole>, IDisposable
    {
        public ApplicationRoleStore(ApplicationDbContext context) : base(context)
        {
        }
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
       
        public ApplicationDbContext() : base("MKHaberContext")
        {
            //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            //Database.SetInitializer<ApplicationDbContext>(null);
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
            Configuration.LazyLoadingEnabled = true;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ApplicationUser>().ToTable("Kullanici", "identity").HasKey(p => p.Id);            
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("KullaniciHak", "identity").HasKey(p => p.Id);
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("KullaniciOturum", "identity").HasKey(p => new { p.LoginProvider, p.ProviderKey, p.UserId });
            modelBuilder.Entity<ApplicationUserRole>().ToTable("KullaniciRol", "identity").HasKey(c => new { c.UserId, c.RoleId });
            modelBuilder.Entity<ApplicationRole>().ToTable("Rol", "identity").HasKey(p => p.Id);

            modelBuilder.Entity<ApplicationUser>().HasOptional<EmailAyarlari>(p => p.EmailAyarlari).WithOptionalPrincipal(c => c.Kullanici);
            modelBuilder.Entity<ApplicationUser>().HasMany<Haber>(k => k.Haberler).WithRequired(h => h.Kullanici).HasForeignKey(h => h.KullaniciID);

            modelBuilder.Configurations.Add(new KategoriMap());
            modelBuilder.Configurations.Add(new EtiketMap());
            modelBuilder.Configurations.Add(new HaberTipMap());
            modelBuilder.Configurations.Add(new HaberPozisyonMap());
            modelBuilder.Configurations.Add(new GaleriMap());
            modelBuilder.Configurations.Add(new YorumMap());
            modelBuilder.Configurations.Add(new ResimMap());
            modelBuilder.Configurations.Add(new EmailAyarlariMap());
            modelBuilder.Configurations.Add(new HaberMap());        

        }

        // public DbSet<Kullanici> kullanici { get; set; }
        public DbSet<HaberTip> HaberTip { get; set; }
        public DbSet<HaberPozisyon> HaberPozisyon { get; set; }

        public class SeedApplicationDbContext : CreateDatabaseIfNotExists<ApplicationDbContext>
        {
            protected override void Seed(ApplicationDbContext context)
            {
                //    List<Rol> roles = new List<Rol>
                //{
                //    new Rol { Name = "Supervizor"   },
                //    new Rol { Name = "Admin"        },
                //    new Rol { Name = "Moderator"    },
                //    new Rol { Name = "Editor"       },
                //    new Rol { Name = "Author"       }
                //};



                //context.Roles.Add(new ApplicationRole { Name = "Admin" });
                //context.Roles.Add(new ApplicationRole { Name = "Supervizor" });                
                //context.Roles.Add(new ApplicationRole { Name = "Moderator" });                
                //context.Roles.Add(new ApplicationRole { Name = "Editor" });
                //context.Roles.Add(new ApplicationRole { Name = "Author" });

               

                //context.Users.Add(new ApplicationUser
                //{
                //    Email = "kadirakdemir@hotmail.com",
                //    PasswordHash = "123456",
                //    Name = "Kadir",
                //    SurName = "Akdemir",
                //    UserName = "Kadir",
                //    SecurityStamp = "as"
                //});

                
                

                //context.HaberTip.Add(new HaberTip
                //{
                //    Ad = "Haber",
                //    IsActive = true,
                //    EklemeTarihi = DateTime.Now,
                //    GuncellemeTarihi = DateTime.Now,
                //    EkleyenKullaniciId = "0",
                //    GuncelleyenKullaniciId = "0"
                //});

                //context.HaberTip.Add(new HaberTip
                //{
                //    Ad = "Köşe Yazısı",
                //    IsActive = true,
                //    EklemeTarihi = DateTime.Now,
                //    GuncellemeTarihi = DateTime.Now,
                //    EkleyenKullaniciId = "0",
                //    GuncelleyenKullaniciId = "0"
                //});

                //context.HaberPozisyon.Add(new HaberPozisyon
                //{
                //    Ad = "Sol Manşet",
                //    IsActive = true,
                //    EklemeTarihi = DateTime.Now,
                //    GuncellemeTarihi = DateTime.Now,
                //    EkleyenKullaniciId = "0",
                //    GuncelleyenKullaniciId = "0"
                //});
                //context.HaberPozisyon.Add(new HaberPozisyon
                //{
                //    Ad = "Sol Manşet",
                //    IsActive = true,
                //    EklemeTarihi = DateTime.Now,
                //    GuncellemeTarihi = DateTime.Now,
                //    EkleyenKullaniciId = "0",
                //    GuncelleyenKullaniciId = "0"
                //});
                //context.HaberPozisyon.Add(new HaberPozisyon
                //{
                //    Ad = "Sağ Manşet",
                //    IsActive = true,
                //    EklemeTarihi = DateTime.Now,
                //    GuncellemeTarihi = DateTime.Now,
                //    EkleyenKullaniciId = "0",
                //    GuncelleyenKullaniciId = "0"
                //});
            }
        }
    }
}



