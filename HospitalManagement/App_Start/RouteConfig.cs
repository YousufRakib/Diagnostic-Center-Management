using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HospitalManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "Login", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    "HomeActions",
            //    "{action}",
            //    new { action = "AddCategory" }
            //);
        }
    }
}
