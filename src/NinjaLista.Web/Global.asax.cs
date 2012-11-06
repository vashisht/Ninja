using System;
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

            routes.MapRoute("details", //RouteName
                            "details",
                            new { controller = "Home", action = "details" }
                );
            
            routes.MapRoute("Contact", //RouteName
                            "contato",
                            new { controller = "Home", action = "contato" }
                );
            routes.MapRoute("LinkLondeners", //RouteName
                           "Linksuteisemlondres",
                           new { controller = "Home", action = "Linksuteisemlondres" }
               );
            routes.MapRoute("termsandConditions", //RouteName
                        "terms-and-conditions",
                        new { controller = "Home", action = "termsAndConditions" }
            );
            routes.MapRoute("StaticPages", //RouteName
                "Page/{page}",

                new { controller = "Home", action = "Page" }
              );
     
            routes.MapRoute("policy", //RouteName
                       "privacy-policy",
                       new { controller = "Home", action = "policypage" }
           );

            routes.MapRoute("Partners", //RouteName
                         "Partners",
                         new { controller = "Home", action = "Partners" }
             );
            routes.MapRoute("PostAd",
                                "PostAd",
                                new { controller = "Home", Action = "PostAd" });

            routes.MapRoute("Preview",
                "Preview-ad",
                new { controller = "Home", action = "PreviewAd" });

            routes.MapRoute("ReplyAd",
                                "Replyad/{id}",
                                new { controller = "Home", Action = "ReplyAd", id = UrlParameter.Optional });
            routes.MapRoute("Confirmation",
                             "Confirmation"
                             , new { controller = "Home" , Action = "Confirmation" });
            routes.MapRoute("SubCategoryDropdown",
                             "SubCategoryDropdown"
                             , new { controller = "Home", Action = "SubCategoryDropdown" });

            routes.MapRoute("Captcha",
                             "Captcha"
                             , new { controller = "Home", Action = "Captcha" });

            routes.MapRoute("ValidateCaptcha",
                            "ValidateCaptcha"
                            , new { controller = "Home", Action = "ValidateCaptcha" });

            routes.MapRoute("FixedSizeImage",
                            "FixedSizeImage"
                            , new { controller = "Photo", Action = "FixedSizeImage" });

            

            routes.MapRoute( "ErrorPage",
                             "Error"
                             ,new{ controller = "Error" ,Action = "Error"}
                );

            routes.MapRoute("404Page",
                            "PageNotFound"
                            , new { controller = "Error", Action = "PageNotFound" }
               );


            routes.MapRoute("ResultsPage", //RouteName
                "cat/{categoryName}/{Id}/{page}",

                new { controller = "Home", action = "AdResultsByCategory", page = UrlParameter.Optional }
              );
            routes.MapRoute("SearchPage", //RouteName
                "search/{keyword}/{page}",

                new { controller = "Home", action = "SearchResults", keyword = "", page = UrlParameter.Optional }
              );
            routes.MapRoute("ResultsPageSubCategory", //RouteName
                "{categoryName}/{subcategoryName}/{Id}/{page}",

                new { controller = "Home", action = "AdResults", page = UrlParameter.Optional }
              );


            routes.MapRoute("DetailsPage", //RouteName
                            "details/{category}/{subcategory}/{title}/{Id}",
                            new { controller = "Home", action = "Details", category = "", subcategory = "", title = "", Id = "" });

            routes.MapRoute(
                             "Default", // Route name
                             "{controller}/{action}/{id}", // URL with parameters
                              new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}