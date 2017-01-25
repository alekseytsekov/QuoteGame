namespace FamousQuoteQuizGame
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // http://localhost:50306/gameoption/gameoption

            //routes.MapRoute(
            //    name: "/gameoption",
            //    url: "gameoption/{action}",
            //    defaults: new { controller = "Game", action = "Game", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Game", action = "Game", id = UrlParameter.Optional }
            );
        }
    }
}
