using System.Web.Mvc;
using System.Web.Routing;

namespace DoAnWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "sinh_vien_62133178", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "PrintList",
               url: "sinh_vien_62133178/PrintList",
               defaults: new { controller = "sinh_vien_62133178", action = "PrintList" }
            );
        }
    }
}
