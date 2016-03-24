using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace GuessTheGames
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //when wanting a specific action
            config.Routes.MapHttpRoute(
                 "WithActionApi",
                 "api/{controller}/{action}/{id}"
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {action = "DefaultAction", id = RouteParameter.Optional }
            );

            //forcing all formatting to happen in json. XML gives serilization errors
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
