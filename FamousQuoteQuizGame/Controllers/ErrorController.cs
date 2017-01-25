namespace FamousQuoteQuizGame.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        // GET: Error
        [HandleError]
        public ActionResult Error()
        {
            return this.View();
        }
    }
}