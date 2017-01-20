namespace FamousQuoteQuizGame.Data.Common
{
    using FamousQuoteQuizGame.Data.Models;

    public interface IUnitOfWork
    {
        void Save();

        IDbRepository<UserStatistic> UserStatistics { get; }

        IDbRepository<Author> Authors { get; }

        IDbRepository<Quote> Quotes { get; }

        IDbRepository<UserGameInfo> UserGameInfos { get; }
    }
}
