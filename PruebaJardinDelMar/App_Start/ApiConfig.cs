using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PruebaJardinDelMar.UI
{
    public static class ApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            if (config != null)
            {
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
        }
    }
}