﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ninjalista
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("public");
            routes.IgnoreRoute("{folder}/{*pathInfo}", new { folder = "images" });
            routes.IgnoreRoute("{folder}/{*pathInfo}", new { folder = "img" });


           

            routes.MapRoute( "ErrorPage",
                             "Error"
                             ,new{ controller = "Error" ,Action = "Error"}
                );

            routes.MapRoute("404Page",
                            "PageNotFound"
                            , new { controller = "Error", Action = "PageNotFound" }
               );

           
            
            routes.MapRoute(
                             "Default", // Route name
                             "{controller}/{action}/{id}", // URL with parameters
                              new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );
            routes.MapRoute("ManageCategories", //RouteName
                         "ManageCategories",
                         new { controller = "Home", action = "ManageCategories" }
             );
            routes.MapRoute("ManageSubCategories", //RouteName
                      "ManageSubCategories",
                      new { controller = "Home", action = "ManageSubCategories" }
          );
            routes.MapRoute("SubcatList", //RouteName
                      "SubcatList",
                      new { controller = "Home", action = "SubcatList" }
          );
            
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}