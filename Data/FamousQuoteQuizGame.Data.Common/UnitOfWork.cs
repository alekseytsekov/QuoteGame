namespace FamousQuoteQuizGame.Data.Common
{
    using FamousQuoteQuizGame.Data.Models;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly FamousQuoteDbContext context;

        private IDbRepository<UserStatistic> userStatistics;
        private IDbRepository<Author> authors;
        private IDbRepository<Quote> quotes;
        private IDbRepository<UserGameInfo> userGameInfos;

        public UnitOfWork(FamousQuoteDbContext context)
        {
            this.context = context;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
        
        public IDbRepository<UserStatistic> UserStatistics
        {
            get
            {
                if (this.userStatistics == null)
                {
                    return this.userStatistics = new DbRepository<UserStatistic>(this.context.UserStatistics);
                }

                return this.userStatistics;
            }
        }

        public IDbRepository<Author> Authors
        {
            get
            {
                if (this.authors == null)
                {
                    return this.authors = new DbRepository<Author>(this.context.Authors);
                }

                return this.authors;
            }
        }

        public IDbRepository<Quote> Quotes
        {
            get
            {
                if (this.quotes == null)
                {
                    return this.quotes = new DbRepository<Quote>(this.context.Quotes);
                }

                return this.quotes;
            }
        }

        public IDbRepository<UserGameInfo> UserGameInfos
        {
            get
            {
                if (this.userGameInfos == null)
                {
                    return this.userGameInfos = new DbRepository<UserGameInfo>(this.context.UserGameInfos);
                }

                return this.userGameInfos;
            }
        }
    }
}
