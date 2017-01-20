namespace FamousQuoteQuizGame.Models
{
    using System;

    public class HighScoreViewModel
    {
        private const int Multiplier = 100;

        private const string DefaultNickName = "Nick Name";
        private const string DefaultAttempts = "Correct/Attempts";
        private const string DefaultResult = "Result";
        private const string percentSign = "%";
        private const string delimeterBetweenStats = "/";

        public string User { get; set; }

        public int CorrectAnswer { get; set; }

        public int AttemptsGuess { get; set; }
        
        public string NickName
        {
            get { return DefaultNickName; }
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
            get { return percentSign; }
        }

        public double GetSuccessRating()
        {
            return Math.Round((double)this.CorrectAnswer / this.AttemptsGuess * Multiplier, 2);
        }

        public string GetMixAttempts()
        {
            return this.CorrectAnswer + delimeterBetweenStats + this.AttemptsGuess;
        }
    }
}