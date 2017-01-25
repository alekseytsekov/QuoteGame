namespace FamousQuoteQuizGame.Controllers
{
    using System.Web.Mvc;
    using FamousQuoteQuizGame.Globals;
    using FamousQuoteQuizGame.Models;
    using FamousQuoteQuizGame.Services;
    using Microsoft.AspNet.Identity;

    public class GameOptionController : Controller
    {
        private IWorker worker;
        
        public GameOptionController(IWorker worker)
        {
            this.worker = worker;
        }

        /* Game Option */
        //[HttpPost]
        public ActionResult GameOption()
        {
            if (!this.Request.IsAuthenticated)
            {
                return this.RedirectToAction("Login", "Account");
            }

            return this.PartialView("GameOption");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetOptions(ClientViewModel model, string submit)
        {
            var userId = this.User.Identity.GetUserId();

            if (submit.ToLower() == WorkerSettings.FormKeySaveString)
            {
                this.worker.ChangeGameMode(userId, model.GameMode);
            }

            return this.Redirect(this.Request.UrlReferrer.PathAndQuery);
        }
    }
}