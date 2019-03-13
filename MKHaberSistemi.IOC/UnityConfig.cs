using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Data.DataContext;
using MKHaberSistemi.Data.Repository;
using MKHaberSistemi.Data.UnitOfWork;
using MKHaberSistemi.Service.EtiketService;
using MKHaberSistemi.Service.HaberService;
using MKHaberSistemi.Service.IdentityService;
using MKHaberSistemi.Service.KategoriService;
using MKHaberSistemi.Service.ResimlerService;
using MKHaberSistemi.Service.ResimService;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace MKHaberSistemi.IOC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            RegisterTypes(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IGenericRepository<Haber>, GenericRepository<Haber>>();
            container.RegisterType<IGenericRepository<Etiket>, GenericRepository<Etiket>>();
            container.BindInRequestScope<IGenericRepository<Kategori>, GenericRepository<Kategori>>();
            container.RegisterType<IGenericRepository<Resim>, GenericRepository<Resim>>();
            container.RegisterType<IGenericRepository<Galeri>, GenericRepository<Galeri>>();

            var Constructor = new InjectionConstructor(new ApplicationDbContext());
            container.RegisterType<ApplicationSignInManager>();
            container.RegisterType<ApplicationUserRole>();
            container.RegisterType<ApplicationUserClaim>();
            container.RegisterType<ApplicationUserLogin>();
            container.RegisterType<ApplicationUserStore>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<ApplicationRoleManager>();
            container.RegisterType<ApplicationRoleStore>();


            container.RegisterType<EmailService>();
            container.RegisterType<SmsService>();

            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, ApplicationUserStore>(Constructor);
            container.RegisterType<RoleManager<ApplicationRole>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRoleStore<ApplicationRole>, ApplicationRoleStore>(Constructor);

            container.RegisterType<IAuthenticationManager>(
              new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));


            container.BindInRequestScope<IUnitOfWork, UnitOfWork>();

            container.RegisterType<IHaberService, HaberService>();
            container.RegisterType<IEtiketService, EtiketService>();
            container.RegisterType<IKategoriService, KategoriService>();
            container.RegisterType<IResimService, ResimService>();
            container.RegisterType<IGaleriService, GaleriService>();

        }
    }
    public static class IOCExtensions
    {
        public static void BindInRequestScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new HierarchicalLifetimeManager());
        }

        public static void BindInSingletonScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new ContainerControlledLifetimeManager());
        }
    }
}