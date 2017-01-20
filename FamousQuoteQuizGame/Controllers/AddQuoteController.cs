namespace FamousQuoteQuizGame.Controllers
{
    using System.Web.Mvc;
    using FamousQuoteQuizGame.Globals;
    using FamousQuoteQuizGame.Models;
    using FamousQuoteQuizGame.Services;
    using Microsoft.AspNet.Identity;

    public class AddQuoteController : Controller
    {
        private IWorker worker;

        public AddQuoteController(IWorker worker)
        {
            this.worker = worker;
        }
        // GET: AddQuote
        public ActionResult AddQuote()
        {
            if (!this.Request.IsAuthenticated)
            {
                return this.RedirectToAction("Login", "Account");
            }
            
            return this.View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Respond(QuoteViewModel model, string submit)
        {
            var userId = this.User.Identity.GetUserId();

            var quote = model.TextArea;
            var author = model.TextBox;
            
            bool isSuccess = this.worker.AddNewQuote(quote, author, userId);

            if (!isSuccess)
            {
                return this.RedirectToAction("Login", "Account");
            }

            return this.RedirectToAction("Game", "Game");
        }
    }
}