namespace FamousQuoteQuizGame.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using FamousQuoteQuizGame.Services;

    public class HighScoreController : Controller
    {
        private IWorker worker;
        public HighScoreController(IWorker worker)
        {
            this.worker = worker;
        }
        // GET: HighScore
        public ActionResult Standing()
        {
            var collection = this.worker.GetBestPlayers().OrderByDescending(x=> x.GetSuccessRating());
            
            return this.View(collection);
        }
    }
}