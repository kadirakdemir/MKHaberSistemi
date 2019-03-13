using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MKHaberSistemi.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapMvcAttributeRoutes();
            // routes.MapRoute(
            //    name: "Admin",
            //    url: "Admin/{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] { "MKHaberSistemi.Areas.Admin.Controllers" }
            //);

          //  routes.MapRoute(
          //    name: "GaleriDetail",
          //    url: "Galeri/{galeriAdi}/{galeriId}",
          //    defaults: new
          //    {
          //        controller = "Galeri",
          //        action = "GaleriDetail",
          //        galeriAdi = UrlParameter.Optional,
          //        galeriId = UrlParameter.Optional
          //    }
          //    , namespaces: new[] { "MKHaberSistemi.Web.Controllers" }
          //);
         //   routes.MapRoute(
         //    name: "HaberDetay",
         //    url: "{kategoriAdi}/{haberBaslik}/{id}",
         //    defaults: new
         //    {
         //        controller = "Haber",
         //        action = "HaberDetay",
         //        id = UrlParameter.Optional
         //    }
         //    , namespaces: new[] { "MKHaberSistemi.Web.Controllers" }
         //);

          

           
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "MKHaberSistemi.Web.Controllers" }
           );
        }
    }
}
