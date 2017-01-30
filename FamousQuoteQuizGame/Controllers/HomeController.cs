namespace FamousQuoteQuizGame.Controllers
{
    using System.Web.Mvc;
    using FamousQuoteQuizGame.Globals;

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            this.ViewBag.MinAttempts = WorkerSettings.MinAttemptsGuess;
            this.ViewBag.MaxStandingList = WorkerSettings.MaxStandingList;

            return this.View();
        }
    }
}