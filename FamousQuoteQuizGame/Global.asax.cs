namespace FamousQuoteQuizGame
{
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using FamousQuoteQuizGame.Data;
    using FamousQuoteQuizGame.Data.Migrations;
    using FamousQuoteQuizGame.Utilities;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapping.Config();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FamousQuoteDbContext, Configuration>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
