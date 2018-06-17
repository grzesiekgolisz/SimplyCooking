using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimplyCooking
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
       
            //routes.MapRoute(
            //    name: "przepisy",
            //    url:"Recipes/wyswietlanie/{id}",
            //defaults: new { controller = "Recipes", action = "Wyswiatlanie", id = UrlParameter.Optional }
            //);


            routes.MapRoute(
                  name: "Default1",
                  url: "{controller}/{action}/{id}",
                  defaults: new { controller = "Home", action = "recipes", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                  name: "Default2",
                  url: "{controller}/{action}/{id}",
                  defaults: new { controller = "Home", action = "details", id = UrlParameter.Optional }

            );

        }
    }
}
