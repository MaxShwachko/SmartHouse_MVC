﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SmartHouse_MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Value", id = RouteParameter.Optional }
            );
        }
    }
}
