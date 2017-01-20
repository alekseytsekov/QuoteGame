using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FamousQuoteQuizGame.Startup))]
namespace FamousQuoteQuizGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
