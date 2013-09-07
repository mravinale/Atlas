using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Atlas
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "api",
                routeTemplate: "api/{controller}/{action}"
            );
        }
         
    }
}
