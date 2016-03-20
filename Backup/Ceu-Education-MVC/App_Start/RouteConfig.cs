using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ceu_Education_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute
            (
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MainPage",action="Index", id = UrlParameter.Optional }
            );
            //routes.MapRoute
            //(
            //    name: "PersonProfile",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "PersonProfile", id = UrlParameter.Optional }
            //);

        }
    }
}