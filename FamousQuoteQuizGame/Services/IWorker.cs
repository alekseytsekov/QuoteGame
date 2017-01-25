namespace FamousQuoteQuizGame.Services
{
    using System;
    using System.Collections.Generic;
    using FamousQuoteQuizGame.Data.Models.Enums;
    using FamousQuoteQuizGame.Models;
    using FamousQuoteQuizGame.Models.Enums;

    public interface IWorker
    {
         void AddInfoForUser(string userId);

        bool AddNewQuote(string quoteText, string authorName, string userId);

        ClientViewModel PrepareModel(ClientViewModel model, string userId);

        Tuple<bool, string> CheckResult(string author, int quoteId);

        void UpdateStatistic(AnswerType modelAnswerType, string userId);

        void ChangeGameMode(string userId, GameMode gameMode);

        IEnumerable<HighScoreViewModel> GetBestPlayers();
    }
}
