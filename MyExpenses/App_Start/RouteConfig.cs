﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyExpenses
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Expenses", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               "Report", // Route name
               "{controller}/{action}/{FiscalYear}", // URL with parameters
               new { area = "", controller = "Report", action = "Index", FiscalYear = UrlParameter.Optional });
        }
    }
}
