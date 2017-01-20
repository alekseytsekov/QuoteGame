namespace FamousQuoteQuizGame.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FamousQuoteQuizGame.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<FamousQuoteQuizGame.Data.FamousQuoteDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(FamousQuoteQuizGame.Data.FamousQuoteDbContext context)
        {
            if (context.Quotes.Any())
            {
                return;
            }

            string[] data = new[]
            {
                "The best preparation for tomorrow is doing your best today. ",
                "H. Jackson Brown, Jr.",
                "Good, better, best. Never let it rest. 'Til your good is better and your better is best.",
                "St. Jerome",
                "The best and most beautiful things in the world cannot be seen or even touched - they must be felt with the heart.",
                "Helen Keller",
                "A strong, positive self-image is the best possible preparation for success",
                "Joyce Brothers",
                "Always do your best. What you plant now, you will harvest later.",
                "Og Mandino",
                "Health is the greatest gift, contentment the greatest wealth, faithfulness the best relationship.",
                "Buddha",
                "The best thing to hold onto in life is each other.",
                "Audrey Hepburn",
                "My best friend is the one who brings out the best in me.",
                "Henry Ford",
                "Write it on your heart that every day is the best day in the year.",
                "Ralph Waldo Emerson",
                "The best way to pay for a lovely moment is to enjoy it.",
                "Richard Bach",
                "Work hard, stay positive, and get up early. It's the best part of the day. ",
                "George Allen, Sr."
            };

            for (int i = 0; i < data.Length; i+=2)
            {
                var dataQuote = data[i].Trim();
                var dataAuthorName = data[i + 1].Trim().Replace(",", " ");

                var author = new Author();
                author.Name = dataAuthorName;

                var quote = new Quote();
                quote.Content = dataQuote;
                quote.Author = author;

                context.Quotes.Add(quote);
            }

            context.SaveChanges();
        }
    }
}
