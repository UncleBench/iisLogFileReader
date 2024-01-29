using System.Web.Mvc;
using System.Web.Routing;

namespace Api
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
                name: "API",
                url: "api/{controller}",
                defaults: new { action = "Get" }
            );

      routes.MapRoute(
          name: "SPA",
          url: "{*catchall}",
          defaults: new { controller = "Spa", action = "Index" }
      );
    }
  }
}
