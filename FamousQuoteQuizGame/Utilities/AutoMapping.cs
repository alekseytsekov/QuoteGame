namespace FamousQuoteQuizGame.Utilities
{
    using AutoMapper;

    public class AutoMapping
    {
        public static void Config()
        {
            Mapper.Initialize(m =>
            {
                //m.CreateMap<UserStatistic, HighScoreViewModel>();
            });
        }
    }
}