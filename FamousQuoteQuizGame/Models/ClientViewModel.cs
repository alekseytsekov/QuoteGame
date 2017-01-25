namespace FamousQuoteQuizGame.Models
{
    using System.Collections.Generic;
    using FamousQuoteQuizGame.Data.Models.Enums;
    using FamousQuoteQuizGame.Models.Enums;

    public class ClientViewModel
    {
        private IList<string> possibleAuthors;

        public ClientViewModel()
        {
            this.possibleAuthors = new List<string>();
        }
        
        public bool InvalidUser { get; set; }

        public string Quote { get; set; }

        public int QuoteId { get; set; }

        public IList<string> PossibleAuthors
        {
            get { return this.possibleAuthors; }
            set { this.possibleAuthors = value; }
        }

        public GameMode GameMode { get; set; }

        public AnswerType AnswerType { get; set; }

        public string RightAnswer { get; set; }

        public bool IsChecked { get; set; }
    }
}