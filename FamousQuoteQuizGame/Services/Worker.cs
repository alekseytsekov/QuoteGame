namespace FamousQuoteQuizGame.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FamousQuoteQuizGame.Data.Common;
    using FamousQuoteQuizGame.Data.Models;
    using FamousQuoteQuizGame.Data.Models.Enums;
    using FamousQuoteQuizGame.Globals;
    using FamousQuoteQuizGame.Models;
    using FamousQuoteQuizGame.Models.Enums;

    public class Worker : IWorker
    {
        private IUnitOfWork context;

        public Worker(IUnitOfWork context)
        {
            this.context = context;
        }

        public void AddInfoForUser(string userId)
        {
            try
            {
                var userGameInfo = new UserGameInfo();
                userGameInfo.UserId = userId;
                var userStatistics = new UserStatistic();
                userStatistics.UserId = userId;

                this.context.UserGameInfos.Add(userGameInfo);
                this.context.UserStatistics.Add(userStatistics);

                this.context.Save();
            }
            catch (Exception ex)
            {
                //log ex message
                throw new ArgumentException(GlobalMessage.InvalidUserId);
                
            }
        }

        public void UpdateStatistic(AnswerType modelAnswerType, string userId)
        {
            var userStat = this.context.UserStatistics.FirstOrDefault(x => x.UserId == userId);

            if (userStat.AttemptsGuess == null)
            {
                userStat.AttemptsGuess = 0;
            }

            userStat.AttemptsGuess++;

            if (userStat.CorrectAnswer == null)
            {
                userStat.CorrectAnswer = 0;
            }

            if (modelAnswerType == AnswerType.Correct)
            {
                userStat.CorrectAnswer++;
            }

            this.context.Save();
        }

        public void ChangeGameMode(string userId, GameMode gameMode)
        {
            //GameMode newGameMode = gameMode == WorkerSettings.FormKeyGameModeBinary ? GameMode.Binary : GameMode.Multiple;

            var userInfo = this.context.UserGameInfos.FirstOrDefault(x => x.UserId == userId);

            if (userInfo == null)
            {
                throw new ArgumentNullException(nameof(gameMode), GlobalMessage.InvalidUserId);
            }

            userInfo.GameMode = gameMode;
            this.context.Save();
        }

        public bool AddNewQuote(string quoteText, string authorName, string userId)
        {
            var userGameInfo = this.context.UserGameInfos.GetAll().FirstOrDefault(x => x.UserId == userId);

            if (userGameInfo == null)
            {
                return false;
                //throw new ArgumentNullException(GlobalMessage.InvalidArguments);
            }

            try
            {
                //await Task.Run(() =>
                //{

                //});
                authorName = authorName.Replace(",", " ");

                var author = new Author();
                author.Name = authorName;

                var quote = new Quote();
                quote.Content = quoteText;
                quote.Author = author;

                var ugi = this.context.UserGameInfos.GetAll().FirstOrDefault(x => x.UserId == userId);
                quote.UserGameInfo = ugi;
                ugi.Quotes.Add(quote);

                this.context.Quotes.Add(quote);
                this.context.Save();
            }
            catch (Exception ex)
            {
                // logger log the message;
                throw new ArgumentException(GlobalMessage.InvalidArguments);
            }
            return true;
        }

        public ClientViewModel PrepareModel(ClientViewModel model, string userId)
        {
            Random rnd = new Random();
            
            model.AnswerType = AnswerType.NotAnswer;
            model.IsChecked = false;

            var userGameInfo = this.context.UserGameInfos.GetAll().FirstOrDefault(x => x.UserId == userId);///

            if (userGameInfo == null)
            {
                model.InvalidUser = true;
                return model;
                //throw new ArgumentNullException(GlobalMessage.InvalidArguments);
            }

            model.GameMode = userGameInfo.GameMode;

            var quotesCount = this.context.Quotes.GetAll().Count(x => x.UserGameInfo.UserId != userId);
            var randomNum = rnd.Next(quotesCount);

            string[] quotes = this.GetQuoteAuthor(randomNum);

            for (int i = 0; i < quotes.Length; i += 3)
            {
                if (i == 0)
                {
                    model.QuoteId = int.Parse(quotes[i + 1]);
                    model.Quote = quotes[i];
                }

                model.PossibleAuthors.Add(quotes[i + 2]);
            }

            model.PossibleAuthors = this.Shuffle(model.PossibleAuthors);
            model.RightAnswer = model.PossibleAuthors.FirstOrDefault();
            
            return model;
        }

        public Tuple<bool,string> CheckResult(string author, int quoteId)
        {
            bool result;
            string correctAuthor = string.Empty;

            try
            {
                correctAuthor = this.context.Quotes.GetAll().FirstOrDefault(x => x.Id == quoteId).Author.Name;
                result = correctAuthor == author;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(GlobalMessage.InvalidArguments);
            }

            var tupleResult = new Tuple<bool,string>(result, correctAuthor);

            return tupleResult;
        }
        
        public IEnumerable<HighScoreViewModel> GetBestPlayers()
        {
           var stats = this.context.UserStatistics
                .GetAll()
                .Where(x => x.AttemptsGuess >= WorkerSettings.MinAttemptsGuess)
                .OrderByDescending(x => (double)x.CorrectAnswer/x.AttemptsGuess)
                .Take(WorkerSettings.MaxStandingList)
                .Select(x =>
                new {
                    UserName = x.User.UserName,
                    CorrectAnswers = x.CorrectAnswer,
                    Attempts = x.AttemptsGuess
                })
                .ToArray();
            //.Substring(0, x.User.UserName.IndexOf("@"))
            var scoreModels = new List<HighScoreViewModel>();

            foreach (var stat in stats)
            {
                var model = new HighScoreViewModel();

                model.User = stat.UserName.Contains("@") ? (stat.UserName.Substring(0, stat.UserName.IndexOf("@"))) : stat.UserName;
                model.CorrectAnswer = stat.CorrectAnswers == null ? 0 : stat.CorrectAnswers.Value;
                model.AttemptsGuess = stat.Attempts;
                scoreModels.Add(model);
            }

            //var dtos = Mapper.Map<IEnumerable<UserStatistic>, IEnumerable<HighScoreViewModel>>(stats);

            return scoreModels;
        }

        public bool CanAddQuote(string userId)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                new System.Globalization.CultureInfo("en-US");

            var currentDate = DateTime.UtcNow.Date;

            var canAdd = this.context.Quotes
                .GetAll()
                .Count(x => x.UserGameInfo.UserId == userId && x.CreatedOn >= currentDate) < WorkerSettings.MaxAddedQuotesPerDay;

            return  canAdd;
        }

        private IList<string> Shuffle(IList<string> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            Random rnd = new Random();

            for (int i = 0; i < collection.Count; i++)
            {
                this.Swap(collection, i, rnd.Next(collection.Count - i));
            }

            return collection;
        }

        private void Swap<T>(IList<T> collection, int firstElement, int secondElement)
        {
            T temp = collection[firstElement];
            collection[firstElement] = collection[secondElement];
            collection[secondElement] = temp;
        }

        private string[] GetQuoteAuthor(int randomNum)
        {
            string[] quotes = new string[WorkerSettings.MaxPossibleAnswers * WorkerSettings.MaxPossibleAnswers];

            var skipEntities = randomNum - WorkerSettings.MaxPossibleAnswers;

            if (skipEntities <= 0)
            {
                skipEntities = 0;
            }

            var query = this.context.Quotes.GetAll()
                            .OrderBy(x=>x.Id)
                            .Skip(skipEntities)
                            .Take(WorkerSettings.MaxPossibleAnswers)
                            .Select(x => new { x.Content, x.Id, x.Author.Name }).ToArray();

            int index = 0;
            foreach (var quote in query)
            {
                quotes[index] = quote.Content;
                quotes[index + 1] = quote.Id.ToString();
                quotes[index + 2] = quote.Name;
                index += WorkerSettings.MaxPossibleAnswers;
            }

            return quotes;
        }


    }
}