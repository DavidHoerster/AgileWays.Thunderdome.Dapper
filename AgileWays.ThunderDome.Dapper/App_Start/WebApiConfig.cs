using AgileWays.ThunderDome.Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AgileWays.ThunderDome.Dapper
{
    public static class WebApiConfig
    {
        public static IEnumerable<PlayerLookup> Players = null;
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
