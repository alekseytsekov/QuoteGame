namespace FamousQuoteQuizGame.Data.Models
{
    public class UserStatistic : BaseModel
    {
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int? CorrectAnswer { get; set; }

        public int AttemptsGuess { get; set; }
    }
}
