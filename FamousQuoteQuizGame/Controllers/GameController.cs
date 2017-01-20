namespace FamousQuoteQuizGame.Controllers
{
    using System;
    using System.Web.Mvc;
    using FamousQuoteQuizGame.Enums;
    using FamousQuoteQuizGame.Globals;
    using FamousQuoteQuizGame.Models;
    using FamousQuoteQuizGame.Services;
    using Microsoft.AspNet.Identity;

    public class GameController : Controller
    {
        private IWorker worker;

        public GameController( IWorker worker)
        {
            this.worker = worker;
        }
        
        // GET: Play
        public ActionResult Game(ClientViewModel model)
        {
            if (!this.Request.IsAuthenticated)
            {
                return this.RedirectToAction("Login", "Account");
            }

            if (model == null || model.RightAnswer == null)
            {
                var userId = this.User.Identity.GetUserId();

                model = new ClientViewModel();

                model = this.worker.PrepareModel(model, userId);

                if (model.InvalidUser)
                {
                    return this.RedirectToAction("Login", "Account");
                }
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BinaryAnswer(ClientViewModel model, string yes, string no)
        {
            string author = model.RightAnswer;
            int quoteId = model.QuoteId;
            bool userSubmit = yes != null;

            var tupleResult = this.worker.CheckResult(author, quoteId);

            var newModel = this.SetAnswerModel(tupleResult, userSubmit);

            return this.RedirectToAction("Game", newModel);
        }

        private ClientViewModel SetAnswerModel(Tuple<bool, string> tupleResult, bool? tempResult)
        {
            ClientViewModel model = new ClientViewModel();

            model.IsChecked = true;

            if (tempResult == null)
            {
                model.AnswerType = tupleResult.Item1 ? AnswerType.Correct : AnswerType.Wrong;
            }
            else
            {
                model.AnswerType = tupleResult.Item1 == tempResult ? AnswerType.Correct : AnswerType.Wrong;
            }

            model.RightAnswer = tupleResult.Item2; // Corect Author
            
            var userId = this.User.Identity.GetUserId();
            this.worker.UpdateStatistic(model.AnswerType, userId);
            return model;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MultiAnswer(ClientViewModel model,string answer)
        {
            int quoteId = model.QuoteId;
            string author = answer;
            
            var tupleResult = this.worker.CheckResult(author, quoteId);

            var newModel = this.SetAnswerModel(tupleResult, null);

            return this.RedirectToAction("Game", newModel);
        }
        
    }
}