namespace FamousQuoteQuizGame.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using FamousQuoteQuizGame.Data.Models.Enums;

    public class UserGameInfo : BaseModel
    {
        private IList<Quote> quotes;

        public UserGameInfo()
        {
            this.quotes = new List<Quote>();
        }
        
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [DefaultValue(GameMode.Binary)]
        public GameMode GameMode { get; set; }

        public virtual IList<Quote> Quotes
        {
            get { return this.quotes; }
            set { this.quotes = value; }
        }
    }
}
