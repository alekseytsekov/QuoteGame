namespace FamousQuoteQuizGame.Models
{
    using System;

    public class HighScoreViewModel
    {
        private const int Multiplier = 100;

        private const string DefaultNickname = "Nickname";
        private const string DefaultAttempts = "Correct/Attempts";
        private const string DefaultResult = "Result";
        private const string DefaultPercentSign = "%";
        private const string DefaultDelimeterBetweenStats = "/";

        public string User { get; set; }

        public int CorrectAnswer { get; set; }

        public int AttemptsGuess { get; set; }
        
        public string Nickname
        {
            get { return DefaultNickname; }
        }

        public string Attempts
        {
            get { return DefaultAttempts; }
        }

        public string Result
        {
            get { return DefaultResult; }
        }

        public string PercentSign
        {
            get { return DefaultPercentSign; }
        }

        public double GetSuccessRating()
        {
            if (this.AttemptsGuess == 0 && this.CorrectAnswer == 0)
            {
                return 0;
            }
            return Math.Round((double)this.CorrectAnswer / this.AttemptsGuess * Multiplier, 2);
        }

        public string GetMixAttempts()
        {
            return this.CorrectAnswer + DefaultDelimeterBetweenStats + this.AttemptsGuess;
        }
    }
}